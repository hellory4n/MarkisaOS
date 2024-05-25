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

    ButtonGroup group = new ButtonGroup();
    public Dictionary<Button, Webview> EpicTabs = new Dictionary<Button, Webview>();
    public Dictionary<Button, Webview> EpicCloseButtons = new Dictionary<Button, Webview>();
    public Dictionary<Button, string> EpicAwesomeEpicAddresses = new Dictionary<Button, string>();
    public Button ActiveBullshit;

    readonly PackedScene newtab = GD.Load<PackedScene>("res://apps/passionfruit/websites/browserSites/newtab.tscn");
    readonly Texture closeIcon = GD.Load<Texture>("res://os/assets/highPeaks/icons/close.png");

    public override void _Ready()
    {
        the = GetNode(TheShitWhereWebsitesAre);
        emKayEssWindow = GetNode<MksWindow>(Window);
        addressBar = GetNode<LineEdit>(Adderesrhbartr);
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

    public void LoadStuff(string address)
    {
        PackedScene packed;
        string jsigtksk = Frambos.GetRealWebPath(address.Replace(" ", ""));
        if (jsigtksk == "404") {
            // if it ends with .com, .net, or .org, the user probably tried to type an address
            if (address.EndsWith(".com") || address.EndsWith(".net") || address.EndsWith(".org")) {
                packed = GD.Load<PackedScene>("res://apps/passionfruit/websites/browserSites/404.tscn");
            }
            // search stuff
            else {
                packed = GD.Load<PackedScene>("res://apps/passionfruit/websites/browserSites/search.tscn");
            }
        }
        else {
            packed = GD.Load<PackedScene>(jsigtksk);
        }

        // commit some shitfuckery :D
        Webview wideWorldOfWeb = packed.Instance<Webview>();
        wideWorldOfWeb.AnchorRight = 1;
        wideWorldOfWeb.AnchorBottom = 1;
        wideWorldOfWeb.MarginRight = 0;
        wideWorldOfWeb.RectClipContent = true;
        Webview webviewThatWillDie = EpicTabs[ActiveBullshit];
        webviewThatWillDie.QueueFree();
        the.AddChild(wideWorldOfWeb);

        // what am i doing
        Button close = EpicCloseButtons.FirstOrDefault(x => x.Value == EpicTabs[ActiveBullshit]).Key;
        EpicCloseButtons[close] = wideWorldOfWeb;
        EpicTabs[ActiveBullshit] = wideWorldOfWeb;
        EpicAwesomeEpicAddresses[ActiveBullshit] = address;

        OnTabSwitch(ActiveBullshit);

        // lol
        if (packed.ResourcePath == "res://apps/passionfruit/websites/browserSites/search.tscn") {
            wideWorldOfWeb.EditorDescription = address;
            wideWorldOfWeb.GetNode<Search>("search").Lol();
        }
        else {
            address = address.Replace(" ", "");
        }

        // save it in the user's history :)
        if (address != "404" && address != "" && address != "res://apps/passionfruit/websites/browserSites/search.tscn") {
            var fig = new Config<WebsiteConfig>();

            // translation crap
            var config = new Config<StringFinder>();
            if (!fig.Data.History.Contains(address)) {
                var jgssggsIthink = new Config<StringFinder>();
                jgssggsIthink.Data.Strings.Add(new HashSet<TranslationString>() {
                    new TranslationString {
                        Path = jsigtksk,
                        MessageId = $"You have unlocked '{address}', ask @hellory4n for the strings (it would be too much work to make this extract the strings from the scene)"
                    },
                });
                jgssggsIthink.Save();

                if (jgssggsIthink.Data.Enabled) {
                    Frambos.Notify("System", "Translation strings unlocked. Translate them at BetaTools.");
                    Frambos.Play(SystemSound.Notification);
                }
            }
            
            fig.Data.History.Add(address);
            fig.Save();
        }

        // show the handsome tags :)
        Node h = GetNode("../../../../../tags/scrollContainer/vBoxContainer");
        foreach (var g in h.GetChildren().Cast<Node>()) {
            if (g is Label lol) {
                if (lol.ThemeTypeVariation == "Header") {
                    continue;
                }
            }
            g.QueueFree();
        }
        foreach (string tag in wideWorldOfWeb.Tags) {
            h.AddChild(new Label {
                Text = tag
            });
        }
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

        if (EpicTabs.Count == 0) {
            emKayEssWindow.Close();
        }
    }
}

}