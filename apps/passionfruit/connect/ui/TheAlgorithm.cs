using Godot;
using markisa.foundation;
using markisa.mkstoolkit;
using markisa.network;
using System;
using System.Linq;

namespace passionfruit.coreapps.connect {

public class TheAlgorithm : VBoxContainer
{
    readonly PackedScene postScene = GD.Load<PackedScene>("res://apps/passionfruit/connect/ui/post.tscn");

    [Export]
    public string Zone = "trending";
    [Export(PropertyHint.NodePathValidTypes, "TextureRect")]
    public NodePath Background;
    public Random random = new Random();

    public override void _Ready()
    {
        MksConnectZone zone = GetConnectZone(Zone, 1);

        // background
        var texture = GD.Load<Texture>(zone.Background);
        GetNode<TextureRect>(Background).Texture = texture;

        LoadMorePosts();
    }

    public void LoadMorePosts()
    {
        MksConnectZone zone = GetConnectZone(Zone, 1);

        // shuffle posts
        var shuffled = zone.Posts
            .Select(x => (x, random.Next()))
            .OrderBy(tuple => tuple.Item2)
            .Select(tuple => tuple.x)
            .ToArray();

        // show all of the posts and shit :)
        foreach (MksPost post in shuffled) {
            var postUi = postScene.Instance<Control>();

            // main content shit
            postUi.GetNode<Label>("m/n/user").Text = post.User;
            postUi.GetNode<TextureRect>("m/n/pfp").Texture = GD.Load<Texture>(post.ProfilePicture);
            // quite the mouthful
            postUi.GetNode<RichTextLabel>("m/o/content").BbcodeText = Tr(post.Content.Replace("<ping>", "[color=#448AFF]@").Replace("</ping>", "[/color]"));
            postUi.GetNode<CanvasItem>("m/n/verified").Visible = post.Verified;

            // attachments :)
            var attachmentPlace = postUi.GetNode("m/fk/attach");
            if (post.Images != null) { // rewrite it in rust
                foreach (string img in post.Images) {
                    var imag = new TextureRect {
                        Texture = GD.Load<Texture>(img),
                        SizeFlagsHorizontal = 0,
                        RectMinSize = new Vector2(332, 249),
                        Expand = true,
                        StretchMode = TextureRect.StretchModeEnum.KeepAspectCovered
                    };
                    attachmentPlace.AddChild(imag);
                }
            }

            // rewrite it in rust
            if (!string.IsNullOrEmpty(post.Link)) {
                var linkFromTheLegendOfZelda = new Button {
                    Text = "Copy Link",
                    ThemeTypeVariation = "Secondary",
                    RectMinSize = new Vector2(332, 45),
                    SizeFlagsHorizontal = 0
                };
                attachmentPlace.AddChild(linkFromTheLegendOfZelda);
                linkFromTheLegendOfZelda.Connect("pressed", this, nameof(CopyLink), new Godot.Collections.Array {
                    post.Link
                });
            }
            
            // dumbass stats
            postUi.GetNode<Button>("m/tools/like").Text = FormatNumber(random.Next(1_000, 100_000));
            postUi.GetNode<Button>("m/tools/reply").Text = FormatNumber(random.Next(10, 10_000));
            postUi.GetNode<Button>("m/tools/views").Text = FormatNumber(random.Next(10_000, 10_000_000));

            AddChild(postUi);

            if (post.Replies != null) {
                postUi.GetNode<Button>("m/tools/reply").Connect("pressed", this, nameof(Replies), new Godot.Collections.Array {
                    GetNode<VBoxContainer>("../../popup/scrollContainer/vBoxContainer"), post.Replies
                });
            }
        }
    }

