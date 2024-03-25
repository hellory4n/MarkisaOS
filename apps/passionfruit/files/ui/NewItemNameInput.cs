using Godot;
using markisa.foundation;
using markisa.mkstoolkit;
using System;

namespace passionfruit.coreapps.files {

public class NewItemNameInput : LineEdit
{
    [Export(PropertyHint.NodePathValidTypes, "Button")]
    public NodePath CreatePath;
    Button create;
    public int heheheha = 0;
    public string fucking;

    public override void _Ready()
    {
        create = GetNode<Button>(CreatePath);
    }

    public override void _Process(float delta)
    {
        // enable irl computer noises
        create.Disabled = Text.Contains("/") || Text.Contains(">") || Text.Contains("<") || Text.Contains(":") ||
                          Text.Contains("\"") || Text.Contains("\\") || Text.Contains("|") || Text.Contains("?") ||
                          Text.Contains("*");
        
        // yes
        switch (heheheha) {
            case 1: PlaceholderText = "New Folder"; break;
            case 2: PlaceholderText = "New Text File"; break;
        }
    }

    public void Create()
    {
        switch (heheheha) {
            case 1:
                MksDir.MakeDir($"{fucking}/{Text}");
                break;
            
            case 2:
                new MksFile<MksTextFile>($"{fucking}/{Text}.txt");
                break;
        }

        Text = "";
        // fuck it
        GetParent().GetParent().GetParent<MksPopup>().HidePopup();
        GetNode<ListFiles>("../../../../container/content/control").Refresh(fucking);
    }
}

}