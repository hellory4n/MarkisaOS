using Godot;
using System;

namespace passionfruit.coreapps.connect {

public class MuteMusic : Button
{
    readonly Texture enabled = GD.Load<Texture>("res://os/assets/highPeaks/icons/musicNote.png");
    readonly Texture disabled  = GD.Load<Texture>("res://os/assets/highPeaks/icons/musicOff.png");
    AudioStreamPlayer music;

    public override void _Ready()
    {
        music = GetNode<AudioStreamPlayer>("../../music");
    }

    public override void _Toggled(bool buttonPressed)
    {
        Icon = buttonPressed ? disabled : enabled;
    }

    public override void _Process(float delta)
    {
        music.StreamPaused = Pressed || !music.GetParent<Control>().Visible;
    }
}

}