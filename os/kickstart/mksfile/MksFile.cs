using System.Collections.Generic;
using Godot;

namespace markisa.foundation {

public class MksFile<T>
{
    /// <summary>
    /// The path of the file.
    /// </summary>
    public string Path { get; private set; }
    /// <summary>
    /// The metadata for the file.
    /// </summary>
    public Dictionary<string, object> Metadata { get; set; } = new Dictionary<string, object>();
    /// <summary>
    /// The data the file stores.
    /// </summary>
    public T Data { get; set; }

    /// <summary>
    /// Saves this file, or creates a new one if it hasn't been saved yet.
    /// </summary>
    public void Save()
    {
        var dir = new Directory();
        dir.MakeDirRecursive($"user://home/{Frambos.CurrentUser}/files/");

        var file = new File();
        //file.Open($"user://home/{Frambos.CurrentUser}/files")
    }
}

}