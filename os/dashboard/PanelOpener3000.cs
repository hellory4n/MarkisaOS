using Godot;
using markisa.foundation;
using System;

namespace markisa.dashboard {

public class PanelOpener3000 : Button
{
    [Export(PropertyHint.NodePathValidTypes, "Panel")]
    public NodePath Panel;
    [Export(PropertyHint.Enum, "App launcher,Quick settings,Notifications,Sticky notes")]
    public int Type;
    Panel epicPanel;
    Vector2 from;
    Vector2 to;

    public override void _Ready()
    {
        epicPanel = GetNode<Panel>(Panel);
        switch (Type) {
            case 0: // app launcher
                from = new Vector2(-400, Frambos.Resolution.y - 300);
                to = new Vector2(64, Frambos.Resolution.y - 300);
                break;
            case 1: // quick settings
                from = new Vector2(Frambos.Resolution.x - 300, -300);
                to = new Vector2(Frambos.Resolution.x - 300, 40);
                break;
            case 2: // notifications
                from = new Vector2(Frambos.Resolution.x - 350, -400);
                to = new Vector2(Frambos.Resolution.x - 350, 40);
                break;
            case 3: // sticky notes
                from = new Vector2(64, -400);
                to = new Vector2(64, 40);
                break;
        }
    }

    public override void _Toggled(bool buttonPressed)
    {
        SceneTreeTween tween = CreateTween();
        tween.SetParallel(true);

        if (buttonPressed) {
            epicPanel.RectPosition = from;
            epicPanel.Modulate = Colors.Transparent;

            tween.TweenProperty(epicPanel, "rect_position", to, 0.2f)
                .SetTrans(Tween.TransitionType.Expo)
                .SetEase(Tween.EaseType.Out);
            
            tween.TweenProperty(epicPanel, "modulate", Colors.White, 0.2f)
                .SetTrans(Tween.TransitionType.Cubic)
                .SetEase(Tween.EaseType.Out);
        }
        else {
            tween.TweenProperty(epicPanel, "rect_position", from, 0.4f)
                .SetTrans(Tween.TransitionType.Cubic)
                .SetEase(Tween.EaseType.Out);
            
            tween.TweenProperty(epicPanel, "modulate", Colors.Transparent, 0.4f)
                .SetTrans(Tween.TransitionType.Expo)
                .SetEase(Tween.EaseType.Out);
        }
    }
}

}