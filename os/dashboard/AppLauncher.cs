using Godot;
using markisa.foundation;
using System;
using System.Linq;

namespace markisa.dashboard {

public class AppLauncher : ItemList
{
    MksPackage[] packages = {};
    MksPackage[] defaultApps = {};
    int defaultAppCount;

    public void LoadStuffLmao()
    {
        Clear();

        var config = new Config<AppStuff>();
        var plfhfhfs = defaultApps.Concat(config.Data.InstalledApps).ToArray();

        foreach (MksPackage pkg in plfhfhfs) {
            AddItem(Tr(pkg.DisplayName), GD.Load<Texture>(pkg.Icon));
        }
    }

    public override void _Ready()
    {
        SetItemText(0, Tr("Websites"));
        SetItemText(1, Tr("Downloads"));
        SetItemText(2, Tr("Email"));
        SetItemText(3, Tr("Connect"));
        SetItemText(4, Tr("Marketplace"));
        SetItemText(5, Tr("Settings"));
        SetItemText(6, Tr("Bank"));
        SetItemText(7, Tr("BetaTools"));
        defaultAppCount = GetItemCount();

        // save the default stuff so we can automatically refresh
        for (int i = 0; i < defaultAppCount; i++) {
            var jghrfgj = new MksPackage {
                DisplayName = GetItemText(i),
                Icon = GetItemIcon(i).ResourcePath
            };
            defaultApps = defaultApps.Append(jghrfgj).ToArray();
        }

        LoadStuffLmao();
    }

    public void OnItemSelected(int idx)
    {
        string j;
        switch (idx) {
            case 0: j = "res://apps/passionfruit/websites/app.tscn"; break;
            case 1: j = "res://apps/passionfruit/files/app.tscn"; break;
            case 2: j = "res://apps/passionfruit/email/app.tscn"; break;
            case 3: j = "res://apps/passionfruit/connect/app.tscn"; break;
            case 4: j = "res://apps/passionfruit/marketplace/app.tscn"; break;
            case 5: j = "res://apps/passionfruit/settings/app.tscn"; break;
            case 6: j = "res://apps/passionfruit/bank/app.tscn"; break;
            case 7: j = "res://apps/passionfruit/betatools/app.tscn"; break;

            // so this isn't a default app
            default:
                // the custom apps are added right afterwards
                MksPackage pkg = packages[idx - defaultAppCount];
                j = pkg.Executable;
                GD.Print("name", pkg.DisplayName);
                break;
        }

        var jgd = GD.Load<PackedScene>(j);
        GetNode("/root/dashboard/windows").AddChild(jgd.Instance());
    }
}

}