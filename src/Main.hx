package;

import openfl.display.BitmapData;
import openfl.display.Bitmap;
import openfl.display.Sprite;
import openfl.Assets;

class Main extends Sprite {
    public function new() {
        super();

        var bitmapData: BitmapData = Assets.getBitmapData("assets/icon.png");
        var bitmap = new Bitmap(bitmapData);
        addChild(bitmap);

        bitmap.x = (stage.stageWidth - bitmap.width) / 2;
        bitmap.y = (stage.stageHeight - bitmap.height) / 2;
    }
}