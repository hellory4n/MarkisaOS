using Godot;
using markisa.mkstoolkit;
using System;
using System.Collections.Generic;
using System.Linq;

namespace markisa.network {

public class WebSearch : Node
{
    //public static Dictionary<string, string[]> Index { get; private set; } = new Dictionary<string, string[]>();
    public static Dictionary<string, string[]> Index { get; private set; } = new Dictionary<string, string[]>() {
        { "bee", new string[] { "res://web//beemovie.net/home.tscn/", } }, { "movie", new string[] { "res://web//beemovie.net/home.tscn/", } }, { "company", new string[] { "res://web//passionfruit.com/home.tscn/", "res://web//markisa.passionfruit.com/home.tscn/", "res://web//markistation.passionfruit.com/home.tscn/", "res://web//business.passionfruit.com/jobs.tscn/", "res://web//business.passionfruit.com/home.tscn/", "res://web//developers.passionfruit.com/home.tscn/", "res://web//koni.com/home.tscn/", "res://web//hexagon.com/home.tscn/", "res://web//kaiatu.com/home.tscn/", } }, { "passionfruit", new string[] { "res://web//passionfruit.com/home.tscn/", "res://web//markisa.passionfruit.com/home.tscn/", "res://web//business.passionfruit.com/jobs.tscn/", "res://web//business.passionfruit.com/home.tscn/", "res://web//developers.passionfruit.com/home.tscn/", } }, { "markisa", new string[] { "res://web//passionfruit.com/home.tscn/", "res://web//markisa.passionfruit.com/home.tscn/", "res://web//markistation.passionfruit.com/home.tscn/", "res://web//business.passionfruit.com/home.tscn/", "res://web//developers.passionfruit.com/home.tscn/", } }, { "computers", new string[] { "res://web//passionfruit.com/home.tscn/", "res://web//markisa.passionfruit.com/home.tscn/", "res://web//markistation.passionfruit.com/home.tscn/", "res://web//business.passionfruit.com/jobs.tscn/", "res://web//business.passionfruit.com/home.tscn/", "res://web//developers.passionfruit.com/home.tscn/", "res://web//koni.com/home.tscn/", } }, { "os", new string[] { "res://web//passionfruit.com/home.tscn/", "res://web//markisa.passionfruit.com/home.tscn/", "res://web//business.passionfruit.com/home.tscn/", "res://web//developers.passionfruit.com/home.tscn/", } }, { "software", new string[] { "res://web//passionfruit.com/home.tscn/", "res://web//markisa.passionfruit.com/home.tscn/", "res://web//business.passionfruit.com/jobs.tscn/", "res://web//business.passionfruit.com/home.tscn/", "res://web//developers.passionfruit.com/home.tscn/", "res://web//koni.com/home.tscn/", } }, { "business", new string[] { "res://web//passionfruit.com/home.tscn/", "res://web//business.passionfruit.com/jobs.tscn/", "res://web//business.passionfruit.com/home.tscn/", "res://web//developers.passionfruit.com/home.tscn/", } }, { "developer", new string[] { "res://web//passionfruit.com/home.tscn/", "res://web//business.passionfruit.com/home.tscn/", "res://web//developers.passionfruit.com/home.tscn/", } }, { "government_partner", new string[] { "res://web//passionfruit.com/home.tscn/", "res://web//business.passionfruit.com/home.tscn/", "res://web//hexagon.com/home.tscn/", "res://web//kaiatu.com/home.tscn/", } }, { "jobs", new string[] { "res://web//business.passionfruit.com/jobs.tscn/", } }, { "koni", new string[] { "res://web//koni.com/home.tscn/", } }, { "games", new string[] { "res://web//koni.com/home.tscn/", } }, { "hexagon", new string[] { "res://web//hexagon.com/home.tscn/", } }, { "food", new string[] { "res://web//hexagon.com/home.tscn/", } }, { "essentials", new string[] { "res://web//hexagon.com/home.tscn/", "res://web//kaiatu.com/home.tscn/", } }, { "kaiatu", new string[] { "res://web//kaiatu.com/home.tscn/", } }
    };
    List<string> everySingleWebsite = new List<string>();
    // website: tags[]
    // it's supposed to be tag: websites[]
    Dictionary<string, string[]> backwardsIndex = new Dictionary<string, string[]>();
    HashSet<string> tags = new HashSet<string>();

    public override void _Ready()
    {
        #if DEBUG
        // i release beta versions on saturday, i need to update the indexing
        if (DateTime.Now.DayOfWeek != DayOfWeek.Saturday) {
            return;
        }

        OS.Execute("zenity", new string[] { "--warning", "--text=\"\"UPDATE THE WEBSITE INDEX!!!!1 (it's in the clipboard)\"\"" });

        // actually update the index :)
        FindAllWebsites("res://web/");

        // for every goddamn website we need to check the tags
        foreach (string website in everySingleWebsite) {
            var webview = GD.Load<PackedScene>(website).Instance<Webview>();
            backwardsIndex.Add(website, webview.Tags);
            webview.QueueFree();

            foreach (string tag in webview.Tags) {
                tags.Add(website);
            }
        }

        // then we do the fucking
        foreach (var entry in backwardsIndex) {
            string website = entry.Key;
            string[] tags = entry.Value;

            foreach (string tag in tags) {
                if (Index.ContainsKey(tag)) {
                    Index[tag] = Index[tag].Append(website).ToArray();
                }
                else {
                    Index[tag] = new string[] { website };
                }
            }
        }

        // now we turn the index into something we can paste into code :)
        string code = "new Dictionary<string, string[]>() { ";
        foreach (var pair in Index) {
            code += $"{{ \"{pair.Key}\", new string[] {{ ";
            foreach (string website in pair.Value) {
                code += $"\"{website}\", ";
            }
            code += "} }, ";
        }
        code += " }";
        OS.Clipboard = code;
        #endif
    }

    public void FindAllWebsites(string path)
    {
        var dir = new Directory();
        if (dir.Open(path) == Error.Ok) {
            dir.ListDirBegin(true);
            string filename = dir.GetNext();
            while (filename != "") {
                if (dir.CurrentIsDir()) {
                    FindAllWebsites($"{path}/{filename}");
                }
                else {
                    if (filename.Extension() == "tscn") everySingleWebsite.Add($"{path}/{filename}/");
                }
                filename = dir.GetNext();
            }
            dir.ListDirEnd();
        }
        else {
            GD.PushWarning($"Error reading {path}");
        }
    }
}

}