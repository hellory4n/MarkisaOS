package frambos.graphics;

import frambos.ecs.Block;

/**
 * Used by pieces to do their graphics bonanza.
 */
class RenderingDevice {
    /**
     * The block
     */
    public var block: Block;

    public function new(block: Block) {
        this.block = block;
    }
}