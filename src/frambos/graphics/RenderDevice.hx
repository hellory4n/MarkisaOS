package frambos.graphics;

import frambos.graphics.instructions.RenderImage;
import frambos.ecs.etc.Viewport;
import frambos.util.MathExtensions;
import frambos.util.Rect;
import frambos.util.Vec2;
import lime.graphics.cairo.CairoImageSurface;
import frambos.core.Assets;
import lime.graphics.CairoRenderContext;
import frambos.ecs.Block;

/**
 * Used by pieces to do their graphics bonanza, mostly just a wrapper around [Cairo](https://www.cairographics.org/) functions with some utilities to help making fancy effects.
 */
class RenderDevice {
    /**
     * The block
     */
    public var block: Block;

    public function new(block: Block) {
        this.block = block;
    }

    /**
     * Creates an image that can be actually used for rendering stuff.
     */
    public function newImageSurface(texture: Texture): ImageSurface {
        texture.format = BGRA32;
        texture.premultiplied = true;
        return ImageSurface.fromImage(texture);
    }

    /**
     * Draws an image surface (create one with `newImageSurface`),
     * @param imageSurface The image surface to draw (create one with `newImageSurface`)
     * @param rect The rect to draw the image on
     * @param rotation The rotation of the image, in degrees.
     * @param alpha The transparency on the image on a scale from 0 to 1
     * @param origin Defines the origin point of the image, with the x and y going from 0 to 1, aligned to the top-left corner (so 0, 0 would be the top-left).
     */
    public function drawImage(imageSurface: ImageSurface, rect: Rect, rotation: Float, alpha: Float, origin: Vec2) {
        if (!block.visible) {
            return;
        }

        block.getViewport().getPiece(Viewport).instructions.push(
            new RenderImage(imageSurface, rect, rotation, alpha, origin)
        );
    }
}

/**
 * An image that can actually be used for rendering stuff.
 */
typedef ImageSurface = CairoImageSurface;