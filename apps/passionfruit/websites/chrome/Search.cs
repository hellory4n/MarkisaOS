using Godot;
using markisa.mkstoolkit;
using markisa.network;
using System;
using System.Collections.Generic;
using System.Linq;

namespace passionfruit.coreapps.websites {

public class Search : Node
{
    public override void _Ready()
    {
        // lmao
        string query = GetParent().EditorDescription;

        // parse the query :))
        // we don't have to do a lot of stuff since there's some text telling you how to use it
        string[] tags = query.Split(' ');

        // search.
        var websites = new List<string>();
        foreach (string tag in tags) {
            // if the user has put "mucka_blucka_by_fabloo_band_tally_hall" we should just immediately give up
            if (!WebSearch.Index.ContainsKey(tag)) {
                websites.Clear();
                break;
            }

            // ???
            if (websites.Count == 0) {
                websites.AddRange(WebSearch.Index[tag]);
            }
            else {
                websites = websites.Intersect(WebSearch.Index[tag]).ToList();
            }
        }

        // display results
        Node place = GetNode("../scrollContainer/vBoxContainer");
        foreach (string website in websites) {
            var webview = GD.Load<PackedScene>(website).Instance<Webview>();
            
            place.AddChild(new RichTextLabel {
                BbcodeEnabled = true,
                BbcodeText = $"[b]{Tr(webview.Title)} - {website}[/b]\n{Tr(webview.Description)}"
            });

            place.AddChild(new Button {
                Name = Tr("Open website"),
                ThemeTypeVariation = "Secondary"
            });

            webview.QueueFree();
        }
    }
}

}