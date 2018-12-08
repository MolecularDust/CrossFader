/*
    This is a mass crossfade script for Vegas Pro that allows to create and remove crossfades and video transitions and change their properties.

    Basic operation: set crossfade's length in milliseconds or frames and click OK button.
    This will create crossfadеs in place of cuts for every selected event.

    "Allow Loops": by default the script skips events that have loops, i.e. the event's right margin exceeds the original clip length.
    Nor does it create a crossfade if detects that looping occurs when making a crossfade. 
    This is made to avoid rogue cuts in video and "broken record" stutters in audio. 
    Loops are okay, however, for generated media like text or solids.
    Check this box to skip loop detection and always create a crossfade in a selected event no matter what.

    If you wish you may add a Transition to the newly created crossfades in video events.

    You can set custom curves while creating a new crossfade or switch into "Change Existing Crossfades Curves" mode.

    "Remove Crossfades" mode is self-explanatory.

    "Do Nothing With Crossfades" skips crossfades module completely and allows creating or removing transitions in video events solely.

    The script can operate in non-interactive mode, without GUI.
    To do so change script's settings below and set Settings.ShowDialog to false and tune other settings to your needs.
    This way you can copy the script to a new file with custom settings and run it triggered by a shortcut key.

    "Edit Script" menu opens "CrossFader.cs" in Notepad for a quick edit.

*/

using ScriptPortal.Vegas;
using System;
using System.Windows.Forms;

namespace CrossFader
{
    public class EntryPoint
    {
        public Settings Settings { get; set; } 

