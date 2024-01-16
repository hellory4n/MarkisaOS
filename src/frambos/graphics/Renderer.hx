package frambos.graphics;

import frambos.core.Assets.Texture;
import openfl.display.Bitmap;

/**
 * Represents an image for the renderer and stuff :)
 */
typedef ImageRender = Bitmap;

class Renderer {
    @:allow(Main)
    static var main: Main;

    
    public static function addImage(oldRender: ImageRender, texture: Texture): ImageRender {
        if (oldRender != null) {
            main.removeChild(oldRender);
        }

        var lol = new ImageRender(texture);
        main.addChild(lol);

        return lol;
    }
}