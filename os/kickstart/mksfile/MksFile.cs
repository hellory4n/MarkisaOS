using System.Collections.Generic;
using Godot;
using Newtonsoft.Json;

namespace markisa.foundation {

public class MksFile<T> where T : new()
{
    /// <summary>
    /// The path of the file.
    /// </summary>
    public string Path { get; }
    /// <summary>
    /// The metadata for the file.
    /// </summary>
    public Dictionary<string, object> Metadata { get; set; } = new Dictionary<string, object>();
    /// <summary>
    /// The data the file stores.
    /// </summary>
    public T Data { get; set; }

    /// <summary>
    /// Loads a file at the given path.
    /// </summary>
    public MksFile(string path)
    {
        Path = path;
        var dir = new Directory();

        if (dir.FileExists(ProcessPath(Path))) {
            var file = new File();
            file.Open(ProcessPath(Path), File.ModeFlags.Read);
            Data = JsonConvert.DeserializeObject<T>(
                file.GetAsText(), new JsonSerializerSettings {
                    TypeNameHandling = TypeNameHandling.All,
                    Formatting = Formatting.Indented
                }
            );
        }
        else {
            Data = new T();
            Save();
        }
    }

    /// <summary>
    /// Saves this file, or creates a new one if it hasn't been saved yet.
    /// </summary>
    public void Save()
    {
        var dir = new Directory();
        dir.MakeDirRecursive(ProcessPath(Path).GetBaseDir());

        var file = new File();
        file.Open(ProcessPath(Path), File.ModeFlags.Write);
        file.StoreString(
            JsonConvert.SerializeObject(Data, new JsonSerializerSettings {
                TypeNameHandling = TypeNameHandling.All,
                Formatting = Formatting.Indented
            })
        );
        file.Close();
    }

    string ProcessPath(string path) {
        // fucking windows
        path = path.Replace(">", "").Replace(":", "").Replace("\\", "").Replace("?", "").Replace("*", "");
        return $"user://fs/{Frambos.CurrentUser}/{path}";
    }
}

}