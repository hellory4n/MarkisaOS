package markisa.engineTest;

import haxe.Exception;
import frambos.util.Vec2;
import frambos.core.Assets;
import frambos.graphics.RenderDevice;
import frambos.ecs.Piece;

class TestPiece extends Piece {
    var fuckingSurface: ImageSurface;

    public override function ready() {
        trace("good morning lmao");
        rect.size = new Vec2(420, 690);
        trace("i'm ready, i'm ready!!!!!!!!!!!");
    }

    public override function update(delta: Float) {
        trace("updating");
        position += new Vec2(50 * delta, 50 * delta);
        rotation += 200 * delta;
        //modulate.a -= 5 * delta;
        trace("updated");
    }

    public override function prepareDraw(device: RenderDevice) {
        trace("preparing draw");
        var awesomeTexture: Texture = Assets.loadTexture("res://assets/icon.png");
        fuckingSurface = device.newImageSurface(awesomeTexture);
        trace("draw has been prepared");
    }

    public override function draw(device: RenderDevice) {
        trace("drawing");
        device.drawImage(fuckingSurface, rect, rotation, modulate, new Vec2(1, 1));
        trace("drawed");
    }
}