        public void FromVegas(Vegas vegas)
        {
            Settings = new Settings();

            // ********* Change default script paremeters here

            Settings.CrossFadeLength = 500;    // Set default crossfade lenght here
            Settings.TimeUnit = TimeUnit.Milliseconds; // Set crossfade's time unit: milliseconds or frames
            Settings.ScriptMode = ScriptMode.CreateNewCrossfades;
            Settings.ChangeCurveType = false; // Set to true to be able to change curve types
            Settings.LeftCurveType = CurveType.Slow; // Left curve type: Fast, Linear, Sharp, Slow, Smooth. Vegas's default is Slow for audio and Smooth for video
            Settings.RightCurveType = CurveType.Fast; // Right curve type: Fast, Linear, Sharp, Slow, Smooth. Vegas's default is Fast for audio and Smooth for video
            Settings.TransitionMode = TransitionMode.NoTransition;   // Add/Remove transision to video events. Chose NoTransition, AddTransition, RemoveTransition of Scanning for available transition presets for the first time may be slow
            Settings.AllowLoops = false; // Allow crossfades to expand beyond clip's original length
            Settings.ShowDialog = true;  // Show dialog window or run the script with these settings without user prompt
            Settings.TransitionAndPresetName = ""; //Put transition and preset names here, e.g. "VEGAS Portals\\Mondrian" if you use the script non-interactively by changing Settings.ShowDialog to true

            // ********* Do no change anything below unless you know what you're doing

            Settings.Vegas = vegas;

            try
            {
                if (Settings.ShowDialog)
                {
                    var form = new CrossFaderForm(Settings);
                    var dialogResult = form.ShowDialog();
                    if (dialogResult != DialogResult.OK)
                        return;
                }

                if (Settings.TransitionMode == TransitionMode.AddTransition && Settings.ShowDialog == false && string.IsNullOrEmpty(Settings.TransitionAndPresetName))
                {
                    throw new Exception ("The script needs to know what transition preset to use. To apply video transitions in silent mode edit TransitionAndPresetName settings property, for example:\n\n" +
                        "Settings.TransitionAndPresetName = \"VEGAS Portals\\\\Mondrian\";");
                }

                if (Settings.TransitionMode == TransitionMode.AddTransition)
                    FindTransition();

                Timecode CrossFade = null;
                Timecode HalfCrossFade = null;

                switch (Settings.TimeUnit)
                {
                    case TimeUnit.Milliseconds:
                        CrossFade = Timecode.FromMilliseconds(Settings.CrossFadeLength);
                        HalfCrossFade = Timecode.FromMilliseconds(Settings.CrossFadeLength / 2);
                        break;
                    case TimeUnit.Frames:
                        CrossFade = Timecode.FromFrames(Settings.CrossFadeLength);
                        HalfCrossFade = Timecode.FromFrames(Settings.CrossFadeLength / 2);
                        break;
                }

                foreach (Track track in vegas.Project.Tracks)
                {
                    foreach (TrackEvent trackEvent in track.Events)
                    {
                        if (trackEvent.Selected)
                        {
                            switch (Settings.ScriptMode)
                            {
                                case ScriptMode.CreateNewCrossfades:
                                    CreateCrossFades(trackEvent, track, HalfCrossFade);
                                    break;
                                case ScriptMode.ChangeExistingCrossfades:
                                    ChangeExistingCrossFades(trackEvent, track);
                                    break;
                                case ScriptMode.RemoveCrossfades:
                                    RemoveCrossFades(trackEvent, track);
                                    break;
                            }

                            if (trackEvent.IsVideo())
                            {
                                switch (Settings.TransitionMode)
                                {
                                    case TransitionMode.AddTransition:
                                        AddTransition(trackEvent);
                                        break;
                                    case TransitionMode.RemoveTransition:
                                        trackEvent.FadeIn.RemoveTransition();
                                        break;
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                vegas.ShowError(ex);
            }
        }

        void CreateCrossFades(TrackEvent trackEvent, Track track, Timecode halfCrossFade)
        {
            if (trackEvent.Index >= 1) // Check current event and the previous one
            {
                var previousEvent = track.Events[trackEvent.Index - 1];
                if (previousEvent.End == trackEvent.Start) // If they form a straight cut expand margins
                {
                    ExpandRightMargin(previousEvent, halfCrossFade, Settings.AllowLoops);
                    ExpandLeftMargin(trackEvent, halfCrossFade, Settings.AllowLoops);
                    if (Settings.ChangeCurveType)
                        ApplyCurves(trackEvent);
                }
            }
            if (trackEvent.Index < track.Events.Count - 1) // Check current event and the next one
            {
                var nextEvent = track.Events[trackEvent.Index + 1];
                if (trackEvent.End == nextEvent.Start) // If they form a straight cut expand margins
                {
                    ExpandRightMargin(trackEvent, halfCrossFade, Settings.AllowLoops);
                    ExpandLeftMargin(nextEvent, halfCrossFade, Settings.AllowLoops);
                    if (Settings.TransitionMode == TransitionMode.AddTransition && nextEvent.IsVideo())
                        AddTransition(nextEvent);
                    if (Settings.ChangeCurveType)
                        ApplyCurves(nextEvent);
                }
            }
        }

        void ChangeExistingCrossFades(TrackEvent trackEvent, Track track)
        {
            if (trackEvent.Index >= 1) // Check current event and the previous one
            {
                var previousEvent = track.Events[trackEvent.Index - 1];
                if (EventsOverlap(previousEvent, trackEvent))
                    ApplyCurves(trackEvent);
            }
            if (trackEvent.Index < track.Events.Count - 1) // Check current event and the next one
            {
                var nextEvent = track.Events[trackEvent.Index + 1];
                if (EventsOverlap(trackEvent, nextEvent)) // If they form a straight cut expand margins
                    ApplyCurves(nextEvent);
            }
        }

        void RemoveCrossFades(TrackEvent trackEvent, Track track)
        {
            if (trackEvent.Index >= 1) // Check current event and the previous one
            {
                var previousEvent = track.Events[trackEvent.Index - 1];
                if (EventsOverlap(previousEvent, trackEvent))
                    RemoveCrossFade(previousEvent, trackEvent);
            }
            if (trackEvent.Index < track.Events.Count - 1) // Check current event and the next one
            {
                var nextEvent = track.Events[trackEvent.Index + 1];
                if (EventsOverlap(trackEvent, nextEvent))
                    RemoveCrossFade(trackEvent, nextEvent);
            }
        }

        void RemoveCrossFade(TrackEvent firstEvent, TrackEvent secondEvent)
        {
            var crossfadeLength = firstEvent.End - secondEvent.Start;
            var half = Timecode.FromNanos(crossfadeLength.Nanos / 2 );
            firstEvent.Length -= half;
            firstEvent.FadeOut.Length = Settings.ZeroTime;
            secondEvent.Start = firstEvent.End;
            secondEvent.Length -= half;
            secondEvent.ActiveTake.Offset += half;
            secondEvent.FadeIn.Length = Settings.ZeroTime;
        }

        void ApplyCurves(TrackEvent trackEvent)
        {
            trackEvent.FadeIn.ReciprocalCurve = Settings.LeftCurveType;
            trackEvent.FadeIn.Curve = Settings.RightCurveType;
        }

        bool EventsOverlap (TrackEvent firstEvent, TrackEvent secondEvent)
        {
            if (firstEvent.End > secondEvent.Start)
                return true;
            else
                return false;
        }

        void ExpandLeftMargin(TrackEvent trackEvent, Timecode addTime, bool force = false)
        {
            var offset = trackEvent.ActiveTake.Offset;
            Timecode newOffset = Settings.ZeroTime; // Set new offset to 0
            bool loop = EventHasLoop(trackEvent);
            if ((offset - addTime > newOffset && !loop) || force == true)
            {
                newOffset = offset - addTime; // Or else the new offset remains 0
                trackEvent.Start -= addTime;
                trackEvent.End += addTime;
            }
            else
            {
                if (Settings.ExpandToAvailableSize && !loop) // Expand to available size
                {
                    // Expand if there is available length even though the crossfade's will be shorter than set by user
                    trackEvent.Start -= offset;
                    trackEvent.End += offset;
                }
            }
            trackEvent.ActiveTake.Offset = newOffset;
        }

        void ExpandRightMargin(TrackEvent trackEvent, Timecode addTime, bool force = false)
        {
            var rightMargin = trackEvent.ActiveTake.Offset + trackEvent.Length;
            if (rightMargin + addTime <= trackEvent.ActiveTake.AvailableLength || force == true)
            {
                trackEvent.End += addTime;
            }
            else
            {
                if (Settings.ExpandToAvailableSize && !EventHasLoop(trackEvent)) // Expand to available size
                {
                    // Expand if there is available length even though the crossfade's will be shorter than set by user
                    if (trackEvent.Length < trackEvent.ActiveTake.AvailableLength)
                        trackEvent.End += trackEvent.ActiveTake.AvailableLength - rightMargin;
                }
            }
        }

        bool EventHasLoop(TrackEvent trackEvent)
        {
            if (trackEvent.Length > trackEvent.ActiveTake.Length)
                return true;
            else
                return false;
        }

        void FindTransition()
        {
            if (string.IsNullOrEmpty(Settings.TransitionAndPresetName))
                throw new Exception("Settings.TransitionAndPresetName cannot be empty.");
            string[] split = Settings.TransitionAndPresetName.Split('\\');
            if (split == null || split.Length < 2 || string.IsNullOrEmpty(split[0]) || string.IsNullOrEmpty(split[1]))
                throw new Exception("Could not read transition or preset name");
            string transitionName = split[0];
            string presetName = split[1];

            var transition = Settings.Vegas.Transitions.FindChildByName(transitionName);
            var effect = new Effect(transition);
            Settings.Effect = effect;
            Settings.PresetName = presetName;
        }

        void AddTransition(TrackEvent trackEvent)
        {
            var newEffect = new Effect(Settings.Effect.PlugIn);
            trackEvent.FadeIn.Transition = newEffect;
            newEffect.Preset = Settings.PresetName;
        }
    }
}
