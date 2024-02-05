using Godot;
using markisa.foundation;
using markisa.kickstart;
using System;

namespace passionfruit.coreapps.settings {

public class DisableComputerNoisesAndShit : CheckBox
{
    [Export]
    public int Shit;

    public override void _Ready()
    {
        var fig = new Config<ComputerNoisesConfig>();
        switch (Shit) {
            case 0: SetPressedNoSignal(fig.Data.Fan); break;
            case 1: SetPressedNoSignal(fig.Data.Disk); break;
            case 2: SetPressedNoSignal(fig.Data.Mouse); break;
            case 3: SetPressedNoSignal(fig.Data.Keyboard); break;
        }
    }

    public override void _Toggled(bool buttonPressed)
    {
        var fig = new Config<ComputerNoisesConfig>();
        var pee = GetNode<ComputerNoises>("/root/ComputerNoises");
        switch (Shit) {
            case 0:
                fig.Data.Fan = buttonPressed;
                pee.FanEnabled = buttonPressed;
                break;
            
            case 1:
                fig.Data.Disk = buttonPressed;
                pee.DiskEnabled = buttonPressed;
                break;
            
            case 2:
                fig.Data.Mouse = buttonPressed;
                pee.MouseEnabled = buttonPressed;
                break;
            
            case 3:
                fig.Data.Keyboard = buttonPressed;
                pee.KeyboardEnabled = buttonPressed;
                break;
        }
        fig.Save();
    }
}

}