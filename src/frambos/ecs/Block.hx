package frambos.ecs;

import frambos.util.Rect;

/**
 * Blocks are the building blocks of Frambos.
 */
class Block {
    /**
     * The rect of the block.
     */
    public var rect = new Rect(0, 0, 0, 0);
    /**
     * The rectangle of the block, in degrees.
     */
    public var rotation: Float = 0;
    /**
     * The color of the block, but only affects it when it's drawing something. Use 0xFFFFFFFF if you don't want to change the color.
     */
    public var modulate: Int = 0xFFFFFFFF;
    /**
     * The name of the block. Should not have slashes in it.
     */
    public var name: String = "New Block";
    var pieces: Array<Piece> = [];
    var children: Array<Block> = [];
    var parent: Block = BlockTree.root;

    public function new() {}

    /**
     * Gets a piece attached to this block, or adds a new one if it's not there yet.
     */
    /*public function getPiece<T: Piece>() {
        for (awesomePiece in pieces) {
            if (awesomePiece is T) {
                return awesomePiece;
            }
        }

        // the piece doesn't exist, make a new one
        var newPiece = new T(this);
        pieces.push(newPiece);
        return newPiece;
    }*/
}