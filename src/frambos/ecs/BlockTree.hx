package frambos.ecs;

/**
 * Manages all of the blocks and shit.
 */
class BlockTree {
    public static var root(default, set): Block;
    static var tree: BlockTreeItem;

    private static function set_root(value: Block): Block {
        if (root != null) {
        	return root;
        }
        tree.block = value;
        return root = value;
    }

    public static function findByRef(block: Block) {

    }

    static function findButItLoopsOverTheTreeAndDoesRecursion(currentThingy: BlockTreeItem, block: Block): BlockTree {
    /**
     * if (currentNode == null || currentNode.ObjectRef == obj)
    {
        return currentNode;
    }

    foreach (var child in currentNode.Children)
    {
        var result = TraverseTree(child, obj);
        if (result != null)
        {
            return result;
        }
    }

    return null;
     */
        if (currentThingy == null || currentThingy.block =)
    }

    public static function addToTree(block: Block, parent: Block) {
    }
}

class BlockTreeItem {
    public var block: Block;
    public var children: Array<BlockTreeItem> = [];
}