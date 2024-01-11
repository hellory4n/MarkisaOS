package markisa.engineTest;

import frambos.util.Vec2;
import frambos.core.Assets;
import frambos.graphics.RenderDevice;
import frambos.ecs.Piece;

class TestPiece extends Piece {
    var fuckingSurface: ImageSurface;

    public override function ready() {
        trace("good morning lmao");
        rect.size = new Vec2(420, 690);
    }

    public override function update(delta: Float) {
        rect.position += new Vec2(50 * delta, 50 * delta);
        rotation += 200 * delta;
        //modulate.a -= 5 * delta;
    }

    public override function prepareDraw(device: RenderDevice) {
        var awesomeTexture: Texture = Assets.loadTexture("res://icon.png");
        fuckingSurface = device.newImageSurface(awesomeTexture);
    }

    public override function draw(device: RenderDevice) {
        device.drawImage(fuckingSurface, rect, rotation, modulate);
    }
}