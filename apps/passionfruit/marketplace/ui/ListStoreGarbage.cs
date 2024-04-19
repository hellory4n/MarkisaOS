using Godot;
using markisa.network;
using System;
using System.Linq;

namespace passionfruit.coreapps.store {

public class ListStoreGarbage : HFlowContainer
{
    readonly PackedScene itemScene = GD.Load<PackedScene>("res://apps/passionfruit/marketplace/ui/item.tscn");

    [Export]
    public string Zone = "essentials";
    Random random = new Random();

    public override void _Ready()
    {
        LoadMorePosts();
    }

    public void LoadMorePosts()
    {
        MksStore store = GetStore(Zone, 1);

        // shuffle posts
        MksStoreItem[] shuffled;
        if (Zone != "bookmarks") {
            shuffled = store.Items
                .Select(x => (x, random.Next()))
                .OrderBy(tuple => tuple.Item2)
                .Select(tuple => tuple.x)
                .ToArray();
        }
        else {
            shuffled = store.Items;
        }

        // show all of the posts and shit :)
        foreach (MksStoreItem item in shuffled) {
            var itemUi = itemScene.Instance<Control>();

            // main content shit
            itemUi.GetNode<TextureRect>("photo").Texture = GD.Load<Texture>(item.Photo);
            itemUi.GetNode<Label>("product").Text = item.Name;
            itemUi.GetNode<Button>("view").Text = Tr("View - {price}").Replace("{price}", $"Ø{item.Price}");
            
            AddChild(itemUi);
        }
    }

    static MksStore GetStore(string zone, uint month)
    {
        MksStore result;
        switch (zone) {
            default:
                switch (month) {
                    default: result = Essentials1.Data; break;
                }
                break;
        }

        return result;
    }
}

}