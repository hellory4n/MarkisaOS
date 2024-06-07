using Godot;
using markisa.foundation;
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
    readonly SystemSound[] randomshit2 = new SystemSound[] {
        SystemSound.Startup,
        SystemSound.Shutdown,
        SystemSound.Confirm,
        SystemSound.Error,
        SystemSound.Notification,
    };
    readonly Random rng = new Random();
    MksWindow handsomeWindow;
    readonly CanvasLayer eyestrain = new CanvasLayer {
        Layer = 128
    };
    double tunnelScale = 1;

    public override void _Ready()
    {
        handsomeWindow = GetParent().GetParent<MksWindow>();

        // the window that isn't actually the app thing, it's a window dedicating to wishing
        // people a nice day
        // quite the mouthful
        GetNode("/root/dashboard/windows").AddChild(GD.Load<PackedScene>("res://apps/destroyermpkg/funniMessage.tscn").Instance<MksWindow>());

        // yeah
        Input.SetCustomMouseCursor(GD.Load<Texture>("res://os/assets/highPeaks/colorIcons/smallMarkisa.png"), Input.CursorShape.Arrow);
    }

    public override void _Process(float delta)
    {
        // we become invisible so the user can't press the close button and this class keep running :D
        handsomeWindow.Modulate = Colors.Transparent;
        handsomeWindow.RectPosition = new Vector2(99999, 99999);
        handsomeWindow.RectScale = new Vector2(0, 0);
    }

    public void StartPart1() => GetNode<Timer>("part1Loop").Start();
    public void StartPart3() => GetNode<Timer>("part3Loop").Start();

    // in part 1, we start by opening random shit
    public void Part1Loop()
    {
        string shit = randomshit[rng.Next(0, randomshit.Length)];
        // quite the mouthful
        GetNode("/root/dashboard/windows").AddChild(GD.Load<PackedScene>(shit).Instance<MksWindow>());
    }

    // in part 2, we get more machiavellian
    // now there's a shader inverting the colors of the whole screen
    // but if reduced motion is enabled we only spam notifications
    public void StartPart2()
    {
        GetNode<Timer>("part2Loop").Start();

        var config = new Config<ReducedMotion>();
        if (config.Data.Enabled) {
            return;
        }

        GetTree().Root.AddChild(eyestrain);
        // quite the mouthful
        eyestrain.AddChild(GD.Load<PackedScene>("res://apps/destroyermpkg/invertThing.tscn").Instance<Control>());
    }

    public void Part2Loop() => Frambos.Notify("You are an idiot!", "Hahahaha!"); 

    // in part 3 we officially go FUCK YOU and do that tunnel effect from recording programs (pretty unusable)
    // but if reduced motion is enabled we only play random sounds
    public void Part3Loop()
    {
        tunnelScale -= 0.1;

        Frambos.Play(randomshit2[rng.Next(0, randomshit2.Length)]);

        // aight we're dead
        if (tunnelScale < 0.25) {
            eyestrain.QueueFree();
            Frambos.KernelPanic();
        }

        var config = new Config<ReducedMotion>();
        if (config.Data.Enabled) {
            return;
        }

        eyestrain.AddChild(new TextureRect {
            Expand = true,
            Texture = GetViewport().GetTexture(),
            FlipV = true,
            RectPivotOffset = Frambos.Resolution / 2,
            RectMinSize = Frambos.Resolution,
            RectScale = new Vector2((float)tunnelScale, (float)tunnelScale),
            MouseFilter = Control.MouseFilterEnum.Ignore,
        });
    }
}

}