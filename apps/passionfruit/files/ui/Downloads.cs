using Godot;
using markisa.foundation;
using markisa.mkstoolkit;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;

namespace passionfruit.coreapps.downloads {

public class Downloads : ItemList
{
    readonly Texture unknown = GD.Load<Texture>("res://apps/passionfruit/files/fileTypes/unknown.png");
    readonly Texture text = GD.Load<Texture>("res://apps/passionfruit/files/fileTypes/text.png");
    readonly Texture mpkg = GD.Load<Texture>("res://apps/passionfruit/files/fileTypes/mkspackage.png");

    List<string> paths = new List<string>();
    string selected = "";

    public override void _Ready()
    {
        Refresh();
    }

    public void Refresh()
    {
        paths.Clear();
        Clear();

        // list the files
        List<string> files = new List<string>();
        
        var dir = new Directory();
        dir.MakeDirRecursive($"user://fs/{Frambos.CurrentUser}");
        dir.Open($"user://fs/{Frambos.CurrentUser}/");
        dir.ListDirBegin(true);

        string filename = dir.GetNext();
        while (filename != "") {
            files.Add(filename);
            paths.Add(filename);
            filename = dir.GetNext();
        }

        // add the items
        foreach (string file in files) {
            switch (file.Extension()) {
                case "txt": AddItem(file, text); break;
                case "mpkg": AddItem(file, mpkg); break;
                default: AddItem(file, unknown); break;
            }
        }
    }

    public void OnItemSelected(int index)
    {
        selected = paths[index];
    }

    public void OnOpenPressed()
    {
        var bruh = new MksFile(selected);
        switch (bruh.Name.Extension()) {
            case "txt":
                GetNode<MksPopup>("../textView").ShowPopup();
                GetNode<RichTextLabel>("../textView/text").Text = bruh.Data;
                break;
            case "mpkg":
                GetNode<MksPopup>("../packageInstaller").ShowPopup();
                var ha = GetNode<ProgressBar>("../packageInstaller/centerContainer/vBoxContainer/paradoxBar");
                ha.MaxValue = 50;
                ha.Value = 0;
                ha.Connect("finished", this, nameof(OnAppInstall), new Godot.Collections.Array { bruh.Data, ha } );
                break;
        }
    }

    public void OnDeleteRequest()
    {
        MksFile.Delete(selected);
        GetNode<MksPopup>("../delete").HidePopup();
        Refresh();
    }

    public void OnAppInstall(string data, ProgressBar hehe)
    {
        var g = JsonConvert.DeserializeObject<MksPackage>(data);
        var config = new Config<AppStuff>();
        // i hope you have an ultrawide monitor
        if (config.Data.InstalledApps.ToList().Exists(x => x.DisplayName == g.Author && x.DisplayName == g.Author && x.Icon == g.Icon)) {
            config.Data.InstalledApps = config.Data.InstalledApps.Append(g).ToArray();
        }
        config.Save();
        
        // gkjsfigjsigjmsijgs
        Frambos.Notify("System", "App installed succesfully");
        Frambos.Play(SystemSound.Notification);
        hehe.Disconnect("finished", this, nameof(OnAppInstall));
    }
}

}