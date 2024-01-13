package frambos.graphics.instructions;

import frambos.util.MathExtensions;
import lime.graphics.cairo.CairoImageSurface;
import lime.graphics.CairoRenderContext;
import frambos.util.Vec2;
import frambos.util.Rect;

class RenderImage implements IGraphicsInstruction {
    var surface: CairoImageSurface;
    var rect: Rect;
    var rotation: Float;
    var alpha: Float;
    var origin: Vec2;

    // quite the mouthful
    public function new(surface: CairoImageSurface, rect: Rect, rotation: Float, alpha: Float, origin: Vec2) {
        this.surface = surface;
        this.rect = rect;
        this.rotation = rotation;
        this.alpha = alpha;
        this.origin = origin;
    }

    public function draw(cairo: CairoRenderContext) {
        cairo.translate(rect.position.x + (rect.size.x / 2), rect.position.y + (rect.size.y / 2));
        cairo.rotate(MathExtensions.deg2rad(rotation));
        cairo.scale(rect.size.x / surface.width, rect.size.y / surface.height);
        cairo.translate(-origin.x * surface.width, -origin.y * surface.height);
        cairo.setSourceSurface(surface, 0, 0);
        cairo.paintWithAlpha(alpha);
    }
}