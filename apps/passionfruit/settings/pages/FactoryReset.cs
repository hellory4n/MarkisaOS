using Godot;
using System;

namespace passionfruit.coreapps.settings {

public class FactoryReset : Button
{
    public override void _Pressed()
    {
        DeleteFolder("user://");
        GetTree().Quit();
    }

    public void DeleteFolder(string path)
    {
        var dir = new Directory();
        if (dir.Open(path) == Error.Ok) {
            dir.ListDirBegin(true);
            string filename = dir.GetNext();
            while (filename != "") {
                if (dir.CurrentIsDir()) {
                    DeleteFolder($"{path}/{filename}");
                    dir.Remove($"{path}/{filename}/");
                }
                else {
                    dir.Remove($"{path}/{filename}");
                }
                filename = dir.GetNext();
            }
            dir.ListDirEnd();
        }
        else {
            GD.PushWarning($"Error deleting {path}");
        }
    }
}

}