namespace frambos.android;
using System.IO;
using Android.Content.Res;

/// <summary>
/// Helper to assist with file loading.
/// </summary>
public static class FileManager {
    internal static AssetManager AssetManager;

    public static string LoadString(string path) {
        using StreamReader s = new(AssetManager.Open(path));
        return s.ReadToEnd();
    }

    public static Stream OpenStream(string path) {
        return AssetManager.Open(path);
    }
}