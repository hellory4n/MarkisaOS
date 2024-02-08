using Godot;
using markisa.foundation;
using markisa.mkstoolkit;
using System;
using System.Linq;

namespace passionfruit.coreapps.websites {

public class AddressBar : LineEdit
{
    [Export]
    public NodePath Tabs;
    WebTabs webTabs;

    public override void _Ready()
    {
        webTabs = GetNode<WebTabs>(Tabs);
    }

    public void Djfjsgjs(string newText)
    {
        PackedScene packed;
        string jsigtksk = Frambos.GetRealWebPath(newText);
        if (jsigtksk == "404") {
            packed = GD.Load<PackedScene>("res://apps/passionfruit/websites/browserSites/404.tscn");
        }
        else {
            packed = GD.Load<PackedScene>(jsigtksk);
        }

        // commit some shitfuckery :D
        Webview wideWorldOfWeb = packed.Instance<Webview>();
        Webview webviewThatWillDie = webTabs.EpicTabs[webTabs.ActiveBullshit];

        foreach (Node kgxfjkgsfjghisf in webviewThatWillDie.GetChildren()) {
            kgxfjkgsfjghisf.QueueFree();
        }

        webviewThatWillDie.ReplaceBy(wideWorldOfWeb);

        // what am i doing
        Button close = webTabs.EpicCloseButtons.FirstOrDefault(x => x.Value == webTabs.EpicTabs[webTabs.ActiveBullshit]).Key;
        webTabs.EpicCloseButtons[close] = wideWorldOfWeb;
        webTabs.EpicTabs[webTabs.ActiveBullshit] = wideWorldOfWeb;
        webTabs.EpicAwesomeEpicAddresses[webTabs.ActiveBullshit] = newText;

        webTabs.OnTabSwitch(webTabs.ActiveBullshit);
    }
}

}