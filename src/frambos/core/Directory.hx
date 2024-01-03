package frambos.core;

import sys.FileSystem;
import frambos.core.File.FileError;
import lime.system.System;
using StringTools;

/**
 * Provides static functions for doing file stuff.
 */
class Directory {
    /**
     * Processes a path to be valid. If it starts with `user://`, it goes to the application storage directory.
     */
    public static function processPath(path: String): String {
        if (path.startsWith("user://")) {
            return System.applicationStorageDirectory + path.substr(7);
        } else {
            return path;
        }
    }

    /**
     * Copies a file and its contents. If the destination already exists, its contents get overwritten.
     */
    public static function copy(from: String, to: String): Error<FileError> {
        try {
            sys.io.File.copy(processPath(from), processPath(to));
            return Success;
        } catch (e) {
            return Error(FileError.CouldntWrite("Couldn't copy from $from to $to"));
        }
    }

    /**
     * Creates a directory at the specified path. Please note that this function is recursive, so if you try to do `Directory.makeDir("user://new/directory")`, both "new" and "directory" folders will be created.
     */
    public static function makeDir(path: String): Error<DirectoryError> {
        try {
            FileSystem.createDirectory(processPath(path));
            return Success;
        } catch (e) {
            return Error(DirectoryError.CouldntMakeDir("Couldn't make directories $path"));
        }
    }

    /**
     * If `true`, the path specified is a directory.
     */
    public static function isDir(path: String): Result<Bool, DirectoryError> {
        try {
            return Success(FileSystem.isDirectory(processPath(path)));
        } catch (e) {
            return Error(DirectoryError.NotFound("Couldn't access $path"));
        }
    }

    /**
     * Deletes the specified file or directory.
     */
    public static function delete(path: String): Error<DirectoryError> {
        var isdir: Result<Bool, DirectoryError> = isDir(path);
        var actualIsdir = false;

        switch (isdir) {
            case Success(data): actualIsdir = data;
            case Error(error): return Error(DirectoryError.CouldntDelete("Couldn't delete $path"));
        }
        
        if (actualIsdir) {
            try {
                FileSystem.deleteDirectory(processPath(path));
            } catch (e) {
                return Error(DirectoryError.CouldntDelete("Couldn't delete $path"));
            }
        } else {
            try {
                FileSystem.deleteFile(processPath(path));
            } catch (e) {
                return Error(DirectoryError.CouldntDelete("Couldn't delete $path"));
            }
        }

        return Success;
    }

    /**
     * Returns the names of all files and directories in the directory specified by path. `.` and `..` are not included in the output.
     */
    public static function listDir(path: String): Result<Array<String>, DirectoryError> {
        try {
            return Success(FileSystem.readDirectory(processPath(path)));
        } catch (e) {
            return Error(DirectoryError.CouldntList("Couldn't list $path"));
        }
    }

    /**
     * Moves/renames a file or directory. 
     */
    public static function move(from: String, to: String): Error<DirectoryError> {
        try {
            FileSystem.rename(processPath(from), processPath(to));
            return Success;
        } catch (e) {
            return Error(DirectoryError.CouldntMove("Couldn't move from $from to $to"));
        }
    }
}

enum DirectoryError {
    CouldntMakeDir(error: String);
    NotFound(error: String);
    CouldntDelete(error: String);
    CouldntMove(error: String);
    CouldntList(error: String);
}