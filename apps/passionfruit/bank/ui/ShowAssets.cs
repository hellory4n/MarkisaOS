using Godot;
using markisa.foundation;
using System;

namespace markisa.network {

public class ShowAssets : Label
{
    public override void _Ready()
    {
        var config = new Config<Banking>();
        Text = $"Ø{config.Data.Assets:F2}";
    }
}

}