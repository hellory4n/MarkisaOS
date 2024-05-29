using Godot;
using markisa.foundation;
using Newtonsoft.Json;
using System;

namespace markisa.sdk {

/// <summary>
/// this is just for getting serialized json files for downloading
/// </summary>
public class SomeEpicSerializer5000 : Node2D
{
    public override void _Ready()
    {
        var serializee = new MksPackage {
            DisplayName = "FasterPC",
            Author = "Creator of FasterPC",
            Icon = "res://apps/fasterpc/dockicon.png",
            Executable = "res://apps/fasterpc/app.tscn",
            AppCategories = new MksPackage.Categories[] {
                MksPackage.Categories.Utilities
            }
        };

        GD.Print(JsonConvert.SerializeObject(serializee));
    }
}

}