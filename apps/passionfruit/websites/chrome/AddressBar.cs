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
        webTabs.LoadStuff(newText);
        webTabs.NavigationStuffs[webTabs.ActiveBullshit].Add(newText);
        webTabs.IndexStuff[webTabs.ActiveBullshit]++;
    }
}

}