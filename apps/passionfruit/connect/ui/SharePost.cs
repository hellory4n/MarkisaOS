using Godot;
using markisa.foundation;
using markisa.network;
using Newtonsoft.Json;
using System;
using System.Linq;

namespace passionfruit.coreapps.connect {

public class SharePost : Button
{
    public override void _Pressed()
    {
        // TheAlgorithm.cs shares the post in certainly unique ways
        var post = JsonConvert.DeserializeObject<MksPost>(EditorDescription);

        var config = new Config<SocialInfo>();
        var config2 = new Config<MarkisaUser>();
        var contacts = GetNode<ItemList>("../../contacts");
        
        // AAAAAAAAAAAAAAAAA
        var contactArray = JsonConvert.DeserializeObject<string[]>(contacts.EditorDescription);
        string contact = contacts.GetItemText(contacts.GetSelectedItems()[0]);
        
        // i'm dying
        var emkayessMeiou = new MksEmail {
            User = "You",
            ProfilePicture = config2.Data.Photo,
            Content = Tr($"Dear (name),\nI found a post you might be interested in:\n\n(post info)\n\nCheers,\n{Frambos.CurrentUserDisplayName}")
                .Replace("(name)", contact)
                .Replace("(post info)", $"[b]{Tr(post.User)}[/b]\n{Tr(post.Content)}")
                .Replace("<ping>", "[color=#448AFF]@")
                .Replace("</ping>", "[/color]")
        };

        config.Data.Emails = config.Data.Emails.Append(emkayessMeiou).ToArray();
        config.Save();
    }
}

}