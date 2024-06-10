using Godot;
using markisa.foundation;
using System;
using System.Linq;

namespace markisa.dashboard {

public class AppLauncher : HFlowContainer
{
    MksPackage[] packages = {};
    MksPackage[] defaultApps = {};
    int appCount = 0;
    int defaultAppCount = 0;

    public void LoadStuffLmao()
    {
        appCount = 0;

        foreach (Node node in GetChildren().Cast<Node>()) {
            node.QueueFree();
        }

        var config = new Config<AppStuff>();
        packages = config.Data.InstalledApps;
        var plfhfhfs = defaultApps.Concat(config.Data.InstalledApps).ToArray();

        foreach (MksPackage pkg in plfhfhfs) {
            AddItem(pkg.DisplayName, GD.Load<Texture>(pkg.Icon));
        }
    }

    public override void _Ready()
    {
        AddItem("Websites", GD.Load<Texture>("res://apps/passionfruit/websites/dockicon.png"));
        AddItem("Downloads", GD.Load<Texture>("res://apps/passionfruit/files/dockicon.png"));
        AddItem("Email", GD.Load<Texture>("res://apps/passionfruit/email/dockicon.png"));
        AddItem("Connect", GD.Load<Texture>("res://apps/passionfruit/connect/dockicon.png"));
        AddItem("Marketplace", GD.Load<Texture>("res://apps/passionfruit/marketplace/dockicon.png"));
        AddItem("Settings", GD.Load<Texture>("res://apps/passionfruit/settings/dockicon.png"));
        AddItem("Bank", GD.Load<Texture>("res://apps/passionfruit/bank/dockicon.png"));
        AddItem("BetaTools", GD.Load<Texture>("res://os/assets/highPeaks/colorIcons/bigMarkisa.png"));
        defaultAppCount = GetChildCount();

        // save the default stuff so we can automatically refresh
        for (int i = 0; i < defaultAppCount; i++) {
            var jghrfgj = new MksPackage {
                DisplayName = GetChildren().Cast<Button>().ToArray()[i].Text,
                Icon = GetChildren().Cast<Button>().ToArray()[i].Icon.ResourcePath
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
                GD.Print(idx, "; ", defaultAppCount, "; ", idx - defaultAppCount);

                // the custom apps are added right afterwards
                MksPackage pkg = packages[idx - defaultAppCount];
                j = pkg.Executable;
                break;
        }

        var jgd = GD.Load<PackedScene>(j);
        GetNode("/root/dashboard/windows").AddChild(jgd.Instance());
    }

    public Button AddItem(string name, Texture icon)
    {
        var button = new Button {
            Text = Tr(name),
            Icon = icon,
            ExpandIcon = true,
            RectMinSize = new Vector2(175, 45),
            MouseFilter = MouseFilterEnum.Pass,
            ThemeTypeVariation = "OSButton",
            SizeFlagsHorizontal = (int)SizeFlags.ExpandFill,
            ClipText = true,
            Align = Button.TextAlign.Left
        };
        AddChild(button);
        button.Connect("pressed", this, nameof(OnItemSelected), new Godot.Collections.Array { appCount });
        appCount++;
        return button;
    }
}

}