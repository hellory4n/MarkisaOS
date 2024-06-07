using Godot;
using markisa.foundation;
using System;

namespace passionfruit.coreapps.settings {

public class ReducedMotionCheckbox : CheckBox
{
    public override void _Ready()
    {
        var config = new Config<ReducedMotion>();
        SetPressedNoSignal(config.Data.Enabled);
    }

    public override void _Toggled(bool buttonPressed)
    {
        var config = new Config<ReducedMotion>();
        config.Data.Enabled = buttonPressed;
        config.Save();
    }
}

}