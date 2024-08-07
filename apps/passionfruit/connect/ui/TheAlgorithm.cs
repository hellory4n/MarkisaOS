using Godot;
using markisa.foundation;
using markisa.mkstoolkit;
using markisa.network;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
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

        if (Zone == "trending") {
            LoadMorePosts();
        }
    }

    public void LoadMorePosts()
    {
        // hehe
        if (Zone == "bookmarks") {
            foreach (var var_ in GetChildren().Cast<Node>()) {
                if (var_ is PanelContainer) {
                    var_.QueueFree();
                }
            }
        }

        MksConnectZone zone = GetConnectZone(Zone, 1);

        // the more button just reloads everything again, we can handle translation now :)
        HandleStringFinder(zone.Posts);

        // shuffle posts
        MksPost[] shuffled;
        if (Zone != "bookmarks") {
            shuffled = zone.Posts
                .Select(x => (x, random.Next()))
                .OrderBy(tuple => tuple.Item2)
                .Select(tuple => tuple.x)
                .ToArray();
        }
        else {
            shuffled = zone.Posts;
        }

        // show all of the posts and shit :)
        foreach (MksPost post in shuffled) {
            var postUi = postScene.Instance<Control>();

            // main content shit
            postUi.GetNode<Label>("m/n/user").Text = post.User;
            postUi.GetNode<TextureRect>("m/n/pfp").Texture = GD.Load<Texture>(post.ProfilePicture);
            // quite the mouthful
            postUi.GetNode<RichTextLabel>("m/o/content").BbcodeText = Tr(post.Content).Replace("<ping>", "[color=#448AFF]@").Replace("</ping>", "[/color]");
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
                // since godot is stupid we have to do this dumbass conversion to then parse it in Replies()
                var stupidarr = new Godot.Collections.Array();
                foreach (MksPost lol in post.Replies) {
                    stupidarr.Add(lol.User);
                    stupidarr.Add(lol.ProfilePicture);
                    stupidarr.Add(lol.Verified);
                    stupidarr.Add(lol.Content);
                    stupidarr.Add(lol.Images);
                    stupidarr.Add(lol.Link);
                    stupidarr.Add("");
                }

                postUi.GetNode<Button>("m/tools/reply").Connect("pressed", this, nameof(Replies), new Godot.Collections.Array {
                    stupidarr
                });
            }

            if (Zone != "bookmarks") {
                // godot is stupid
                postUi.GetNode<Button>("m/tools/bookmark").Connect("pressed", this, nameof(Bookmark), new Godot.Collections.Array {
                    JsonConvert.SerializeObject(post)
                });
            }
            else {
                postUi.GetNode("m/tools/bookmark").QueueFree();
            }

            postUi.GetNode<Button>("m/tools/share").Connect("pressed", this, nameof(Share), new Godot.Collections.Array {
                JsonConvert.SerializeObject(post)
            });
        }

        GetNode("more").Raise();
    }

    static MksConnectZone GetConnectZone(string zone, uint month)
    {
        MksConnectZone result;
        switch (zone) {
            case "bookmarks":
                var config = new Config<ConnectConfig>();
                result = new MksConnectZone {
                    Month = 1, // TODO: update when i add time
                    Music = "",
                    Background = "res://os/assets/bootloader/onboardingWallpaper.png",
                    Posts = config.Data.Bookmarks
                };
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

    public void Replies(Godot.Collections.Array postsStupidEdition)
    {
        GetNode<MksPopup>("../../popup").ShowPopup();
        var list = GetNode<VBoxContainer>("../../popup/scrollContainer/vBoxContainer");
        
        // since godot is stupid we have to send a dumbass array and then parse it
        var posts = new List<MksPost>();
        for (int i = 0; i < postsStupidEdition.Count; i++) {
            var mkspost = new MksPost {
                User = (string)postsStupidEdition[i],
                ProfilePicture = (string)postsStupidEdition[i + 1],
                Verified = (bool)postsStupidEdition[i + 2],
                Content = (string)postsStupidEdition[i + 3],
                Images = (string[])postsStupidEdition[i + 4],
                Link = (string)postsStupidEdition[i + 5]
            };
            i += 6;
            posts.Add(mkspost);
        }

        // clear previous replies
        foreach (dynamic node in list.GetChildren()) {
            if (node is PanelContainer ha) {
                ha.QueueFree();
            }
        }

        if (posts == null) {
            return;
        }

        // show all of the replies and shit :)
        foreach (MksPost post in posts) {
            var postUi = postScene.Instance<Control>();

            // main content shit
            postUi.GetNode<Label>("m/n/user").Text = post.User;
            postUi.GetNode<TextureRect>("m/n/pfp").Texture = GD.Load<Texture>(post.ProfilePicture);
            // quite the mouthful
            postUi.GetNode<RichTextLabel>("m/o/content").BbcodeText = Tr(post.Content).Replace("<ping>", "[color=#448AFF]@").Replace("</ping>", "[/color]");
            postUi.GetNode<CanvasItem>("m/n/verified").Visible = post.Verified;

            // attachments :)
            var attachmentPlace = postUi.GetNode("m/fk/attach");
            if (post.Images.Length != 0) {
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
            postUi.GetNode("m/tools/reply").QueueFree();
            postUi.GetNode("m/tools/bookmark").QueueFree();
            postUi.GetNode("m/tools/share").QueueFree();
            postUi.GetNode<Button>("m/tools/views").Text = FormatNumber(random.Next(5_000, 500_000));

            list.AddChild(postUi);
        }
    }

    public void Bookmark(string postjson)
    {
        var post = JsonConvert.DeserializeObject<MksPost>(postjson);
        var config = new Config<ConnectConfig>();
        config.Data.Bookmarks = config.Data.Bookmarks.Append(post).ToArray();
        config.Save();

        Frambos.Notify("Connect", "Post added to bookmarks");
        Frambos.Play(SystemSound.Notification);
    }

    public void Share(string postjson)
    {
        // open the popup & share data in the most questionable way possible
        GetNode<MksPopup>("../../../../share").ShowPopup();
        GetNode<Button>("../../../../share/m/n/o/continue").EditorDescription = postjson;

        // list the contacts :)
        var config = new Config<SocialInfo>();
        if (config.Data.Contacts.Length == 0) {
            return;
        }

        var contacts = GetNode<ItemList>("../../../../share/m/n/contacts");
        // we have to share it like this since the contact name is gonna be translated
        // i'm gonna die
        GetNode<ItemList>("../../../../share/m/n/contacts").EditorDescription = JsonConvert.SerializeObject(config.Data.Contacts);
        contacts.Clear();
        foreach (string contact in config.Data.Contacts) {
            contacts.AddItem(Tr(contact));
        }
    }

    void HandleStringFinder(MksPost[] posts)
    {
        // make sure we're actually pressing the "more" button
        // the 2 children are an invisible hseparator for padding, & the more button
        if (GetChildCount() == 2) {
            return;
        }

        var config = new Config<StringFinder>();

        var notAList = new HashSet<TranslationString>();
        foreach (MksPost post in posts) {
            notAList.Add(new TranslationString {
                Path = "res://apps/passionfruit/connect/app.tscn", // don't want to handle that
                MessageId = post.User
            });

            notAList.Add(new TranslationString {
                Path = "res://apps/passionfruit/connect/app.tscn", // don't want to handle that
                MessageId = post.Content
            });

            foreach (MksPost reply in post.Replies) {
                notAList.Add(new TranslationString {
                    Path = "res://apps/passionfruit/connect/app.tscn", // don't want to handle that
                    MessageId = reply.User
                });

                notAList.Add(new TranslationString {
                    Path = "res://apps/passionfruit/connect/app.tscn", // don't want to handle that
                    MessageId = reply.Content
                });
            }
        }

        config.Data.Strings.Add(notAList);
        config.Save();

        if (config.Data.Enabled) {
            Frambos.Notify("System", "Translation strings unlocked. Translate them at BetaTools.");
            Frambos.Play(SystemSound.Notification);
        }
    }
}

}