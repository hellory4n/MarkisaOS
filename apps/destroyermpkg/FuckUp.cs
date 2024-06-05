using Godot;
using markisa.mkstoolkit;
using System;

namespace destroyer.mpkg {

public class FuckUp : Node
{
    readonly string[] randomshit = new string[] {
        "res://apps/passionfruit/bank/app.tscn",
        "res://apps/passionfruit/connect/app.tscn",
        "res://apps/passionfruit/email/app.tscn",
        "res://apps/passionfruit/files/app.tscn",
        "res://apps/passionfruit/marketplace/app.tscn",
        "res://apps/passionfruit/settings/app.tscn",
        "res://apps/passionfruit/websites/app.tscn",
    };
    readonly Random rng = new Random();

    public override void _Ready()
    {
        // we become invisible so the user can't press the close button and this class keep running :D
        GetParent().GetParent<MksWindow>().Modulate = Colors.Transparent;
        GetParent().GetParent<MksWindow>().RectPosition = new Vector2(99999, 99999);

        // the window that isn't actually the app thing, it's a window dedicating to wishing
        // people a nice day
        // quite the mouthful
        GetNode("/root/dashboard/windows").AddChild(GD.Load<PackedScene>("res://apps/destroyermpkg/funniMessage.tscn").Instance<MksWindow>());
    }

    public void StartPart1() => GetNode<Timer>("part1Loop").Start();

    // in part 1, we start by opening random shit
    public void Part1Loop()
    {
        string shit = randomshit[rng.Next(0, randomshit.Length)];
        // quite the mouthful
        GetNode("/root/dashboard/windows").AddChild(GD.Load<PackedScene>(shit).Instance<MksWindow>());
    }
}

}