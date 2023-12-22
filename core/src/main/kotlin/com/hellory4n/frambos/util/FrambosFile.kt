package com.hellory4n.frambos.util

import com.badlogic.gdx.Gdx
import com.badlogic.gdx.files.FileHandle

/** A low-level-ish way of opening files. */
class FrambosFile {
    private lateinit var internalFile: FileHandle
    lateinit var path: String

    /**
     * @return The content of the file as text, or an empty string if the file doesn't exist.
     */
    fun readString(): String {
        return try {
            internalFile.readString()
        } catch (e: Exception) {
            warn("File \"$path\" doesn't exist, returning an empty string")
            ""
        }
    }

    /**
     * @return The content of the file as bytes, or an empty array if the file doesn't exist.
     */
    fun readBytes(): ByteArray {
        return try {
            return internalFile.readBytes()
        } catch (e: Exception) {
            warn("File \"$path\" doesn't exist, returning an empty array.")
            return ByteArray(0)
        }
    }

    /**
     * Overwrites the content of the file, and creates a new file if it doesn't exist yet.
     */
    fun overwriteString(string: String) {
        internalFile.writeString(string, false)
        println(internalFile.file().absolutePath)
    }

    /**
     * Appends a string to the end of the file, and creates a new file if it doesn't exist yet.
     */
    fun appendString(string: String) {
        internalFile.writeString(string, true)
    }

    /**
     * Overwrites the content of the file, and creates a new file if it doesn't exist yet.
     */
    fun overwriteBytes(bytes: ByteArray, offset: Int, length: Int) {
        internalFile.writeBytes(bytes, offset, length, false)
    }

    /**
     * Appends a string to the file, and creates a new file if it doesn't exist yet.
     */
    fun appendBytes(bytes: ByteArray, offset: Int, length: Int) {
        internalFile.writeBytes(bytes, offset, length, true)
    }

    companion object {
        /** Open a file.
         *  Use `res://` at the beginning if it's an internal file, or `user://` if you need to change it later.
         *  If the file doesn't exist, writing to the file will automatically create it.
         */
        fun open(s: String): FrambosFile {
            return FrambosFile().apply {
                internalFile = processPath(s)
                path = s
            }
        }

        /**
         * @return whether the file specified exists.
         */
        fun exists(path: String): Boolean {
            return processPath(path).exists()
        }

        /**
         * @return whether the path is a directory.
         */
        fun isDirectory(path: String): Boolean {
            return processPath(path).isDirectory
        }

        /**
         * Lists the files and folders ([isDirectory]) inside the path specified
         */
        fun list(folderPath: String): ArrayList<FrambosFile> {
            val coolFolder: FileHandle = processPath(folderPath)
            val returnThingy = ArrayList<FrambosFile>()
            for (coolFile in coolFolder.list()) {
                returnThingy.add(FrambosFile().apply {
                    internalFile = coolFile
                    path = coolFile.name()
                })
            }
            return returnThingy
        }

        /**
         * Process a path so libGDX can use it.
         */
        private fun processPath(path: String): FileHandle {
            return if (path.startsWith("res://")) {
                Gdx.files.internal(path.replace("res://", ""))
            } else {
                Gdx.files.local(path.replace("user://", ""))
            }
        }
    }
}
