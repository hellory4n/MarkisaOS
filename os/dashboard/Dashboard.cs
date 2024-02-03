using Godot;
using markisa.foundation;
using System;

namespace markisa.dashboard {

public class Dashboard : Control
{
    public override void _Ready()
    {
        Frambos.Play(SystemSound.Startup);
    }
}

}