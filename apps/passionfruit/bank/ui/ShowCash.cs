using Godot;
using markisa.foundation;
using System;

namespace markisa.network {

public class ShowCash : Label
{
    public override void _Ready()
    {
        var config = new Config<Banking>();
        Text = $"Ø{config.Data.Cash:F2}";
    }
}

}