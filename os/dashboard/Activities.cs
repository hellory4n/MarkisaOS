using Godot;
using markisa.mkstoolkit;
using System;

namespace markisa.dashboard {

public class Activities : GridContainer
{
    ColorRect parentOfParent;

    public override void _Ready()
    {
        parentOfParent = GetParent().GetParent<ColorRect>();
    }

    public override void _Process(float delta)
    {
        // so the user doesn't get stuck in the activities forever cuz there's no window open
        if (GetChildCount() == 0) {
            parentOfParent.Visible = false;
        }
    }
}

}