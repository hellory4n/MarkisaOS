using Godot;
using markisa.foundation;
using markisa.network;
using System;

namespace passionfruit.coreapps.connect {

public class BluckBluckBluckBaBluckBluckBlucka : Button
{
    public override void _Ready()
    {
        GD.Print("M");
        Visible = false;
        GD.Print("N");
        #if DEBUG
        GD.Print("B");
        Visible = true;
        GD.Print("V");
        #endif
        GD.Print("C");
    }

    public override void _Pressed()
    {
        GD.Print("Q");
        #if DEBUG
        GD.Print("W");
        string g = HyperConnectinator3000.MurdersOfMurderers();
        GD.Print("E");
        OS.Clipboard = g;
        GD.Print("R");
        #endif
        GD.Print("T");
        Frambos.Notify("lmao", "lamo");
        GD.Print("Y");
    }
}

}