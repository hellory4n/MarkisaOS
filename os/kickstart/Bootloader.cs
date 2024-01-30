using Godot;
using System;
using markisa.foundation;

namespace markisa.kickstart
{
public class Bootloader : Node
{
    [Export]
    public PackedScene hehe;
    [Export(PropertyHint.NodePathValidTypes, "TextureRect")]
    public NodePath textureRectangle;
    TextureRect tjtjt;

    public override void _Ready()
    {
        // don't make everything ginormous on desktop
        // there's an option to do that from the project settings but it means
        // i don't get to see how it would look on mobile, so i prefer this
        if (!Frambos.IsOnMobile) {
            GetTree().SetScreenStretch(
                SceneTree.StretchMode.Mode2d, SceneTree.StretchAspect.Keep, OS.GetScreenSize());
            Frambos.Resolution = OS.GetScreenSize();
        }
        else {
            Frambos.Resolution = OS.WindowSize;
        }

        tjtjt = GetNode<TextureRect>(textureRectangle);
        tjtjt.RectPivotOffset = tjtjt.RectSize / 2;

        // seeing your cursor while the computer is booting is quite uncommon
        Input.WarpMousePosition(Vector2.Zero);
        Input.MouseMode = Input.MouseModeEnum.ConfinedHidden;
    }

    public override void _Process(float delta)
    {
        if (Input.IsActionJustReleased("skipBoot")) {
            loadThing();
        }
    }

    public void loadThing()
    {
        var lol = hehe.Instance<Control>();
        GetTree().Root.AddChild(lol);
        GetParent().QueueFree();

        // bring back the cursor
        Input.WarpMousePosition(tjtjt.RectSize / 2);
        Input.MouseMode = Input.MouseModeEnum.Visible;
    }
}

}