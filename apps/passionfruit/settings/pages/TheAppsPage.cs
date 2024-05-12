using Godot;
using markisa.foundation;
using System;
using System.Linq;

namespace passionfruit.coreapps.settings {

public class TheAppsPage : ItemList
{
    MksPackage[] packages;
    // we do the new() thing so it doesn't crash with the the the the the the the the the the the the the the the the the the the the
    MksPackage selected = new MksPackage();

    public override void _Ready()
    {
        Refresh();
    }

    public void Refresh()
    {
        GD.Print("$");
        var config = new Config<AppStuff>();
        packages = config.Data.InstalledApps;
        foreach (var g in config.Data.InstalledApps) {
            AddItem(Tr(g.DisplayName), GD.Load<Texture>(g.Icon));
        }
    }

    public void OnItemSelected(int idx)
    {
        selected = packages[idx];
    }

    public void ImOnHellOnEarthInTermsOfClimate()
    {
        GD.Print("hehe");
        var config = new Config<AppStuff>();
        var J = config.Data.InstalledApps.ToList();
        GD.Print(selected.DisplayName, " by ", selected.Author);
        J.RemoveAll(x => x.DisplayName == selected.DisplayName && x.Author == selected.Author);
        config.Data.InstalledApps = J.ToArray();
        config.Save();

        Clear();
        Refresh();
    }
}

}