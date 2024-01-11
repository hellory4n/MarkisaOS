package markisa.bootloader;

import markisa.engineTest.TestPiece;
import frambos.ecs.BlockTree;
import frambos.ecs.Block;

class Boot {
    public function new() {
        trace("the game started omgomgmogmogmomogmogmogmogmo");

        var heheheha = new Block();
        heheheha.name = "heheheha";
        heheheha.getPiece(TestPiece);
        BlockTree.root.addChild(heheheha);

        var haha = new Block();
        haha.name = "haha";
        BlockTree.root.addChild(haha);

        var comedy = new Block();
        comedy.name = "comedy";
        heheheha.addChild(comedy);

        var amogus = new Block();
        amogus.name = "amogus";
        heheheha.addChild(amogus);

        var itIsThePinnacleOfComedy = new Block();
        itIsThePinnacleOfComedy.name = "itIsThePinnacleOfComedy";
        amogus.addChild(itIsThePinnacleOfComedy);

        trace(heheheha.getPath());
        trace(haha.getPath());
        trace(comedy.getPath());
        trace(amogus.getPath());
        trace(itIsThePinnacleOfComedy.getPath());
    }
}