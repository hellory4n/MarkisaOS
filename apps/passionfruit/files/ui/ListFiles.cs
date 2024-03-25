using Godot;
using markisa.foundation;
using System;
using System.Collections.Generic;

namespace passionfruit.coreapps.files {

public class ListFiles : ItemList
{
    readonly Texture folderIcon = GD.Load<Texture>("res://apps/passionfruit/files/dockicon.png");
    readonly Texture textIcon = GD.Load<Texture>("res://apps/passionfruit/files/fileTypes/text.png");
    readonly Texture fileIcon = GD.Load<Texture>("res://apps/passionfruit/files/fileTypes/unknown.png");

    List<string> paths = new List<string>();
    public string CurrentFolder = "/";
    public string BeingCopied = "";
    public string BeingCut = "";
    public string Selected = "";

    public override void _Ready()
    {
        base._Ready();
        Refresh("/");
    }

    public void Refresh(string path)
    {
        CurrentFolder = path;
        Clear();
        paths.Clear();
        string[] stuff = MksDir.ListFiles(path);

        foreach (string item in stuff) {
            switch (GetType($"{path}/{item}")) {
                case FileType.Folder: AddItem(item, folderIcon); break;
                case FileType.Text: AddItem(item, textIcon); break;
                case FileType.Unknown: AddItem(item, fileIcon); break;
            }

            paths.Add(item);
        }

        Selected = "";
    }

    public void Open(int index)
    {
        string item = paths[index];
        GD.Print(item);
        GD.Print(CurrentFolder);
        GD.Print($"{CurrentFolder}/{item}");
        GD.Print();
        
        switch (GetType(item)) {
            case FileType.Folder: Refresh($"{CurrentFolder}/{item}"); break;
            // TODO: add a text viewer
        }
    }

    public void RefreshButton()
    {
        Refresh(CurrentFolder);
    }

    public void Select(int index)
    {
        Selected = $"{CurrentFolder}/{paths[index]}";
    }

    public FileType GetType(string path)
    {
        if (MksDir.IsDir(path)) {
            return FileType.Folder;
        }
        else {
            switch (path.Extension()) {
                case "txt": return FileType.Text;
                default: return FileType.Unknown;
            }
        }
    }
}

}

public enum FileType
{
    Folder,
    Text,
    Unknown
}