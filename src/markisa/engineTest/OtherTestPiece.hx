package markisa.engineTest;

import frambos.util.Color;
import frambos.util.Vec2;
import frambos.core.Assets;
import frambos.graphics.RenderDevice;
import frambos.ecs.Piece;

class OtherTestPiece extends Piece {
    var fuckingSurface: ImageSurface;

    public override function ready() {
        trace("good morning lmao");
        size = new Vec2(1366, 768);
        trace("i'm ready, i'm ready!!!!!!!!!!!");
    }

    public override function prepareDraw(device: RenderDevice) {
        trace("preparing draw");
        var awesomeTexture: Texture = Assets.loadTexture("res://assets/greenPeaks.png");
        fuckingSurface = device.newImageSurface(awesomeTexture);
        trace("draw has been prepared");
    }

    public override function draw(device: RenderDevice) {
        trace("drawing");
        device.drawImage(fuckingSurface, rect, rotation, alpha, new Vec2(0.5, 0.5));
        trace("drawed");
    }
}