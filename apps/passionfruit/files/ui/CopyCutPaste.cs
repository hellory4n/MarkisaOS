using Godot;
using System;

namespace passionfruit.coreapps.files {

public class CopyCutPaste : Button
{
    [Export(PropertyHint.NodePathValidTypes, "ItemList")]
    public NodePath vg;
    [Export]
    public int Mode;

    static string path = "";

    /*public override void _Pressed()
    {
        var hehe = GetNode<ListFiles>(vg);
        hehe.
    }*/
}

}