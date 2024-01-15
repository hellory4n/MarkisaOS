package frambos.core;

import openfl.filesystem.File;
using StringTools;

/**
 * Provides static functions for doing file stuff.
 */
class Directory {
    /**
     * Processes a path and stuff.
     */
    public static function processPath(path: String): File {
        return File.applicationStorageDirectory.resolvePath(path.substr(7));
    }

    /**
     * Copies a file and its contents. If the destination a
     * lready exists, its contents get overwritten. If it fails, it returns `Couldn't copy`
     */
    public static function copy(from: String, to: String): Error {
        try {
            processPath(from).copyTo(processPath(to), true);
            return Success;
        } catch (e) {
            return Error("Couldn't copy");
        }
    }

    /**
     * Creates a directory at the specified path. Please note that this function is recursive, so if you try to do `Directory.makeDir("user://new/directory")`, both `new` and `directory` folders will be created. If it fails, it returns `Couldn't make directory`
     */
    public static function makeDir(path: String): Error {
        try {
            processPath(path).createDirectory();
            return Success;
        } catch (e) {
            return Error("Couldn't make directory");
        }
    }

    /**
     * If `true`, the path specified is a directory. If it fails, it returns `Couldn't access`
     */
    public static function isDir(path: String): Result<Bool> {
        try {
            return Success(processPath(path).isDirectory);
        } catch (e) {
            return Error("Couldn't access");
        }
    }

    /**
     * Deletes the file, or returns `Couldn't delete file` if it fails.
     */
    public static function deleteFile(path: String): Error {
        try {
            processPath(path).deleteFile();
            return Success;
        } catch (e) {
            return Error("Couldn't delete file");
        }
    }

    /**
     * Deletes a directory, or returns `Couldn't delete directory` if it fails.
     * @param deleteContents If `true`, the contents of the directory (including subdirectories and their contents) gets deleted. If `false` and the folder has contents, the function fails.
     */
    public static function deleteDir(path: String, deleteContents: Bool): Error {
        try {
            processPath(path).deleteDirectory(deleteContents);
            return Success;
        } catch (e) {
            return Error("Couldn't delete directory");
        }
    }

    /**
     * Returns the names of all files and directories in the directory specified by path, but not the contents of its subdirectories. `.` and `..` are not included in the output. If it fails, `Couldn't list directory` is returned
     */
    public static function listDir(path: String): Result<Array<String>> {
        try {
            var jjhjhhjkhjk = processPath(path);
            var heheheha = jjhjhhjkhjk.getDirectoryListing();
            var lol: Array<String> = [];
            for (p in heheheha) {
                lol.push(jjhjhhjkhjk.getRelativePath(p));
            }

            return Success(lol);
        } catch (e) {
            return Error("Couldn't list directory");
        }
    }

    /**
     * Moves/renames a file or directory, or returns `Couldn't move` if it fails.
     * @param overwrite If `false`, the move fails if the target file already exists. If true, the operation overwrites any existing file or directory of the same name.
     */
    public static function move(from: String, to: String, overwrite: Bool): Error {
        try {
            processPath(from).moveTo(processPath(to));
            return Success;
        } catch (e) {
            return Error("Couldn't move");
        }
    }
}