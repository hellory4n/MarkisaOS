package frambos.ecs;

import frambos.ecs.BlockTree.BlockTreeItem;
import frambos.ecs.Piece;
import frambos.util.Rect;
using StringTools;

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

    /**
     * Returns a list of direct children of this block.
     */
    public function getChildren(): Array<Block> {
        var lol = BlockTree.findByRef(this).children;

        var lmao: Array<Block> = [];
        for (xd in lol) {
            lmao.push(xd.block);
        }

        return lmao;
    }

    /**
     * Adds a block as a child of this block. This also ensures the name is valid.
     * 
     */
    public function addChild(child: Block) {
        BlockTree.addToTree(child, this);
    }

    /**
     * Gets the direct parent of this block.
     */
    public function getParent(): Block {
        return BlockTree.getParent(this).block;
    }

    /**
     * If `true`, the block currently has the specified piece attached to it.
     */
    public function hasPiece<T>(type: Class<T>): Bool {
        for (awesomePiece in pieces) {
            if (Std.isOfType(awesomePiece, type)) {
                return true;
            }
        }
        return false;
    }

    /**
     * Returns the full path of a block.
     */
    public function getPath(): BlockPath {
        var path = "";
        var currentThingy: Block = this;
        while (currentThingy != null) {
            path = '$currentThingy/$path';
            currentThingy = currentThingy.getParent();
        }

        return '/$path';
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
        var isRelative = true;
        var isParentThingy = false;
        var isAbsolute = true;

        // how many getParents() do we need?
        var howManyParentsShouldBeGotten = 0;
        while (path.startsWith("../")) {
            howManyParentsShouldBeGotten++;
            path = path.substring(3);

            isRelative = false;
            isParentThingy = true;
            isAbsolute = false;
        }

        // get the parents
        var parent = this;
        for (i in 0...howManyParentsShouldBeGotten) {
            parent = parent.getParent();
        }

        if (path.startsWith("/")) {
            isRelative = false;
            isParentThingy = false;
            isAbsolute = true;
        }

        path = path.replace("./", "");

        // stop fucking around with the path and actually get the block
        var lol: Array<String> = path.split("/");
        if (isRelative) {
            return BlockTree.findByPath('${getPath()}/${lol[lol.length-1]}');
        } else if (isParentThingy) {
            return BlockTree.findByPath('${parent.getPath()}/${lol[lol.length-1]}');
        } else {
            return BlockTree.findByPath(path);
        }
    }

    /**
     * If `true`, there is a block in the path specified.
     * 
     * Starting with `/` means it's absolute, e.g. `/root/someNode`
     * 
     * You can put 1 or more `../` at the beginning to indicate it's relative to a parent.
     * 
     * No prefix or a `./` prefix means it's relative to the current block.
     */
    public function exists(path: BlockPath): Bool {
        return getBlock(path) != null;
    }

    /**
     * Moves this block to the end of its parent's children list. Probably useful when making UIs
     */
    public function moveToForeground() {
        var lol = BlockTree.findByRef(getParent());
        var jkgjdgj = BlockTree.findByRef(this);
        lol.children.remove(jkgjdgj);
        lol.children.push(jkgjdgj);
    }
}

/**
 * It's just a disguised string
 */
typedef BlockPath = String;