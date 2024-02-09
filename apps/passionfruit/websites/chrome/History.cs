using Godot;
using markisa.foundation;
using System;

namespace passionfruit.coreapps.websites {

public class History : ItemList
{
    public override void _Ready()
    {
        LoadStuff();
    }

    public void LoadStuff()
    {
        Clear();

        var fig = new Config<WebsiteConfig>();
        foreach (string webOfSites in fig.Data.History) {
            AddItem(webOfSites);
        }

        GetNode<Button>("../bottom/open").Disabled = false;
    }
}

}