package frambos.ecs;

/**
 * Things you attach to blocks to make them do something.
 */
class Piece {
    /**
     * The block this piece is attached to.
     */
    public final block: Block;
    public final CLASS = new Piece(null);

    public function new(block: Block) {
        this.block = block;
    }
}