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
        return CairoImageSurface.fromImage(texture);
    }

    /**
     * Draws an image surface (create one with `newImageSurface`) in the specified rect.
     */
    public function drawImage(imageSurface: ImageSurface, rect: Rect, rotation: Float, modulate: Color) {
        if (!block.visible) {
            return;
        }

        cairo.setSourceSurface(imageSurface, rect.position.x, rect.position.y);
        cairo.scale(rect.size.x, rect.size.y);
        cairo.rotate(MathExtensions.deg2rad(rotation));
        cairo.setSourceRGBA(modulate.r, modulate.g, modulate.b, modulate.a);
        cairo.paint();
    }
}

/**
 * An image that can actually be used for rendering stuff.
 */
typedef ImageSurface = CairoImageSurface;