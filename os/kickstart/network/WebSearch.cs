using Godot;
using markisa.mkstoolkit;
using System;
using System.Collections.Generic;
using System.Linq;

namespace markisa.network {

public class WebSearch : Node
{
    //public static Dictionary<string, HashSet<string>> Index { get; private set; } = new Dictionary<string, HashSet<string>>();
    public static Dictionary<string, HashSet<string>> Index { get; private set; } = new Dictionary<string, HashSet<string>>() {
        { "bee", new HashSet<string>(new string[] { "res://web//beemovie.net/home.tscn", }) }, { "movie", new HashSet<string>(new string[] { "res://web//beemovie.net/home.tscn", }) }, { "company", new HashSet<string>(new string[] { "res://web//passionfruit.com/home.tscn", "res://web//markisa.passionfruit.com/home.tscn", "res://web//markistation.passionfruit.com/home.tscn", "res://web//business.passionfruit.com/home.tscn", "res://web//developers.passionfruit.com/home.tscn", "res://web//koni.com/home.tscn", "res://web//hexagon.com/home.tscn", "res://web//kaiatu.com/home.tscn", }) }, { "passionfruit", new HashSet<string>(new string[] { "res://web//passionfruit.com/home.tscn", "res://web//markisa.passionfruit.com/home.tscn", "res://web//business.passionfruit.com/home.tscn", "res://web//developers.passionfruit.com/home.tscn", }) }, { "markisa", new HashSet<string>(new string[] { "res://web//passionfruit.com/home.tscn", "res://web//markisa.passionfruit.com/home.tscn", "res://web//markistation.passionfruit.com/home.tscn", "res://web//business.passionfruit.com/home.tscn", "res://web//developers.passionfruit.com/home.tscn", }) }, { "computers", new HashSet<string>(new string[] { "res://web//passionfruit.com/home.tscn", "res://web//markisa.passionfruit.com/home.tscn", "res://web//markistation.passionfruit.com/home.tscn", "res://web//business.passionfruit.com/home.tscn", "res://web//developers.passionfruit.com/home.tscn", "res://web//koni.com/home.tscn", }) }, { "os", new HashSet<string>(new string[] { "res://web//passionfruit.com/home.tscn", "res://web//markisa.passionfruit.com/home.tscn", "res://web//business.passionfruit.com/home.tscn", "res://web//developers.passionfruit.com/home.tscn", }) }, { "software", new HashSet<string>(new string[] { "res://web//passionfruit.com/home.tscn", "res://web//markisa.passionfruit.com/home.tscn", "res://web//business.passionfruit.com/home.tscn", "res://web//developers.passionfruit.com/home.tscn", "res://web//koni.com/home.tscn", }) }, { "business", new HashSet<string>(new string[] { "res://web//passionfruit.com/home.tscn", "res://web//business.passionfruit.com/home.tscn", "res://web//developers.passionfruit.com/home.tscn", }) }, { "developer", new HashSet<string>(new string[] { "res://web//passionfruit.com/home.tscn", "res://web//business.passionfruit.com/home.tscn", "res://web//developers.passionfruit.com/home.tscn", }) }, { "government_partner", new HashSet<string>(new string[] { "res://web//passionfruit.com/home.tscn", "res://web//business.passionfruit.com/home.tscn", "res://web//hexagon.com/home.tscn", "res://web//kaiatu.com/home.tscn", }) }, { "empresa", new HashSet<string>(new string[] { "res://web//passionfruit.com/home.tscn", "res://web//markisa.passionfruit.com/home.tscn", "res://web//markistation.passionfruit.com/home.tscn", "res://web//business.passionfruit.com/home.tscn", "res://web//developers.passionfruit.com/home.tscn", "res://web//koni.com/home.tscn", "res://web//hexagon.com/home.tscn", "res://web//kaiatu.com/home.tscn", }) }, { "computadores", new HashSet<string>(new string[] { "res://web//passionfruit.com/home.tscn", "res://web//markisa.passionfruit.com/home.tscn", "res://web//markistation.passionfruit.com/home.tscn", "res://web//business.passionfruit.com/home.tscn", "res://web//developers.passionfruit.com/home.tscn", "res://web//koni.com/home.tscn", }) }, { "sistema_operacional", new HashSet<string>(new string[] { "res://web//passionfruit.com/home.tscn", "res://web//markisa.passionfruit.com/home.tscn", "res://web//business.passionfruit.com/home.tscn", "res://web//developers.passionfruit.com/home.tscn", }) }, { "programas", new HashSet<string>(new string[] { "res://web//passionfruit.com/home.tscn", "res://web//markisa.passionfruit.com/home.tscn", "res://web//business.passionfruit.com/home.tscn", "res://web//developers.passionfruit.com/home.tscn", "res://web//koni.com/home.tscn", }) }, { "negócios", new HashSet<string>(new string[] { "res://web//passionfruit.com/home.tscn", "res://web//business.passionfruit.com/home.tscn", "res://web//developers.passionfruit.com/home.tscn", }) }, { "desenvolvimento", new HashSet<string>(new string[] { "res://web//passionfruit.com/home.tscn", "res://web//business.passionfruit.com/home.tscn", "res://web//developers.passionfruit.com/home.tscn", }) }, { "parceiro_do_governo", new HashSet<string>(new string[] { "res://web//passionfruit.com/home.tscn", "res://web//business.passionfruit.com/home.tscn", "res://web//hexagon.com/home.tscn", "res://web//kaiatu.com/home.tscn", }) }, { "koni", new HashSet<string>(new string[] { "res://web//koni.com/home.tscn", }) }, { "games", new HashSet<string>(new string[] { "res://web//koni.com/home.tscn", }) }, { "jogos", new HashSet<string>(new string[] { "res://web//koni.com/home.tscn", }) }, { "hexagon", new HashSet<string>(new string[] { "res://web//hexagon.com/home.tscn", }) }, { "food", new HashSet<string>(new string[] { "res://web//hexagon.com/home.tscn", }) }, { "essentials", new HashSet<string>(new string[] { "res://web//hexagon.com/home.tscn", "res://web//kaiatu.com/home.tscn", }) }, { "comida", new HashSet<string>(new string[] { "res://web//hexagon.com/home.tscn", }) }, { "essenciais", new HashSet<string>(new string[] { "res://web//hexagon.com/home.tscn", "res://web//kaiatu.com/home.tscn", }) }, { "kaiatu", new HashSet<string>(new string[] { "res://web//kaiatu.com/home.tscn", }) },  };
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
            webview.QueueFree();

