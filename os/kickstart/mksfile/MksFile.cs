using System.Collections.Generic;
using Godot;
using Newtonsoft.Json;

namespace markisa.foundation {

public class MksFile<T> where T : new()
{
    /// <summary>
    /// The path of the file.
    /// </summary>
    public string Name { get; }
    /// <summary>
    /// The data the file stores.
    /// </summary>
    public T Data { get; set; }

    /// <summary>
    /// Loads a file at the given path.
    /// </summary>
    public MksFile(string name)
    {
        Name = name;
        var dir = new Directory();

        if (dir.FileExists(ProcessName(Name))) {
            var file = new File();
            file.Open(ProcessName(Name), File.ModeFlags.Read);
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
        dir.MakeDirRecursive(ProcessName(Name).GetBaseDir());

        var file = new File();
        file.Open(ProcessName(Name), File.ModeFlags.Write);
        file.StoreString(
            JsonConvert.SerializeObject(Data, new JsonSerializerSettings {
                TypeNameHandling = TypeNameHandling.All,
                Formatting = Formatting.Indented
            })
        );
        file.Close();
    }

    public static void Delete(string path)
    {
        var dir = new Directory();
        dir.Remove(ProcessName(path));
    }

    static string ProcessName(string name) {
        // fucking windows
        name = name.Replace(">", "").Replace(":", "").Replace("\\", "").Replace("?", "").Replace("*", "").Replace("/", "");
        return $"user://fs/{Frambos.CurrentUser}/{name}";
    }
}

}