using Godot;
using System;

namespace passionfruit.coreapps.files {

public class GoToParentFolder : Button
{
    [Export(PropertyHint.NodePathValidTypes, "ItemList")]
    public NodePath EpicAwesomeEpicThingy;
    
    public override void _Pressed()
    {
        var listFiles = GetNode<ListFiles>(EpicAwesomeEpicThingy);
        listFiles.Refresh(listFiles.CurrentFolder.GetBaseDir());
    }
}

}