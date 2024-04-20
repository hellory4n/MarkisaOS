using Godot;
using markisa.foundation;
using markisa.mkstoolkit;
using markisa.network;
using Newtonsoft.Json;
using System;
using System.Linq;

namespace passionfruit.coreapps.websites {

public class ShareWebsite : Button
{
    public override void _Ready()
    {
        var config = new Config<SocialInfo>();
        if (config.Data.Contacts.Length == 0) {
            return; 
        }

        var contacts = GetNode<ItemList>("../../contacts");
        contacts.Clear();
        foreach (string contact in config.Data.Contacts) {
            contacts.AddItem(Tr(contact));
        }
    }

    public override void _Pressed()
    {
        var config = new Config<SocialInfo>();
        var config2 = new Config<MarkisaUser>();
        var config3 = new Config<StoryProgress>();
        var contacts = GetNode<ItemList>("../../contacts");
        string address = GetNode<LineEdit>("../../../../../container/sidebar/vBoxContainer/address").Text;

        // AAAAAAAAAAAAAAAAA
        if (contacts.GetSelectedItems().Length == 0) {
            return;
        }
        string contact = contacts.GetItemText(contacts.GetSelectedItems()[0]);
        
        // i'm dying
        var emkayessMeiou = new MksEmail {
            User = "You",
            ProfilePicture = config2.Data.Photo,
            Content = Tr("Dear {name},(/n)(/n)I found a website you might be interested in: {website}(/n)(/n)Cheers,(/n){user}")
                .Replace("(/n)", "\n")
                .Replace("{name}", Tr(contact))
                .Replace("{website}", address)
                .Replace("{user}", Frambos.CurrentUserDisplayName),
            
            Time = Frambos.Now
        };

        config.Data.Emails = config.Data.Emails.Append(emkayessMeiou).ToArray();
        config.Save();

        GetParent().GetParent().GetParent().GetParent<MksPopup>().HidePopup();
    }
}

}