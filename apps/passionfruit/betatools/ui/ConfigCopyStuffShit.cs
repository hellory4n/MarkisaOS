using Godot;
using markisa.foundation;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;

namespace passionfruit.coreapps.betatools {

public class ConfigCopyStuffShit : VBoxContainer
{
    public void Load()
    {
        var values = new Dictionary<string, string>();
        values = LoadRecursive("user://", values);

        // do the
        string text = JsonConvert.SerializeObject(values, new JsonSerializerSettings {
            TypeNameHandling = TypeNameHandling.All,
            Formatting = Formatting.Indented
        });

        GetNode<RichTextLabel>("text").Text = text;
        GetNode<Button>("copy").Connect("pressed", this, nameof(CopyCrap), new Godot.Collections.Array { text });
    }

    Dictionary<string, string> LoadRecursive(string path, Dictionary<string, string> values)
    {
        var dir = new Directory();
        if (dir.Open(path) == Error.Ok) {
            dir.ListDirBegin(true);
            string filename = dir.GetNext();
            while (filename != "") {
                if (dir.CurrentIsDir()) {
                    LoadRecursive($"{path}/{filename}", values);
                }
                else {
                    var f = new File();
                    f.Open($"{path}/{filename}", File.ModeFlags.Read);
                    values.Add($"{path}/{filename}", f.GetAsText());
                    f.Close();
                }
                filename = dir.GetNext();
            }
            dir.ListDirEnd();
        }
        else {
            GD.PushWarning($"Error deleting {path}");
        }
        return values;
    }

    public void CopyCrap(string J)
    {
        OS.Clipboard = J;
    }
}

}