    static MksConnectZone GetConnectZone(string zone, uint month)
    {
        MksConnectZone result;
        switch (zone) {
            case "comedy":
                switch (month) {
                    default: result = ComedyZone1.Data; break;
                }
                break;
            
            case "creativity":
                switch (month) {
                    default: result = CreativityZone1.Data; break;
                }
                break;
            
            case "discussion":
                switch (month) {
                    default: result = DiscussionZone1.Data; break;
                }
                break;
            
            case "entertainment":
                switch (month) {
                    default: result = EntertainmentZone1.Data; break;
                }
                break;
            
            case "help center":
                switch (month) {
                    default: result = HelpCenterZone1.Data; break;
                }
                break;
            
            case "technology":
                switch (month) {
                    default: result = TechnologyZone1.Data; break;
                }
                break;
            
            default:
                switch (month) {
                    default: result = TrendingZone1.Data; break;
                }
                break;
        }

        return result;
    }

    static string FormatNumber(double number)
    {
        if (number >= 1_000_000) {
            // guess what, international number formatting !!
            if (TranslationServer.GetLocale() == "pt") {
                return $"{number / 1_000_000:F1} mi";
            }
            else if (TranslationServer.GetLocale() == "id") {
                return $"{number / 1_000_000:F1}jt";
            }
            else {
                return $"{number / 1_000_000:F1}M";
            }
        }
        else if (number >= 1_000) {
            if (TranslationServer.GetLocale() == "pt") {
                return $"{number / 1_000:F1} mil";
            }
            else if (TranslationServer.GetLocale() == "id") {
                return $"{number / 1_000:F1}rb";
            }
            else {
                return $"{number / 1_000:F1}K";
            }
        }
        else {
            return number.ToString();
        }
    }

    public void CopyLink(string url)
    {
        OS.Clipboard = url;
        Frambos.Notify("Connect", "Link copied.");
        Frambos.Play(SystemSound.Notification);
    }

    public void Replies(VBoxContainer list, MksPost[] posts)
    {
        GetNode<MksPopup>("../../popup").ShowPopup();

        // clear previous replies
        foreach (dynamic node in list.GetChildren()) {
            if (node is PanelContainer ha) {
                ha.QueueFree();
            }
        }

        if (posts == null) {
            return;
        }

        var shuffled = posts
            .Select(x => (x, random.Next()))
            .OrderBy(tuple => tuple.Item2)
            .Select(tuple => tuple.x)
            .ToArray();

        // show all of the replies and shit :)
        foreach (MksPost post in shuffled) {
            var postUi = postScene.Instance<Control>();

            // main content shit
            postUi.GetNode<Label>("m/n/user").Text = post.User;
            postUi.GetNode<TextureRect>("m/n/pfp").Texture = GD.Load<Texture>(post.ProfilePicture);
            // quite the mouthful
            postUi.GetNode<RichTextLabel>("m/o/content").BbcodeText = Tr(post.Content.Replace("<ping>", "[color=#448AFF]@").Replace("</ping>", "[/color]"));
            postUi.GetNode<CanvasItem>("m/n/verified").Visible = post.Verified;

            // attachments :)
            var attachmentPlace = postUi.GetNode("m/fk/attach");
            if (post.Images != null) { // rewrite it in rust
                foreach (string img in post.Images) {
                    var imag = new TextureRect {
                        Texture = GD.Load<Texture>(img),
                        SizeFlagsHorizontal = 0,
                        RectMinSize = new Vector2(332, 249),
                        Expand = true,
                        StretchMode = TextureRect.StretchModeEnum.KeepAspectCovered
                    };
                    attachmentPlace.AddChild(imag);
                }
            }

            // rewrite it in rust
            if (!string.IsNullOrEmpty(post.Link)) {
                var linkFromTheLegendOfZelda = new Button {
                    Text = "Copy Link",
                    ThemeTypeVariation = "Secondary",
                    RectMinSize = new Vector2(332, 45),
                    SizeFlagsHorizontal = 0
                };
                attachmentPlace.AddChild(linkFromTheLegendOfZelda);
                linkFromTheLegendOfZelda.Connect("pressed", this, nameof(CopyLink), new Godot.Collections.Array {
                    post.Link
                });
            }
            
            // dumbass stats
            postUi.GetNode<Button>("m/tools/like").Text = FormatNumber(random.Next(50, 5_000));
            postUi.GetNode<Button>("m/tools/views").Text = FormatNumber(random.Next(5_000, 500_000));

            list.AddChild(postUi);
        }
    }
}

}