using Godot;
using markisa.foundation;
using System;

namespace markisa.dashboard {

public class UserDisplayBullshit : Button
{
    public override void _Ready()
    {
        Text = Frambos.CurrentUserDisplayName;
        HintTooltip = Frambos.CurrentUser;
        var m = new Config<MarkisaUser>();
        Icon = GD.Load<Texture>(m.Data.Photo);
    }
}

}