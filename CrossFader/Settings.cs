using ScriptPortal.Vegas;
using System;
using System.Collections.Generic;

namespace CrossFader
{
    public class Settings
    {
        public bool ShowDialog { get; set; }
        public long CrossFadeLength { get; set; }
        public TimeUnit TimeUnit { get; set; }
        public ScriptMode ScriptMode { get; set; }
        public bool AllowLoops { get; set; }
        public bool ChangeCurveType { get; set; }
        public CurveType LeftCurveType { get; set; }
        public CurveType RightCurveType { get; set; }
        public TransitionMode TransitionMode { get; set; }
        public string TransitionAndPresetName { get; set; }
        public Effect Effect { get; set; }
        public string PresetName { get; set; }
        public bool ExpandToAvailableSize { get; set; }

        public static List<string> TransitionPresetNames { get; set; }

        public static Vegas Vegas { get; set; }
        public static string ScriptFileName { get; set; }

        public static Timecode ZeroTime { get; set; }

        public static List<string> GetTransitions()
        {
            if (Vegas == null)
                throw new Exception("Vegas static property in Settings cannot be null");

            List<string> names = new List<string>();
            foreach (var transition in Vegas.Transitions)
            {
                if (transition.IsContainer)
                    continue;
                foreach (var preset in transition.Presets)
                {
                    names.Add(transition.Name + "\\" + preset.Name);
                }
            }
            return names;
        }

        public static Dictionary<CurveType, string> LeftCurveTypes { get; set; }
        public static Dictionary<CurveType, string> RightCurveTypes { get; set; }
        public static Dictionary<ScriptMode, string> ScriptModesList { get; set; }
        public Dictionary<TransitionMode, string> TransitionModeList { get; set; }

        public Settings()
        {
            ScriptFileName = "CrossFader.cs";

            LeftCurveTypes = new Dictionary<CurveType, string>
            {
                {CurveType.Fast, "Fast" },
                {CurveType.Linear, "Linear" },
                {CurveType.Sharp, "Sharp" },
                {CurveType.Slow, "Slow (audio default)" },
                {CurveType.Smooth, "Smooth (video default)" },
            };

            RightCurveTypes = new Dictionary<CurveType, string>
            {
                {CurveType.Fast, "Fast (audio default)" },
                {CurveType.Linear, "Linear" },
                {CurveType.Sharp, "Sharp" },
                {CurveType.Slow, "Slow" },
                {CurveType.Smooth, "Smooth (video default)" },
            };

            ScriptModesList = new Dictionary<ScriptMode, string>
            {
                { ScriptMode.CreateNewCrossfades, "Create Crossfades" },
                { ScriptMode.ChangeExistingCrossfades, "Change Existing Crossfades Curves"},
                { ScriptMode.RemoveCrossfades, "Remove Crossfades"},
                { ScriptMode.DoNothingWithCrossfades, "Do Nothing With Crossfades"}
            };

            TransitionModeList = new Dictionary<TransitionMode, string>
            {
                { TransitionMode.NoTransition, "Do Not Add Transition" },
                { TransitionMode.AddTransition, "Add Transition To Video Events"},
                { TransitionMode.RemoveTransition, "Remove Existing Transitions"}
            };

            ZeroTime = new Timecode();
        }
    }

    public enum TimeUnit
    {
        Milliseconds,
        Frames
    }

    public enum ScriptMode
    {
        CreateNewCrossfades,
        ChangeExistingCrossfades,
        RemoveCrossfades,
        DoNothingWithCrossfades
    }

    public enum TransitionMode
    {
        NoTransition,
        AddTransition,
        RemoveTransition
    }
}
