package markisa.engineTest;

import frambos.util.Vec2;
import frambos.core.Assets;
import frambos.graphics.RenderDevice;
import frambos.ecs.Piece;

class TestPiece extends Piece {
    var fuckingSurface: ImageSurface;

    public override function ready() {
        size = new Vec2(690, 420);
    }

    public override function update(delta: Float) {
        position += new Vec2(50 * delta, 50 * delta);
        rotation += 200 * delta;
        alpha -= 0.25 * delta;
    }

    public override function prepareDraw(device: RenderDevice) {
        var awesomeTexture: Texture = Assets.loadTexture("res://assets/markisa.png");
        fuckingSurface = device.newImageSurface(awesomeTexture);
    }

    public override function draw(device: RenderDevice) {
        device.drawImage(fuckingSurface, rect, rotation, alpha, new Vec2(0.5, 0.5));
    }
}