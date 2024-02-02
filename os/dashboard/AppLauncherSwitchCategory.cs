using Godot;
using System;

namespace markisa.dashboard {

public class AppLauncherSwitchCategory : Button
{
    [Export(PropertyHint.NodePathValidTypes, "ScrollContainer")]
    public NodePath EpicCategory;

    public override void _Pressed()
    {
        ScrollContainer jJFJgjkfg = GetNode<ScrollContainer>(EpicCategory);
        foreach (Control child in GetParent().GetParent().GetChildren()) {
            if (child is ScrollContainer) {
                child.Visible = child == jJFJgjkfg;
            }
        }
    }
}

}