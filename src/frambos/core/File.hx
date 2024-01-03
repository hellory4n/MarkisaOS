package frambos.core;

import frambos.core.Result;
import lime.system.System;

/**
 * Provides an API for reading user files.
 */
class File {
    var internalPath: String;
    public var path: String;
    var isAsset: Bool;

    /**
     * Opens a file.
     * @param path The path of the file. Make sure to start the path with `user://` if you're writing saves or whatever.
     */
    public function new(path: String) {
        this.path = path;
        this.internalPath = Directory.processPath(path);
    }

    /**
     * Reads a file and returns the result as text, or a `FileError` if it fails.
     */
    public function read(): Result<String, FileError> {
        try {
            return Success(sys.io.File.getContent(internalPath));
        } catch (e) {
            return Error(FileError.CouldntRead("Couldn't read $path ($internalPath), are you sure it exists?"));
        }
    }

    /**
     * Overwrites all of the content in a file, or creates a new file if it doesn't exist yet.
     */
    public function write(content: String): Error<FileError> {
        try {
            sys.io.File.saveContent(internalPath, content);
            return Success;
        } catch (e) {
            return Error(FileError.CouldntWrite("Couldn't write to $path ($internalPath)"));
        }
    }
}

enum FileError {
    CouldntRead(error: String);
    CouldntWrite(error: String);
}