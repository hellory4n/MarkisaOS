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
            DisplayName = "Ghosts On Wheels",
            Author = "Koni Development",
            Icon = "res://apps/koni/ghostsOnCars/dockicon.png",
            Executable = "res://apps/koni/ghostsOnCars/app.tscn",
            AppCategories = new MksPackage.Categories[] {
                MksPackage.Categories.Games
            }
        };

        GD.Print(JsonConvert.SerializeObject(serializee));
    }
}

}