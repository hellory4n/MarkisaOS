using Godot;
using System;

namespace markisa.dashboard {

public class AppLauncher : ItemList
{
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
            default: j = "res://apps/passionfruit/test/app.tscn"; break;
        }

        var jgd = GD.Load<PackedScene>(j);
        GetNode("/root/dashboard/windows").AddChild(jgd.Instance());
    }
}

}