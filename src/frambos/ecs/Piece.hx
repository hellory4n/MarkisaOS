package frambos.ecs;

/**
 * Things you attach to blocks to make them do something.
 */
class Piece {
    /**
     * The block this piece is attached to.
     */
    public final block: Block;

    public function new(block: Block) {
        this.block = block;
    }

    /**
     * Called when all of the block's children have been initialized.
     */
    public function ready() {}
    /**
     * Called every frame.
     * @param delta Represents the elapsed time between consecutive frames, so moving things are consistent between frames, e.g. `velocity += speed * delta`
     */
    public function update(delta: Float) {}
    /**
     * Called every frame when it's time to render the game. This function should only be used by the engine.
     */
    public function draw() {}
}