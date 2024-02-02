using Godot;
using System;

namespace markisa.dashboard {

public class Clear : Button
{
    public override void _Pressed()
    {
        GetNode<LineEdit>("../../expression").Clear();
    }
}

}