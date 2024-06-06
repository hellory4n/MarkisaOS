using Godot;
using System;

public class BiosStuffThings : Control
{
    public override void _Input(InputEvent @event)
    {
        if (@event is InputEventKey) {
            GetTree().Root.AddChild(GD.Load<PackedScene>("res://os/kickstart/bootscreen.tscn").Instance());
            GetParent().QueueFree();
        }

        if (@event is InputEventMouseButton) {
            GetTree().Root.AddChild(GD.Load<PackedScene>("res://os/kickstart/bootscreen.tscn").Instance());
            GetParent().QueueFree();
        }
    }
}
