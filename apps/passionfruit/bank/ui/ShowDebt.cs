using Godot;
using markisa.foundation;
using System;

namespace markisa.network {

public class ShowDebt : Label
{
    public override void _Ready()
    {
        var config = new Config<Banking>();
        Text = $"Ø{config.Data.Debt:F2}";
    }
}

}