using Godot;
using System;

public class BiosStuffThings : Button
{
    bool nuhUh = false;
    public override void _Pressed()
    {
        GetTree().Root.AddChild(GD.Load<PackedScene>("res://os/kickstart/bootscreen.tscn").Instance());
        GetParent().QueueFree();
    }

    public override void _Input(InputEvent @event)
    {
        if (@event is InputEventKey && !nuhUh) {
            GetTree().Root.AddChild(GD.Load<PackedScene>("res://os/kickstart/bootscreen.tscn").Instance());
            GetParent().QueueFree();
            nuhUh = true;
        }
    }
}
