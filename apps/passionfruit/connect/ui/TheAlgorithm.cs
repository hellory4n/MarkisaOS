using Godot;
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
            postUi.GetNode<Label>("m/n/user").Text = post.User;
            postUi.GetNode<TextureRect>("m/n/pfp").Texture = GD.Load<Texture>(post.ProfilePicture);
            postUi.GetNode<RichTextLabel>("m/o/content").BbcodeText = Tr(post.Content);
            postUi.GetNode<CanvasItem>("m/n/verified").Visible = post.Verified;

            postUi.GetNode<Button>("m/tools/like").Text = FormatNumber(random.Next(1_000, 100_000));
            postUi.GetNode<Button>("m/tools/reply").Text = FormatNumber(random.Next(10, 10_000));
            postUi.GetNode<Button>("m/tools/views").Text = FormatNumber(random.Next(10_000, 10_000_000));

            AddChild(postUi);
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

    static string FormatNumber(int number)
    {
        if (number >= 1_000_000) {
            return $"{number / 1_000_000:F1}M";
        }
        else if (number >= 1_000) {
            return $"{number / 1_000:F1}K";
        }
        else {
            return number.ToString();
        }
    }
}

}