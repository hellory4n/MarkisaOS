using Godot;
using markisa.mkstoolkit;
using System;

namespace markisa.dashboard {

public class MarkisaButton : Button
{
    PackedScene lol = GD.Load<PackedScene>("res://apps/passionfruit/settings/app.tscn");

    public override void _Pressed()
    {
        var epicWindow = lol.Instance<MksWindow>();
        Node windows = GetNode("/root/dashboard/windows");

        // make the system page show up :)
        epicWindow.GetNode<Control>("contents/hSplitContainer/control/system").Visible = true;
        epicWindow.GetNode<Control>("contents/hSplitContainer/control/home").Visible = false;

        windows.AddChild(epicWindow);
    }
}

}