package frambos.core;

import frambos.ecs.BlockTree;
import frambos.ecs.Block;

class Init {
    public function new() {
        // create the block tree
        var root = new Block();
        root.name = "root";
        BlockTree.root = root;
    }
}