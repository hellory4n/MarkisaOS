using Godot;
using System;

namespace markisa.mkstoolkit {

[Tool]
public class MksPopup : Panel
{
    public override void _Ready()
    {
        ThemeTypeVariation = "MksPopup";

        if (!Engine.EditorHint) {
            Modulate = Colors.Transparent;
            Visible = false;
            RectPosition = new Vector2(RectPosition.x, -RectSize.y);
        }
    }

    public void ShowPopup()
    {
        Visible = true;
        SceneTreeTween tween = CreateTween();
        tween.SetParallel(true);
        tween.TweenProperty(this, "rect_position", new Vector2(RectPosition.x, 0), 0.2f)
            .SetTrans(Tween.TransitionType.Cubic)
            .SetEase(Tween.EaseType.Out);
        
        tween.TweenProperty(this, "modulate", Colors.White, 0.2f)
            .SetTrans(Tween.TransitionType.Expo)
            .SetEase(Tween.EaseType.Out);
    }

    public void HidePopup()
    {
        SceneTreeTween tween = CreateTween();
        tween.SetParallel(true);
        tween.TweenProperty(this, "rect_position", new Vector2(RectPosition.x, -RectSize.y), 0.3f)
            .SetTrans(Tween.TransitionType.Expo)
            .SetEase(Tween.EaseType.Out);
        
        tween.TweenProperty(this, "modulate", Colors.Transparent, 0.3f)
            .SetTrans(Tween.TransitionType.Cubic)
            .SetEase(Tween.EaseType.Out);
    }
}

}