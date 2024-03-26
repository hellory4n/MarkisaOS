using Godot;
using markisa.foundation;
using markisa.mkstoolkit;
using System;
using System.Collections.Generic;

namespace passionfruit.coreapps.downloads {

public class Downloads : ItemList
{
    readonly Texture unknown = GD.Load<Texture>("res://apps/passionfruit/files/fileTypes/unknown.png");
    readonly Texture text = GD.Load<Texture>("res://apps/passionfruit/files/fileTypes/text.png");

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
                default: AddItem(file, unknown); break;
            }
        }
    }

    public void OnItemSelected(int index)
    {
        selected = paths[index];
    }

    public void OnDeleteRequest()
    {
        // for fuck's sake
        MksFile<object>.Delete(selected);
        GetNode<MksPopup>("../delete").HidePopup();
        Refresh();
    }
}

}