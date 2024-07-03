using Godot;
using markisa.foundation;
using markisa.network;
using System;

namespace passionfruit.coreapps.connect {

public class BluckBluckBluckBaBluckBluckBlucka : Button
{
    public override void _Ready()
    {
        Visible = false;
        #if DEBUG
        Visible = true;
        #endif
    }

    public override void _Pressed()
    {
        #if DEBUG
        string g = HyperConnectinator3000.MurdersOfMurderers();
        OS.Clipboard = g;
        #endif
        Frambos.Notify("lmao", "lamo");
    }
}

}