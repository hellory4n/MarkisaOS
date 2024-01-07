package frambos.ecs;

import frambos.ecs.Block.BlockPath;
using StringTools;

/**
 * Manages all of the blocks and shit. Most of the stuff here should be used through the `Block` class instead.
 */
class BlockTree {
    /**
     * The parent of all blocks under the sun.
     */
    public static var root(default, set): Block;
    static var tree: BlockTreeItem;

    private static function set_root(value: Block): Block {
        if (root != null) {
        	return root;
        }
        tree.block = value;
        return root = value;
    }

    /**
     * Finds where a block is located on the block tree.
     * @param block The reference to the block.
     * @return The tree item with the block, or null if the block isn't on the tree yet.
     */
    public static function findByRef(block: Block): BlockTreeItem {
        return findByRefButItDoesRecursion(tree, block);
    }

    static function findByRefButItDoesRecursion(currentThingy: BlockTreeItem, block: Block): BlockTreeItem {
        if (currentThingy == null || currentThingy.block == block) {
            return currentThingy;
        }

        for (child in currentThingy.children) {
            var result: BlockTreeItem = findByRefButItDoesRecursion(child, block);
            if (result != null) {
                return result;
            }
        }

        return null;
    }

    /**
     * Adds a block to the tree. This also ensures the name is valid.
     */
    public static function addToTree(block: Block, parent: Block) {
        var parentItem = findByRef(parent);

        // very illegal characters (@ is used to ensure unique names)
        block.name = block.name.replace("/", "");
        block.name = block.name.replace("@", "");
        block.name = block.name.replace(".", "");

        // make sure there's nothing with that name
        for (child in parentItem.children) {
            if (child.block.name == block.name) {
                // oh noes it already exists, add garbage to the name
                block.name = '@@${block.name}${Math.random() * 1000000}';
                break;
            }
        }

        parentItem.children.push(new BlockTreeItem(block, parentItem));
    }

    public static function findByPath(path: BlockPath): Block {
        var hierarchy = path.split("/");

        var currentThingy = tree;
        for (thingy in hierarchy) {
            if (thingy == null || thingy == "") {
                continue;
            }

            currentThingy = currentThingy.children.filter(x -> x.block.name == thingy)[0];

            // oh noes it doesn't exist
            if (currentThingy == null) {
                return null;
            }
        }

        return currentThingy.block;
    }

    public static function getParent(block: Block): BlockTreeItem {
        var theFuckingTreeItem = findByRef(block) ?? return null;
        return theFuckingTreeItem.parent;
    }

    public static function getChildren(block: Block): Array<BlockTreeItem> {
        var theFuckingTreeItem = findByRef(block) ?? return null;
        return theFuckingTreeItem.children;
    }
}

/**
 * This is only used internally by the block tree, don't use it.
 */
class BlockTreeItem {
    public var block: Block;
    public var parent: BlockTreeItem;
    public var children: Array<BlockTreeItem> = [];

    public function new(block: Block, parent: BlockTreeItem) {
        this.block = block;
        this.parent = parent;
    }
}