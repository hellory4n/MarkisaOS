using Godot;
using markisa.foundation;
using markisa.mkstoolkit;
using markisa.network;
using Newtonsoft.Json;
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

            // quite the mouthful
            itemUi.GetNode<Button>("view").Connect("pressed", this, nameof(View), new Godot.Collections.Array { JsonConvert.SerializeObject(item) });
            
            AddChild(itemUi);
        }
    }

    static MksStore GetStore(string zone, uint month)
    {
        MksStore result;
        switch (zone) {
            case "technology":
                switch (month) {
                    default: result = Technology1.Data; break;
                }
                break;
            
            case "local market":
                switch (month) {
                    default: result = LocalMarket1.Data; break;
                }
                break;

            default:
                switch (month) {
                    default: result = Essentials1.Data; break;
                }
                break;
        }

        return result;
    }

    public void View(string item)
    {
        var m = JsonConvert.DeserializeObject<MksStoreItem>(item);

        // do the shits :D
        var popup = GetNode<MksPopup>("../../../../popup");
        popup.ShowPopup();
        popup.GetNode<TextureRect>("m/n/photo").Texture = GD.Load<Texture>(m.Photo);
        popup.GetNode<Label>("m/n/o/name").Text = Tr(m.Name);
        popup.GetNode<Label>("m/n/o/p/seller").Text = Tr(m.Seller);
        popup.GetNode<Label>("m/n/o/p/rating").Text = $"{m.Rating}/10";
        popup.GetNode<RichTextLabel>("m/n/o/description").Text = Tr(m.Description);
        popup.GetNode<Button>("m/n/o/buy").Text = Tr("Buy - {price}").Replace("{price}", $"Ø{m.Price}");
        popup.GetNode<Button>("m/n/o/buy").Connect("pressed", this, nameof(Purchase), new Godot.Collections.Array { item });

        // can you actually buy it? lol
        var config = new Config<Banking>();
        popup.GetNode<Button>("m/n/o/buy").Disabled = config.Data.Cash < m.Price;
    }

    public void Purchase(string item)
    {
        var m = JsonConvert.DeserializeObject<MksStoreItem>(item);

        GetNode<MksPopup>("../../../../popup").HidePopup();

        // confusing way of switching categories
        GetNode<Control>("../../").Visible = false;
        GetNode<Control>("../../../cart").Visible = true;
        GetNode<ProgressBar>("../../../cart/m/paradoxBar").Value = 0;
        GetNode<ProgressBar>("../../../cart/m/paradoxBar").MaxValue = 100;
        GetNode<ProgressBar>("../../../cart/m/paradoxBar").Connect("finished", this, nameof(WhenTheShitArrives), new Godot.Collections.Array { item });

        // lose your life savings
        var config = new Config<Banking>();
        config.Data.Cash -= m.Price;

        config.Data.Transactions = config.Data.Transactions.Append(new BankTransaction {
            Amount = m.Price,
            Account = Tr(m.Seller),
            Send = true
        }).ToArray();

        config.Save();
    }

    public void WhenTheShitArrives(string item)
    {
        var m = JsonConvert.DeserializeObject<MksStoreItem>(item);
        Frambos.Notify("Marketplace", "Your package has arrived.");
        Frambos.Play(SystemSound.Success);
        new OnItemArrival(m);
        GetNode<ProgressBar>("../../../cart/m/paradoxBar").Disconnect("finished", this, nameof(WhenTheShitArrives));
    }
}

}