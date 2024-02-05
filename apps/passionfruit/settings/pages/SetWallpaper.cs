using Godot;
using markisa.foundation;
using System;

namespace passionfruit.coreapps.settings {

public class SetWallpaper : ItemList
{
    public void Fuck(int index)
    {
        Texture epicWallpaper = GetItemIcon(index);
        GetNode<TextureRect>("/root/dashboard/wallpaper").Texture = epicWallpaper;

        // now we save the bullshit
        var config = new Config<DashboardConfig>();
        config.Data.Wallpaper = epicWallpaper.ResourcePath;
        config.Save();
    }
}

}