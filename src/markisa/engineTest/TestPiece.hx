package markisa.engineTest;

import frambos.ecs.Piece;

class TestPiece extends Piece {
    public override function ready() {
        super.ready();
        trace("good morning lmao");
    }

    public override function update(delta: Float) {
        super.update(delta);
        trace('delta time is $delta lol');
    }

    public override function draw() {
        super.draw();
        trace("i is artist");
    }
}