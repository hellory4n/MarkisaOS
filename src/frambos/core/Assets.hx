package frambos.core;

import openfl.display.BitmapData;
using StringTools;

/**
 * Awesome class for using images (which are quite important in a 2d game, also it's just openfl's `Image` class)
 */
typedef Texture = BitmapData;

/**
 * Manages assets and shits.
 */
class Assets {
    /**
     * Loads a texture from the specified path. Start with `res://` so it doesn't crash and burn
     */
    public static function loadTexture(path: String): Texture {
        return openfl.Assets.getBitmapData(path.replace("res://", ""));
    }

    /**
     * Loads a text file from the specified path. Start with `res://` so it doesn't crash and burn
     */
     public static function loadText(path: String): String {
        return openfl.Assets.getText(path.replace("res://", ""));
    }
}