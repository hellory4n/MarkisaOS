using Godot;
using markisa.foundation;
using System;

public class ASpinBoxThatSpecifyAQuantityOfMoneyToSend : SpinBox
{
    public override void _Ready()
    {
        var config = new Config<Banking>();
        MaxValue = (double)config.Data.Cash;
    }
}
