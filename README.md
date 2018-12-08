# CrossFader    

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
