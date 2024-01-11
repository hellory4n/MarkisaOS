package frambos.ecs;

import frambos.ecs.Block.BlockPath;
import frambos.graphics.RenderDevice;
import frambos.core.Assets;
import frambos.util.Rect;
import frambos.util.Color;

/**
 * Things you attach to blocks to make them do something.
 */
class Piece {
    /**
     * The block this piece is attached to.
     */
    public final block: Block;
    /**
     * The rect of the block.
     */
    public var rect(get, set): Rect;
    /**
     * The rectangle of the block, in degrees.
     */
    public var rotation(get, set): Float;
    /**
     * The color of the block, but only affects it when it's drawing something. Use white if you don't want to change the color.
     */
    public var modulate(get, set): Color;

    public function new(block: Block) {
        this.block = block;
    }

    /**
     * Called when all of the block's children have been initialized and the engine has finished setting up everything.
     */
    public function ready() {}
    /**
     * Called right before `ready`, only difference is that it has a render device. This function should only be used by the engine.
     */
    public function prepareDraw(device: RenderDevice) {}
    /**
     * Called every frame.
     * @param delta Represents the elapsed time between consecutive frames in seconds, so moving things are consistent between frames, e.g. `velocity += speed * delta`
     */
    public function update(delta: Float) {}
    /**
     * Called every frame when it's time to render the game. This function should only be used by the engine.
     */
    public function draw(device: RenderDevice) {}

    /**
     * Loads a texture from the specified path. Start with `res://` so it doesn't crash and burn
     */
    public function loadTexture(path: String): Texture {
        return Assets.loadTexture(path);
    }

    /**
     * Loads a texture from the specified path. Start with `res://` so it doesn't crash and burn
     */
     public function loadText(path: String): String {
        return Assets.loadText(path);
    }

    function set_rect(value: Rect): Rect {
        return block.rect = value;
    }

	function get_rect(): Rect {
		return block.rect;
	}

    function set_rotation(value: Float): Float {
        return block.rotation = value;
    }

	function get_rotation(): Float {
		return block.rotation;
	}

    function set_modulate(value: Color): Color {
        return block.modulate = value;
    }

	function get_modulate(): Color {
		return block.modulate;
	}

    /**
     * Adds a block as a child of this block. This also ensures the name is valid.
     */
    public function addChild(child: Block) {
        block.addChild(child);
    }

    /**
     * Gets a block based on its path, or null if it doesn't exist.
     * 
     * Starting with `/` means it's absolute, e.g. `/root/someNode`
     * 
     * You can put 1 or more `../` at the beginning to indicate it's relative to a parent.
     * 
     * No prefix or a `./` prefix means it's relative to the current block.
     */
    public function getBlock(path: BlockPath): Block {
        return block.getBlock(path);
    }
}