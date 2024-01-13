package frambos.graphics.instructions;

import lime.graphics.CairoRenderContext;

/**
 * It's a instruction for viewports so they can do real rendering bullshit.
 */
interface IGraphicsInstruction {
    function draw(cairo: CairoRenderContext): Void;
}