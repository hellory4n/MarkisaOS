using Godot;
using markisa.mkstoolkit;
using System;

namespace markisa.internalstuff {

public class DraggableTitle : Node2D
{
    // don't ask what this does, i stole this from https://gist.github.com/angstyloop/08200c6d816347c82ea1aed56c219f17
    // and deleted all of the comments since they were pretty ridiculous
    public MksWindow window;
    static MksWindow activeWindow;
    string status = "none";
    public Vector2 tsize;
    Vector2 mpos;
    Vector2 offset;

    public override void _Process(float delta)
    {
        if (status == "dragging") {
            window.RectGlobalPosition = mpos + offset + new Vector2(0, 45);
        }
        Update();
    }

    public override void _Input(InputEvent ev)
    {
        if (ev is InputEventMouseButton eve) {
            if (status != "dragging" && ev.IsPressed()) {
                Vector2 evpos = eve.GlobalPosition;
                Vector2 gpos = GlobalPosition;

                Rect2 rect = new Rect2(Position, tsize);
                if (rect.HasPoint(evpos)) {
                    window.Raise();
                    status = "clicked";
                    offset = gpos - evpos;
                    activeWindow = window;
                }
            }
            else if (status == "dragging" && !ev.IsPressed()) {
                status = "released";
                activeWindow = null;
            }
        }

        if (status == "clicked" && activeWindow == window && ev is InputEventMouseMotion) {
            status = "dragging";
        }

        mpos = GetGlobalMousePosition();
    }

    public override void _Draw()
    {
        DrawRect(new Rect2(Position, tsize), Colors.Red);
    }
}

}