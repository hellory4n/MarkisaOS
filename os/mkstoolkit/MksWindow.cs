using Godot;
using markisa.foundation;
using markisa.internalstuff;
using System;

namespace markisa.mkstoolkit {

[Tool]
public class MksWindow : Control
{
    /// <summary>
    /// The title of the window.
    /// </summary>
    [Export]
    public string WindowTitle { get; set; } = "";
    /// <summary>
    /// The icon that will be shown in the dock, recommended resolution of 40x40
    /// </summary>
    [Export]
    public Texture DockIcon { get; set; }
    /// <summary>
    /// The smaller icon, recommended resolution of 28x28
    /// </summary>
    [Export]
    public Texture SmallIcon { get; set; }
    /// <summary>
    /// If true, the window will be floating and draggable. Else, it will be maximized. This is always set to false on mobile :)
    /// </summary>
    [Export]
    public bool Floating { get; set; }
    /// <summary>
    /// How much % of the screen the window will be.
    /// </summary>
    [Export]
    public Vector2 SizePercentage { get; set; } = new Vector2(40, 40);
    /// <summary>
    /// How much totally real memory this app will use. This will affect computer noises
    /// </summary>
    [Export(PropertyHint.Range, "1,100")]
    public int MemoryUsage { get; set; } = 1;
    /// <summary>
    /// How much this app will read and write. This will affect computer noises
    /// </summary>
    [Export(PropertyHint.Range, "1,100")]
    public int DiskUsage { get; set; } = 1;
    /// <summary>
    /// The root of all content in this window.
    /// </summary>
    [Export(PropertyHint.NodePathValidTypes, "Control")]
    public NodePath ContentRoot { get; set; }
    /// <summary>
    /// Yes
    /// </summary>
    public Control RealContentRoot { get; set; }

    StyleBox backgroundStyle;
    StyleBox titleStyle;
    Panel bg;
    Panel title;
    DraggableTitle draggableTitle;
    Label titleName;
    Button iconDisplay;
    Button closeButton;
    Button dockButton;
    double timeStuff;

    public override void _Ready()
    {
        // every window must be maximized on android, whether the windows like it or not (help)
        if (Frambos.IsOnMobile) {
            Floating = false;
            SizePercentage = new Vector2(100, 100);
        }

        // make the internal bullshit
        bg = new Panel {
            AnchorRight = 1,
            AnchorBottom = 1,
        };

        title = new Panel {
            AnchorRight = 1,
            RectPosition = new Vector2(0, -45),
            RectMinSize = new Vector2(45, 45),
            MouseFilter = MouseFilterEnum.Ignore
        };

        if (Floating && !Engine.EditorHint) {
            draggableTitle = new DraggableTitle{
                window = this,
                Position = new Vector2(0, -45)
            };
            AddChild(draggableTitle);
        }

        titleName = new Label {
            AnchorRight = 1,
            AnchorBottom = 1,
            Align = Label.AlignEnum.Center,
            Valign = Label.VAlign.Center,
            ClipText = true
        };

        closeButton = new Button {
            RectMinSize = new Vector2(45, 45),
            Flat = true,
            IconAlign = Button.TextAlign.Center,
            AnchorLeft = 1,
            AnchorRight = 1,
            AnchorBottom = 1,
            MarginLeft = -45,
            MarginRight = -45
        };

        closeButton.AddStyleboxOverride("focus", new StyleBoxEmpty());
        closeButton.Connect("pressed", this, nameof(Close));

        iconDisplay = new Button {
            RectMinSize = new Vector2(45, 45),
            Flat = true,
            IconAlign = Button.TextAlign.Center,
            ExpandIcon = true,
            MouseFilter = MouseFilterEnum.Ignore
        };

        AddChild(bg);
        AddChild(title);
        title.AddChild(titleName);
        title.AddChild(closeButton);
        title.AddChild(iconDisplay);

        if (!Engine.EditorHint) {
            // make sure the size is right
            RectSize = (Frambos.Resolution * (SizePercentage / 100)) - new Vector2(64, 85);

            // go to the center of the screen
            if (Floating) {
                Vector2 coolSize = RectSize + new Vector2(64, 45);
                RectPosition = (Frambos.Resolution + new Vector2(64, 40)) / 2 - (coolSize / 2);
            }
            else {
                if (Frambos.IsOnMobile) {
                    RectPosition = new Vector2(64, 85);
                }
                else {
                    RectPosition = new Vector2(64, 0);
                }
            }
        }

        // show up in the dock
        if (!Engine.EditorHint) {
            Node haha = GetNode("/root/dashboard/interface/dock/stuff/apps");
            dockButton = new Button {
                Icon = DockIcon,
                ThemeTypeVariation = "OSButton",
                IconAlign = Button.TextAlign.Center,
                RectMinSize = new Vector2(64, 64)
            };
            haha.AddChild(dockButton);
            dockButton.Connect("pressed", this, nameof(OtherDumbFunctionThatCallsASingleOtherFunction));
        }

        // do the awesome window opening animation
        if (!Engine.EditorHint) {
            RectScale = Vector2.Zero;
            Modulate = Colors.Transparent;

            SceneTreeTween tween = CreateTween();
            tween.SetParallel(true);
            tween.TweenProperty(this, "rect_scale", Vector2.One, 0.2f)
                .SetTrans(Tween.TransitionType.Cubic)
                .SetEase(Tween.EaseType.Out);
            
            tween.TweenProperty(this, "modulate", Colors.White, 0.2f)
                .SetTrans(Tween.TransitionType.Expo)
                .SetEase(Tween.EaseType.Out);
        }
        
        RealContentRoot = GetNode<Control>(ContentRoot);
    }

