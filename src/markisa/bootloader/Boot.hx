package markisa.bootloader;

import frambos.ecs.BlockTree;
import frambos.ecs.Block;

class Boot {
    public function new() {
        trace("the game started omgomgmogmogmomogmogmogmogmo");

        var heheheha2 = new Block();
        heheheha2.name = "heheheha2";
        BlockTree.root.addChild(heheheha2);

        var haha = new Block();
        haha.name = "haha";
        BlockTree.root.addChild(haha);

        var comedy = new Block();
        comedy.name = "comedy";
        heheheha2.addChild(comedy);

        var amogus = new Block();
        amogus.name = "amogus";
        heheheha2.addChild(amogus);

        var itIsThePinnacleOfComedy = new Block();
        itIsThePinnacleOfComedy.name = "itIsThePinnacleOfComedy";
        amogus.addChild(itIsThePinnacleOfComedy);

        BlockTree.printTree();
    }
}