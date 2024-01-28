using Godot;
using System;

public class A : Sprite {
    public override void _Process(float delta) {
        base._Process(delta);
        Scale += new Vector2(0.1f, 0.1f);
    }
}
