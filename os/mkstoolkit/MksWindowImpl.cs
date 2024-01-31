using Godot;
using System;

namespace markisa.mkstoolkit {

/// <summary>
/// Due to godot 3 limitations, i have to make a GDScript script to make things show up in the "add node" dialog, and I really wouldn't like to code this much garbage in GDScript
/// </summary>
public class MksWindowImpl : Node
{
    Control parent;

    public override void _Ready()
    {
        GD.Print("lol");
        parent = GetParent<Control>();
        GD.Print(parent.RectPosition);
    }

    public override string _GetConfigurationWarning()
    {
        return base._GetConfigurationWarning();
    }
}

}