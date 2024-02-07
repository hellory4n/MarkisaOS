using Godot;
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
    Node the;
    MksWindow emKayEssWindow;

    ButtonGroup group = new ButtonGroup();
    Dictionary<Button, Webview> epicTabs = new Dictionary<Button, Webview>();
    Dictionary<Button, Webview> epicCloseButtons = new Dictionary<Button, Webview>();

    readonly PackedScene newtab = GD.Load<PackedScene>("res://apps/passionfruit/websites/browserSites/newtab.tscn");
    readonly Texture closeIcon = GD.Load<Texture>("res://os/assets/highPeaks/icons/close.png");

    public override void _Ready()
    {
        the = GetNode(TheShitWhereWebsitesAre);
        emKayEssWindow = GetNode<MksWindow>(Window);
        AddTab();
    }

    public override void _Process(float delta)
    {
        // jgsdfjpghkoskgophsrkopkoprg
        foreach (var ifInterThenOnlyNet in epicTabs) {
            ifInterThenOnlyNet.Key.Text = ifInterThenOnlyNet.Value.Title;
            ifInterThenOnlyNet.Key.Icon = ifInterThenOnlyNet.Value.Icon;
        }

        emKayEssWindow.MemoryUsage = Mathf.Min(epicTabs.Count * 6, 100);
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
        epicTabs.Add(buttOn, totallyAccurateBattleSimulator);
        epicCloseButtons.Add(nearby, totallyAccurateBattleSimulator);

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

    public void OnTabSwitch(Button button)
    {
        foreach (var jgg in epicTabs) {
            jgg.Value.Visible = jgg.Key == button;
            jgg.Value.IsActive = jgg.Key == button;
            button.Pressed = true;
        }

        emKayEssWindow.WindowTitle = $"{epicTabs[button].Title} — Websites";
    }

    public void OnTabClose(Button button)
    {
        if (epicCloseButtons[button].IsActive) {
            OnTabSwitch(epicTabs.First().Key);
        }

        // find the corresponding tab switcher thing :)
        // i love COC (Clash Of Clans)
        Button clashOfClans = epicTabs.FirstOrDefault(x => x.Value == epicCloseButtons[button]).Key;

        epicCloseButtons[button].QueueFree();
        clashOfClans.GetParent().QueueFree();

        epicCloseButtons.Remove(button);
        epicTabs.Remove(clashOfClans);

        if (epicTabs.Count == 0) {
            emKayEssWindow.Close();
        }
    }
}

}