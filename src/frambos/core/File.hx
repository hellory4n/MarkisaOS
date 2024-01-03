package frambos.core;

import frambos.core.Result;
import sys.io.FileInput;
import lime.utils.Assets;
import sys.io.File;
import lime.system.System;

/**
 * Provides an API for reading user files.
 */
class File {
    var path: String;
    var isAsset: Bool;

    /**
     * Opens a file.
     * @param path The path of the file.
     */


    public function new(path: String) {
        this.path = path;
    }

    /**
     * Reads a file and returns the result as text, or a `FileError` if it fails.
     */
    public function read(): Result<String, FileError> {
        try {
            return Result.Success(sys.io.File.getContent(path));
        } catch (e) {
            return Result.Error(FileError.CouldntRead("Couldn't read $path"));
        }
    }

    /**
     * Overwrites all of the content in a file.
     * @param content 
     */
    public function write(content: String): Result<Bool, FileError> {
        try {
            return Result.Success(sys.io.File.getContent(path));
        } catch (e) {
            return Result.Error(FileError.CouldntRead("Couldn't read $path"));
        }
    }
}

enum FileError {
    CouldntRead(error: String);
    CouldntWrite(error: String);
}