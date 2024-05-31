using Godot;
using System;

namespace fasterpc.com {

public class UnfortunateBackgroundThing : Node
{
    public override void _Ready()
    {
        var lol = new RealUnfortunateBackgroundThing();
        GetTree().Root.AddChild(lol);
    }
}

}