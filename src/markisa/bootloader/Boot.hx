package markisa.bootloader;

import markisa.engineTest.OtherTestPiece;
import markisa.engineTest.TestPiece;
import frambos.ecs.BlockTree;
import frambos.ecs.Block;

class Boot {
    public function new() {
        trace("the game started omgomgmogmogmomogmogmogmogmo");

        var vmdgdgkd = new Block();
        vmdgdgkd.name = "vmdgdgkd";
        vmdgdgkd.getPiece(OtherTestPiece);
        BlockTree.root.addChild(vmdgdgkd);

        var heheheha = new Block();
        heheheha.name = "heheheha";
        heheheha.getPiece(TestPiece);
        BlockTree.root.addChild(heheheha);
    }
}