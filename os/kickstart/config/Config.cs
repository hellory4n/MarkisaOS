using Godot;
using Newtonsoft.Json;
using System;

namespace markisa.foundation
{

/// <summary>
/// A container for data or some shit like that.
/// </summary>
class Config<T> where T : IConfigData, new()
{
    /// <summary>
    /// The data in this config.
    /// </summary>
    public T Data { get; set; }

    /// <summary>
    /// Saves the config and shit.
    /// </summary>
    public void Save()
    {
        File file = new File();
        file.Open(FigureOutTheFuckingPath(Data.GetFilename()), File.ModeFlags.Write);
        file.StoreString(
            JsonConvert.SerializeObject(Data, new JsonSerializerSettings {
                TypeNameHandling = TypeNameHandling.All,
                Formatting = Formatting.Indented
            })
        );
        file.Close();
    }

    /// <summary>
    /// It loads some bullshit, or creates a new one if it doesn't exist yet.
    /// </summary>
    public Config()
    {
        // temporary object so we can generate a path and load the data frfrfr
        T tempdata = new T();
        string path = FigureOutTheFuckingPath(tempdata.GetFilename());

        var dir = new Directory();
        if (dir.FileExists(path)) {
            var file = new File();
            file.Open(path, File.ModeFlags.Read);
            Data = JsonConvert.DeserializeObject<T>(
                file.GetAsText(), new JsonSerializerSettings {
                    TypeNameHandling = TypeNameHandling.All,
                    Formatting = Formatting.Indented
                }
            );
            file.Close();
        }
        else {
            var file = new File();
            file.Open(path, File.ModeFlags.Write);
            file.StoreString(
                JsonConvert.SerializeObject(tempdata, new JsonSerializerSettings {
                    TypeNameHandling = TypeNameHandling.All,
                    Formatting = Formatting.Indented
                })
            );
            file.Close();
        }
    }

    string FigureOutTheFuckingPath(string originalPath)
    {
        string m = "user://" + originalPath.Replace("%user", $"home/{Frambos.CurrentUser}");
        var directory = new Directory();
        directory.MakeDirRecursive(m.GetBaseDir());
        return m;
    }
}
}