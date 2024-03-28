using Godot;
using markisa.foundation;
using System;

namespace markisa.dashboard {

public class Dashboard : Control
{
    public override void _Ready()
    {
        Frambos.Play(SystemSound.Startup);

        // mobile mode :)
        if (Frambos.IsOnMobile) {
            GetNode<Control>("interface/panel").Visible = false;
            GetNode<Control>("interface/dock").Visible = false;
            GetNode<Control>("interface/mobileui").Visible = true;
            GetNode<Control>("mobileTimeMoney").Visible = true;
        }
        else {
            GetNode<Control>("interface/panel").Visible = true;
            GetNode<Control>("interface/dock").Visible = true;
            GetNode<Control>("interface/mobileui").Visible = false;
            GetNode<Control>("mobileTimeMoney").Visible = false;
        }

        // load the fucking settings
        var config = new Config<DashboardConfig>();
        GetNode<TextureRect>("wallpaper").Texture = GD.Load<Texture>(config.Data.Wallpaper);
    }
}

}