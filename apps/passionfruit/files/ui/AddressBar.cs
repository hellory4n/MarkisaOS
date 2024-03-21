using Godot;
using markisa.foundation;
using System;

namespace passionfruit.coreapps.files {

public class AddressBar : LineEdit
{
    [Export(PropertyHint.NodePathValidTypes, "ItemList")]
    public NodePath EpicAwesomeEpicThingy;

    public void Submit(string newText)
    {
        var listFiles = GetNode<ListFiles>(EpicAwesomeEpicThingy);
        
        if (MksDir.Exists(newText) && MksDir.IsDir(newText)) {
            listFiles.Refresh(newText);
        }
    }
}

}