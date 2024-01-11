package frambos.graphics;

import frambos.util.MathExtensions;
import frambos.util.Color;
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
    @:allow(Main)
    static var cairo: CairoRenderContext;

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
        return CairoImageSurface.fromImage(texture);
    }

    /**
     * Draws an image surface (create one with `newImageSurface`),
     * @param imageSurface The image surface to draw (create one with `newImageSurface`)
     * @param rect The rect to draw the image on
     * @param rotation The rotation of the image, in degrees.
     * @param modulate A color object to change the color of the image.
     * @param origin Defines the origin point of the image, with the x and y going from 0 to 1, aligned to the top-left corner (so 0, 0 would be the top-left).
     */
    public function drawImage(imageSurface: ImageSurface, rect: Rect, rotation: Float, modulate: Color, origin: Vec2) {
        if (!block.visible) {
            return;
        }

        origin = origin.clamp(new Vec2(0, 0), new Vec2(1, 1));

        cairo.save();

        // set the origin point
        cairo.translate(rect.position.x + (rect.size.x * origin.x), rect.position.y + (rect.size.y * origin.y));

        cairo.rotate(MathExtensions.deg2rad(rotation));
        cairo.scale(rect.size.x, rect.size.y);
        cairo.setSourceSurface(imageSurface, -origin.x, -origin.y);
        cairo.setSourceRGBA(modulate.r, modulate.g, modulate.b, modulate.a);

        cairo.paint();
        cairo.restore();
    }
}

/**
 * An image that can actually be used for rendering stuff.
 */
typedef ImageSurface = CairoImageSurface;