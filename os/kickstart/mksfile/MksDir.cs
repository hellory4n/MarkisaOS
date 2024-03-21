using System;
using System.Linq;
using Godot;

namespace markisa.foundation {

public static class MksDir
{
    /// <summary>
    /// Permanently deletes the target file or an empty directory. The argument can be relative to the current directory, or an absolute path.
    /// </summary>
    /// <returns><c>true</c> if the operation succeeded, <c>false</c> otherwise</returns>
    public static bool Delete(string path)
    {
        var dir = new Directory();
        Error m = dir.Remove(ProcessPath(path));
        return m == Error.Ok;
    }

    /// <summary>
    /// Copies from <c>from</c> to <c>to</c>. If the destination already exists, it will be overwritten. Only files can be copied.
    /// </summary>
    /// <returns><c>true</c> if the operation succeeded, <c>false</c> otherwise</returns>
    public static bool Copy(string from, string to)
    {
        var dir = new Directory();
        Error m = dir.Copy(ProcessPath(from), ProcessPath(to));
        return m == Error.Ok;
    }
    
    /// <summary>
    /// If <c>true</c>, the target file or directory exists.
    /// </summary>
    public static bool Exists(string path)
    {
        var dir = new Directory();
        return dir.FileExists(ProcessPath(path)) || dir.DirExists(ProcessPath(path));
    }

    /// <summary>
    /// Returns an array of the relative paths of every file or folder inside the target folder. If <c>skipHidden</c> is true, every file or folder that starts with "." is skipped, similar to UNIX-like systems.
    /// </summary>
    public static string[] ListFiles(string dirPath)
    {
        string[] paths = {};
        var dir = new Directory();
        dir.Open(ProcessPath(dirPath));
        dir.ListDirBegin(true);

        string filename = null;
        while (filename != "") {
            filename = dir.GetNext();

            paths = paths.Append(filename).ToArray();
        }

        // the last item is always ""
        return paths.Take(paths.Length - 1).ToArray();
    }

    /// <summary>
    /// Recursively creates directories. For example, <c>/Foo/Bar</c> would create a Bar folder inside a Foo folder.
    /// </summary>
    public static void MakeDir(string path)
    {
        var dir = new Directory();
        dir.MakeDirRecursive(ProcessPath(path));
    }

    /// <summary>
    /// Moves (renames) the file or directory from <c>from</c> to <c>to</c>. If the target file or directory already exists, it will be overwritten.
    /// </summary>
    /// <returns><c>true</c> if the operation succeeded, <c>false</c> otherwise</returns>
    public static bool Move(string from, string to)
    {
        var dir = new Directory();
        Error m = dir.Rename(ProcessPath(from), ProcessPath(to));
        return m == Error.Ok;
    }

    /// <summary>
    /// If <c>true</c>, the target file is a directory. Else, it's a file. Please note that it also returns false if the path doesn't exist, so remember to check that with <c>MksDir.Exists()</c> first.
    /// </summary>
    /// <param name="path"></param>
    /// <returns></returns>
    public static bool IsDir(string path)
    {
        var dir = new Directory();
        if (dir.FileExists(ProcessPath(path))) {
            return false;
        }
        else if (dir.DirExists(ProcessPath(path))) {
            return true;
        }
        else {
            return false;
        }
    }

    static string ProcessPath(string path) {
        // fucking windows
        path = path.Replace(">", "").Replace(":", "").Replace("\\", "").Replace("?", "").Replace("*", "");
        return $"user://fs/{Frambos.CurrentUser}/{path}";
    }
}

}