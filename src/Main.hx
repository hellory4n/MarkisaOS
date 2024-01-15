package;

import markisa.bootloader.Boot;
import frambos.ecs.Block;
import frambos.ecs.BlockTree;
import openfl.Lib;
import openfl.events.Event;
import openfl.display.BitmapData;
import openfl.display.Bitmap;
import openfl.display.Sprite;
import openfl.Assets;

class Main extends Sprite {
    static inline var MIN_UPDATE_INTERVAL: Float = 1.0 / 60.0;
    var cacheTime: Float = -1.0;

    public function new() {
        super();

        // create the block tree
        var root = new Block();
        root.name = "root";
        BlockTree.root = root;

        var bitmapData: BitmapData = Assets.getBitmapData("assets/icon.png");
        var bitmap = new Bitmap(bitmapData);
        addChild(bitmap);

        bitmap.x = (stage.stageWidth - bitmap.width) / 2;
        bitmap.y = (stage.stageHeight - bitmap.height) / 2;

        addEventListener(Event.ENTER_FRAME, updateIGuess);

        // the game can now do their own bullshit
        new Boot();
    }

    function updateIGuess(event: Event) {
        // delta time bullshit
        var currentTime: Int = Lib.getTimer();
        var delta: Float = (currentTime - cacheTime) / 1000;
		
        // the actual update part
        BlockTree.callUpdate(delta);
        BlockTree.callDraw();

        // more delta time bullshit
		cacheTime = currentTime;
    }
}