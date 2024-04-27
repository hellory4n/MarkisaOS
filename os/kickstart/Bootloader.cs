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
		tjtjt = GetNode<TextureRect>(textureRectangle);
		tjtjt.RectPivotOffset = Frambos.Resolution / 2;

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
