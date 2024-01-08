package frambos.core;

import lime.graphics.Image;
using StringTools;

/**
 * Awesome class for using images (which are quite important in a 2d game, also it's just lime's `Image` class)
 */
typedef Texture = Image;

/**
 * Manages assets and shits.
 */
class Assets {
    /**
     * Loads a texture from the specified path. Start with `res://` so it doesn't crash and burn
     */
    public static function loadTexture(path: String): Texture {
        return lime.utils.Assets.getImage(path.replace("res://", ""));
    }
}