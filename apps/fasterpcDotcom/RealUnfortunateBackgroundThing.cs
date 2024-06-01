using Godot;
using markisa.foundation;
using markisa.mkstoolkit;
using System;

namespace fasterpc.com {

public class RealUnfortunateBackgroundThing : Node
{
    public override void _Ready()
    {
        var timer = new Timer {
            WaitTime = 90,
            Autostart = true,
            OneShot = false
        };
        timer.Connect("timeout", this, nameof(Annoy));
        AddChild(timer);
    }

    public void Annoy()
    {
        var ad = new Button {
            RectMinSize = new Vector2(332, 249),
            AnchorLeft = 1,
            AnchorTop = 1,
            AnchorRight = 1,
            AnchorBottom = 1,
            MarginLeft = -348,
            MarginTop = -265,
            MarginBottom = -16,
            MarginRight = -16,
        };

        // figure out texture and link
        Texture texture;
        string link = "";
        switch (new Random().Next(1, 7)) {
            case 1:
                texture = GD.Load<Texture>("res://apps/fasterpcDotcom/ad1.png");
                link = "fasterpc.com/women.tscn";
                break;
            case 2:
                texture = GD.Load<Texture>("res://apps/fasterpcDotcom/ad2.png");
                link = "fasterpc.com/moneys.tscn";
                break;
            case 3:
                texture = GD.Load<Texture>("res://apps/fasterpcDotcom/ad3.png");
                link = "fasterpc.com/dontgetarrested.tscn";
                break;
            case 4:
                texture = GD.Load<Texture>("res://apps/fasterpcDotcom/ad4.png");
                link = "fasterpc.com/pcslow.tscn";
                break;
            case 5:
                texture = GD.Load<Texture>("res://apps/fasterpcDotcom/ad5.png");
                link = "sphericol.com";
                break;
            case 6:
                texture = GD.Load<Texture>("res://apps/fasterpcDotcom/ad6.png");
                link = "fasterpc.com/upgrademks.tscn";
                break;
            default: texture = new ImageTexture(); break;
        }

        var stylebox = new StyleBoxTexture {
            Texture = texture,
        };
        ad.AddStyleboxOverride("normal", stylebox);
        ad.AddStyleboxOverride("hover", stylebox);
        ad.AddStyleboxOverride("pressed", stylebox);
        ad.AddStyleboxOverride("focus", stylebox);

        // add it and do the cool animation
        GetNode("/root/dashboard").AddChild(ad);
        var tween = CreateTween();
        ad.Modulate = Colors.Transparent;
        tween.TweenProperty(ad, "modulate", Colors.White, 0.5f)
            .SetEase(Tween.EaseType.Out)
            .SetTrans(Tween.TransitionType.Cubic);
        
        // TODO: play annoying sound
        Frambos.Play(SystemSound.Notification);

        ad.Connect("pressed", this, nameof(AnnoyMore), new Godot.Collections.Array { link, ad });
    }

    public void AnnoyMore(string link, Node FUCKYOU)
    {
        var help = GD.Load<PackedScene>("res://apps/fasterpcDotcom/suspicious.tscn");
        GetNode("/root/dashboard/windows").AddChild(help.Instance<MksWindow>());
        OS.Clipboard = link;
        FUCKYOU.QueueFree();
    }
}

}