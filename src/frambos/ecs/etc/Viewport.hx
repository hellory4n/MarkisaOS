package frambos.ecs.etc;

import frambos.core.Project;
import frambos.util.Vec2;
import lime.graphics.CairoRenderContext;
import frambos.graphics.instructions.IGraphicsInstruction;
import frambos.graphics.RenderDevice;

/**
 * It renders stuff.
 */
class Viewport extends Piece {
    public var instructions: Array<IGraphicsInstruction> = [];
    /**
     * If `true`, the children will be scaled to the size specified in `originalSize`. Else, it will be clipped by the viewport's rect.
     */
    public var scale = false;
    /**
     * The original size the children are rendered at, used for scaling it.
     */
    public var originalSize: Vec2;

    @:allow(Main)
    static var cairo: CairoRenderContext;

    public override function draw(device: RenderDevice) {
        cairo.save();
        

        /*if (scale) {
            final scaleX = rect.size.x / originalSize.x;
            final scaleY = rect.size.y / originalSize.y;
            cairo.scale(scaleX, scaleY);
        }*/

        for (instruction in instructions) {
            instruction.draw(cairo);
        }

        /*if (!scale) {
            cairo.rectangle(rect.position.x, rect.position.y, rect.size.x, rect.size.y);
            cairo.clip();
        }*/

        cairo.restore();
    }
}