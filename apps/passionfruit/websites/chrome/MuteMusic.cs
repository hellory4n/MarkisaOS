using Godot;
using System;

namespace passionfruit.coreapps.websites {

public class MuteMusic : Button
{
    readonly Texture enabled = GD.Load<Texture>("res://os/assets/highPeaks/icons/musicNote.png");
    readonly Texture disabled  = GD.Load<Texture>("res://os/assets/highPeaks/icons/musicOff.png");

    public override void _Toggled(bool buttonPressed)
    {
        Icon = buttonPressed ? disabled : enabled;
    }
}

}