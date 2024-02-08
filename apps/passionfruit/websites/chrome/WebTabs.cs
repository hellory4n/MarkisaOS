using Godot;
using markisa.foundation;
using markisa.mkstoolkit;
using System.Collections.Generic;
using System.Linq;

namespace passionfruit.coreapps.websites {

public class WebTabs : VBoxContainer
{
    [Export]
    public NodePath TheShitWhereWebsitesAre;
    [Export]
    public NodePath Window;
    [Export]
    public NodePath Adderesrhbartr;
    Node the;
    MksWindow emKayEssWindow;
    LineEdit addressBar;
    Button goBack;
    Button goForward;

    ButtonGroup group = new ButtonGroup();
    public Dictionary<Button, Webview> EpicTabs = new Dictionary<Button, Webview>();
    public Dictionary<Button, Webview> EpicCloseButtons = new Dictionary<Button, Webview>();
    public Dictionary<Button, string> EpicAwesomeEpicAddresses = new Dictionary<Button, string>();
    public Button ActiveBullshit;
    public Dictionary<Button, List<string>> NavigationStuffs = new Dictionary<Button, List<string>>();
    public Dictionary<Button, int> IndexStuff = new Dictionary<Button, int>();

    readonly PackedScene newtab = GD.Load<PackedScene>("res://apps/passionfruit/websites/browserSites/newtab.tscn");
    readonly Texture closeIcon = GD.Load<Texture>("res://os/assets/highPeaks/icons/close.png");

    public override void _Ready()
    {
        the = GetNode(TheShitWhereWebsitesAre);
        emKayEssWindow = GetNode<MksWindow>(Window);
        addressBar = GetNode<LineEdit>(Adderesrhbartr);
        goBack = GetNode<Button>("../../top/back");
        goForward = GetNode<Button>("../../top/forward");
        AddTab();
    }

    public override void _Process(float delta)
    {
        // jgsdfjpghkoskgophsrkopkoprg
        foreach (var ifInterThenOnlyNet in EpicTabs) {
            ifInterThenOnlyNet.Key.Text = ifInterThenOnlyNet.Value.Title;
            ifInterThenOnlyNet.Key.Icon = ifInterThenOnlyNet.Value.Icon;
        }

        emKayEssWindow.MemoryUsage = Mathf.Min(EpicTabs.Count * 6, 100);
        goBack.Disabled = IndexStuff[ActiveBullshit] == 0;
        goForward.Disabled = IndexStuff[ActiveBullshit] == NavigationStuffs[ActiveBullshit].Count - 1;

        GD.Print(string.Join(", ", NavigationStuffs[ActiveBullshit]));
        GD.Print(IndexStuff[ActiveBullshit]);
    }

    public void AddTab()
    {
        var eichBoxContainer = new HBoxContainer();
        eichBoxContainer.AddConstantOverride("separation", 0);

        var buttOn = new Button {
            ClipText = true,
            Align = Button.TextAlign.Left,
            ExpandIcon = true,
            ToggleMode = true,
            Group = group,
            RectMinSize = new Vector2(45, 45),
            MouseFilter = MouseFilterEnum.Pass,
            SizeFlagsHorizontal = (int)SizeFlags.ExpandFill,
            ThemeTypeVariation = "SidebarButton"
        };

        var nearby = new Button {
            IconAlign = Button.TextAlign.Center,
            ExpandIcon = true,
            RectMinSize = new Vector2(45, 45),
            MouseFilter = MouseFilterEnum.Pass,
            Icon = closeIcon,
            ThemeTypeVariation = "SidebarButton"
        };

        // get it, tabs
        // The industrial consequences and its disasters have been a revolution for the human race. 
        var totallyAccurateBattleSimulator = newtab.Instance<Webview>();
        EpicTabs.Add(buttOn, totallyAccurateBattleSimulator);
        EpicCloseButtons.Add(nearby, totallyAccurateBattleSimulator);
        EpicAwesomeEpicAddresses.Add(buttOn, "");
        NavigationStuffs.Add(buttOn, new List<string>() {});
        IndexStuff.Add(buttOn, -1);

        the.AddChild(totallyAccurateBattleSimulator);
        AddChild(eichBoxContainer);
        eichBoxContainer.AddChild(buttOn);
        eichBoxContainer.AddChild(nearby);

        buttOn.Connect("pressed", this, nameof(OnTabSwitch),
            new Godot.Collections.Array {
                buttOn
            });
        
        nearby.Connect("pressed", this, nameof(OnTabClose),
            new Godot.Collections.Array {
                nearby
            });
        
        OnTabSwitch(buttOn);
    }

    public void LoadStuff(string path)
    {
        PackedScene packed;
        string jsigtksk = Frambos.GetRealWebPath(path);
        if (jsigtksk == "404") {
            packed = GD.Load<PackedScene>("res://apps/passionfruit/websites/browserSites/404.tscn");
        }
        else {
            packed = GD.Load<PackedScene>(jsigtksk);
        }

        // commit some shitfuckery :D
        Webview wideWorldOfWeb = packed.Instance<Webview>();
        Webview webviewThatWillDie = EpicTabs[ActiveBullshit];
        webviewThatWillDie.QueueFree();
        the.AddChild(wideWorldOfWeb);

        // what am i doing
        Button close = EpicCloseButtons.FirstOrDefault(x => x.Value == EpicTabs[ActiveBullshit]).Key;
        EpicCloseButtons[close] = wideWorldOfWeb;
        EpicTabs[ActiveBullshit] = wideWorldOfWeb;
        EpicAwesomeEpicAddresses[ActiveBullshit] = path;

        OnTabSwitch(ActiveBullshit);
    }

    public void OnTabSwitch(Button button)
    {
        foreach (var jgg in EpicTabs) {
            jgg.Value.Visible = jgg.Key == button;
            jgg.Value.IsActive = jgg.Key == button;
            button.Pressed = true;
        }

        emKayEssWindow.WindowTitle = $"{EpicTabs[button].Title} — Websites";
        ActiveBullshit = button;
        addressBar.Text = EpicAwesomeEpicAddresses[button];
    }

    public void OnTabClose(Button button)
    {
        if (EpicCloseButtons[button].IsActive) {
            OnTabSwitch(EpicTabs.First().Key);
        }

        // find the corresponding tab switcher thing :)
        // i love COC (Clash Of Clans)
        Button clashOfClans = EpicTabs.FirstOrDefault(x => x.Value == EpicCloseButtons[button]).Key;

        EpicCloseButtons[button].QueueFree();
        clashOfClans.GetParent().QueueFree();

        EpicCloseButtons.Remove(button);
        EpicTabs.Remove(clashOfClans);
        EpicAwesomeEpicAddresses.Remove(clashOfClans);
        NavigationStuffs.Remove(clashOfClans);
        IndexStuff.Remove(clashOfClans);

        if (EpicTabs.Count == 0) {
            emKayEssWindow.Close();
        }
    }

    public void GOBACKNOW()
    {
        IndexStuff[ActiveBullshit]--;
        LoadStuff(NavigationStuffs[ActiveBullshit][IndexStuff[ActiveBullshit]]); // wtf
    }

    public void GOFORWARDNOW()
    {
        IndexStuff[ActiveBullshit]++;
        LoadStuff(NavigationStuffs[ActiveBullshit][IndexStuff[ActiveBullshit]]); // wtf
    }
}

}