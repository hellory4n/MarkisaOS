package frambos.ecs;

import frambos.ecs.Piece;
import haxe.Constraints;
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
     * The name of the block. Should not have / or @ in it.
     */
    public var name: String = "New Block";
    var pieces: Array<Piece> = [];

    public function new() {}

    /**
     * Gets a piece attached to this block, or adds a new one if it's not there yet.
     */
    public function getPiece<T>(type: Class<T>): T {
        for (awesomePiece in pieces) {
            if (Std.isOfType(awesomePiece, type)) {
                return cast awesomePiece;
            }
        }

        // the piece doesn't exist, make a new one
        var newPiece = Type.createInstance(type, []);
        pieces.push(cast newPiece);
        return newPiece;
    }
}

/**
 * It's just a disguised string
 */
typedef BlockPath = String;