            // duplicate the tags to include the translated stuff :)
            TranslationServer.SetLocale("pt");
            foreach (var tag in webview.Tags) {
                webview.Tags = webview.Tags.Append(Tr(tag)).ToArray();
            }

            TranslationServer.SetLocale("es");
            foreach (var tag in webview.Tags) {
                webview.Tags = webview.Tags.Append(Tr(tag)).ToArray();
            }

            TranslationServer.SetLocale("id");
            foreach (var tag in webview.Tags) {
                webview.Tags = webview.Tags.Append(Tr(tag)).ToArray();
            }

            foreach (string tag in webview.Tags) {
                tags.Add(website);
            }
            backwardsIndex.Add(website, webview.Tags);
        }

        // then we do the fucking
        foreach (var entry in backwardsIndex) {
            string website = entry.Key;
            string[] tags = entry.Value;

            foreach (string tag in tags) {
                if (Index.ContainsKey(tag)) {
                    Index[tag].Add(website);
                }
                else {
                    Index[tag] = new HashSet<string>(new string[] { website });
                }
            }
        }

        // now we turn the index into something we can paste into code :)
        string code = "new Dictionary<string, HashSet<string>>() { ";
        foreach (var pair in Index) {
            code += $"{{ \"{pair.Key}\", new HashSet<string>(new string[] {{ ";
            foreach (string website in pair.Value) {
                code += $"\"{website}\", ";
            }
            code += "}) }, ";
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
                    if (filename.Extension() == "tscn") everySingleWebsite.Add($"{path}/{filename}");
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