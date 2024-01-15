package frambos.core;

import openfl.filesystem.FileStream;
import openfl.filesystem.FileMode;
import frambos.core.Result;

/**
 * Provides an API for reading user files.
 */
class File {
    var internalPath: openfl.filesystem.File;
    public var path: String;
    var _mode: openfl.filesystem.FileMode;

    /**
     * Opens a file.
     * @param path The path of the file. Make sure to start the path with `user://` if you're writing saves or whatever.
     * @param mode The mode to open the file in. See `FileMode`.
     */
    public function new(path: String, mode: FileMode) {
        this.path = path;
        internalPath = Directory.processPath(path);
        _mode = cast mode;
    }

    /**
     * Reads a file as UTF-8 and returns the result as text, or `Couldn't read file` if it fails.
     */
    public function read(): Result<String> {
        try {
            var lol = new FileStream();
            lol.open(internalPath, _mode);
            var ghhghg = lol.readUTFBytes(lol.bytesAvailable);
            lol.close();
            return Success(ghhghg);
        } catch (e) {
            return Error("Couldn't read file");
        }
    }

    /**
     * Writes a UTF-8 string to a file, and returns `Couldn't write to file` if it fails.
     */
    public function write(content: String): Error {
        try {
            var lol = new FileStream();
            lol.open(internalPath, _mode);
            lol.writeUTFBytes(content);
            lol.close();
            return Success;
        } catch (e) {
            return Error("Couldn't write to file");
        }
    }
}

/**
 * Some stuff for defining how files should be used or somethbjdjhsrkhr.
 */
enum abstract FileMode(String) to String {
    /**
     * Opens the file in write mode, if it exists, any new data gets written to the end, but if it doesn't, a new file is created.
     */
    var APPEND = "append";
    /**
     * Opens the file in read-only mode. The file must exist, missing files are not created.
     */
    var READ = "read";
    /**
     * Opens the file in read/write mode. If it doesn't exist, a new file is created.
     */
    var UPDATE = "update";
    /**
     * Opens a file in write-only mode. If it exists, all existing data gets overwritten, and if it doesn't, a new file is created.
     */
    var WRITE = "write";
}