    public override void _Process(float delta)
    {
        timeStuff += delta;
        if (timeStuff > 0.02) {
            OnThemeChanged();
        }

        if (Floating && !Engine.EditorHint) {
            draggableTitle.tsize = new Vector2(RectSize.x, 45);
        }

        // show a preview of the size and shit
        if (Engine.EditorHint) {
            // we show a preview of what it would be on desktop unless it's not floating,
            // since everything is maximized on mobile
            // this is confusing
            if (Floating) {
                RectSize = (new Vector2(1280, 720) * SizePercentage / 100) - new Vector2(64, 85);
            }
            else {
                RectSize = (new Vector2(853, 480) * SizePercentage / 100) - new Vector2(64, 85);
            }
        }

        // sync the window title icon stuff
        titleName.Text = WindowTitle;
        iconDisplay.Icon = SmallIcon;

        RealContentRoot.Raise();
    }

    // TODO: call this function when i add theming
    void OnThemeChanged()
    {
        backgroundStyle = GetStylebox("background", "MksWindow");
        titleStyle = GetStylebox("titleBackground", "MksWindow");

        if (bg != null && title != null) {
            bg.AddStyleboxOverride("panel", backgroundStyle);
            title.AddStyleboxOverride("panel", titleStyle);
            closeButton.Icon = GetIcon("close", "MksWindow");
        }
    }

    public void Close()
    {
        SceneTreeTween tween = CreateTween();
        tween.SetParallel(true);
        tween.TweenProperty(this, "rect_scale", Vector2.Zero, 0.3f)
            .SetTrans(Tween.TransitionType.Expo)
            .SetEase(Tween.EaseType.Out)
            .Connect("finished", this, nameof(DumbFunctionThatCallsASingleOtherFunctionBecauseGodot3DoesntLetMeUseLambdas));
        
        tween.TweenProperty(this, "modulate", Colors.Transparent, 0.3f)
            .SetTrans(Tween.TransitionType.Cubic)
            .SetEase(Tween.EaseType.Out);
        
        dockButton?.QueueFree();
    }

    void DumbFunctionThatCallsASingleOtherFunctionBecauseGodot3DoesntLetMeUseLambdas() => QueueFree();
    void OtherDumbFunctionThatCallsASingleOtherFunction() => Raise();
}

}