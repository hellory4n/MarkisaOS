package frambos.ecs;

import frambos.util.Vec2;
import frambos.ecs.Block.BlockPath;
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
     * The position of the block.
     */
    public var position(get, set): Vec2;
    public var size(get, set): Vec2;
    /**
     * The rect of the block.
     */
    public var rect(get, never): Rect;
    /**
     * The rectangle of the block, in degrees.
     */
    public var rotation(get, set): Float;
    /**
     * The color of the block, but only affects it when it's drawing something. Use white if you don't want to change the color.
     */
    public var alpha(get, set): Float;

    public function new(block: Block) {
        this.block = block;
    }

    /**
     * Called when all of the block's children have been initialized and the engine has finished setting up everything.
     */
    public function ready() {}
    /**
     * Called every frame.
     * @param delta Represents the elapsed time between consecutive frames in seconds, so moving things are consistent between frames, e.g. `velocity += speed * delta`
     */
    public function update(delta: Float) {}
    /**
     * Called every frame when it's time to render the game. This function should only be used by the engine.
     */
    public function draw() {}

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

	function get_rect(): Rect {
		return block.rect;
	}

    function set_rotation(value: Float): Float {
        return block.rotation = value;
    }

	function get_rotation(): Float {
		return block.rotation;
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

    function set_position(value: Vec2): Vec2 {
        return block.position = value;
    }

	function get_position(): Vec2 {
		return block.position;
	}

    function set_size(value: Vec2): Vec2 {
        return block.size = value;
    }

	function get_size(): Vec2 {
		return block.size;
	}

    function set_alpha(value: Float): Float {
        return block.alpha = value;
    }

	function get_alpha(): Float {
		return block.alpha;
	}
}