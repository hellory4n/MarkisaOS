package markisa.engineTest;

import frambos.ecs.Piece;

class OtherTestPiece extends Piece {
    public override function ready() {
        trace("good morning");
    }

    public override function update(delta: Float) {
        trace("updating");
    }

    public override function draw() {
        trace("drawing");
    }
}