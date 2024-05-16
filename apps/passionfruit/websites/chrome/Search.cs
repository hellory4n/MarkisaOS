using Godot;
using markisa.mkstoolkit;
using markisa.network;
using System;
using System.Collections.Generic;
using System.Linq;

namespace passionfruit.coreapps.websites {

public class Search : Node
{
    public void Lol()
    {
        // lmao
        string query = GetParent().EditorDescription;

        // parse the query :))
        // we don't have to do a lot of stuff since there's some text telling you how to use it
        string[] tags = query.Split(' ');

        // search.
        HashSet<string> websites = WebSearch.Index[tags[0]];

        foreach (string tag in tags.Skip(1))
        {
            if (!WebSearch.Index.ContainsKey(tag))
            {
                // If any tag is not found in the dictionary, no website will satisfy the condition
                websites.Clear();
                break;
            }

            // Find the intersection of websites containing the current tag and the existing list
            websites = websites.Intersect(WebSearch.Index[tag]).ToHashSet();
        }

        // display results
        Node place = GetNode("../scrollContainer/vBoxContainer");
        foreach (string website in websites) {
            var webview = GD.Load<PackedScene>(website).Instance<Webview>();
            
            place.AddChild(new RichTextLabel {
                BbcodeEnabled = true,
                BbcodeText = $"[b]{Tr(webview.Title)} - {website.Replace("res://web//", "").Replace("/home.tscn", "")}[/b]\n{Tr(webview.Description)}",
                FitContentHeight = true
            });

            var j = new Button {
                Text = "Open website",
                ThemeTypeVariation = "Secondary"
            };
            place.AddChild(j);
            j.Connect("pressed", this, nameof(Lol), new Godot.Collections.Array { website });

            webview.QueueFree();
        }
    }

    public void Lol(string website)
    {
        var fufjk = GetNode<Button>("../lazy");
        fufjk.Set("website", website.Replace("res://web//", "").Replace("/home.tscn", ""));
        fufjk.Call("_pressed");
    }
}

}