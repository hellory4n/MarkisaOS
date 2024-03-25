using Godot;
using markisa.foundation;
using System;

namespace passionfruit.coreapps.files {

public class CopyCutPaste : Button
{
    [Export(PropertyHint.NodePathValidTypes, "ItemList")]
    public NodePath vg;
    [Export]
    public int Mode;

    ListFiles hehe;

    public override void _Ready()
    {
        hehe = GetNode<ListFiles>(vg);
    }

    public override void _Process(float delta)
    {
        // we can't copy/cut the nothing
        if (Mode == 2) {
            Disabled = hehe.BeingCopied != "" || hehe.BeingCut != "";
        }
        else {
            Disabled = hehe.Selected == "";
        }
    }

    public override void _Pressed()
    {
        if (Mode == 0) {
            if (hehe.Selected != "") {
                hehe.BeingCopied = hehe.Selected;
            }
        }
        else if (Mode == 1) {
            if (hehe.Selected != "") {
                hehe.BeingCut = hehe.Selected;
            }
        }
        // paste
        else {
            string target = hehe.CurrentFolder;

            // copy or cut?
            string original = "";
            bool cut = false;
            if (hehe.BeingCopied != "") {
                cut = false;
                original = hehe.BeingCopied;
            }
            else {
                cut = true;
                original = hehe.BeingCut;
            }

            // should we copy metric buttloads of files?
            if (MksDir.IsDir(original)) {
                DeepCopy(original, target, cut);
            }
            // oh ok it's just a file
            else {
                MksDir.Copy(original, $"{target}/{original.GetFile()}");
            }
        }
    }

    void DeepCopy(string dir, string target, bool cut)
    {
        string[] items = MksDir.ListFiles(dir);
        foreach (string item in items) {
            string realpath = $"{dir}/{item}";
            MksDir.Copy(realpath, $"{target}/{item}");

            if (MksDir.IsDir(realpath)) {
                DeepCopy(dir, target, cut);
            }

            if (cut) {
                MksDir.Delete(realpath);
            }
        }
    }
}

}