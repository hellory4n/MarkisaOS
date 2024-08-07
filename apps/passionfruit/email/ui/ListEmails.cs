using Godot;
using markisa.foundation;
using markisa.network;
using System;

namespace passionfruit.coreapps.emails {

public class ListEmails : ItemList
{
    [Export(PropertyHint.NodePathValidTypes, "RichTextLabel")]
    public NodePath Help;

    Config<SocialInfo> config;

    public override void _Ready()
    {
        // really couldn't figure out a proper null check
        // should have written it in rust smh
        config = new Config<SocialInfo>();
        config.Data.Emails = new MksEmail[] {};
        Refresh();
    }

    public void Refresh()
    {
        // new is a keyword so we call it new but in japanese
        var 新しい = new Config<SocialInfo>();
        if (新しい.Data.Emails.Length != config.Data.Emails.Length) {
            config = 新しい;
        }
        else {
            return;
        }

        // actually list the shit
        Clear();
        foreach (MksEmail email in config.Data.Emails) {
            AddItem(email.User, GD.Load<Texture>(email.ProfilePicture));
        }
    }

    public void ItemSelected(int index)
    {
        // get email :)
        MksEmail email = config.Data.Emails[index];

        // do the shit
        var bourgeoisTextLabel = GetNode<RichTextLabel>(Help);
        bourgeoisTextLabel.Clear();
        // the content for emails sent by you already come translated :)
        if (email.User == "You") {
            bourgeoisTextLabel.BbcodeText = $"{Tr("[b]You -")} {email.Time}[/b]\n\n{email.Content}";
        }
        else {
            bourgeoisTextLabel.BbcodeText = $"[b]{Tr(email.User)} - {email.Time}[/b]\n\n{Tr(email.Content)}";
        }

        foreach (object m in bourgeoisTextLabel.GetParent().GetChildren()) {
            if (m is Node h) {
                if (h is RichTextLabel) {
                    continue;
                }
                h.QueueFree();
            }
        }

        // GTUIGJKBGJKNHK
        if (email.Images != null) { // rewrite it in rust
            foreach (string img in email.Images) {
                var iphone = new TextureRect {
                    Texture = GD.Load<Texture>(img),
                    SizeFlagsHorizontal = 0,
                    RectMinSize = new Vector2(332, 249),
                    Expand = true,
                    StretchMode = TextureRect.StretchModeEnum.KeepAspectCovered
                };
                bourgeoisTextLabel.GetParent().AddChild(iphone);
            }
        }
    }

    public void CopyLink(string url)
    {
        OS.Clipboard = url;
        Frambos.Notify("Emails", "Link copied.");
        Frambos.Play(SystemSound.Notification);
    }
}

}