package frambos.util;

import frambos.util.Vec2;

/**
 * Represents a rectangle, with the origin point being at the top left.
 */

abstract Rect(Array<Vec2>) to Array<Vec2> {
    public var position(get, set): Vec2;
    public var size(get, set): Vec2;
    /**
     * The bottom-right corner of the rect.
     */
    public var end(get, never): Vec2;
    public var area(get, never): Float;
    public var center(get, never): Vec2;
    
    public inline function new(x: Float, y: Float, width: Float, height: Float) {
        this = new Array<Vec2>();
        this.push(new Vec2(x, y));
        this.push(new Vec2(width, height));
    }

    private inline function get_position(): Vec2 { return this[0]; }
    private inline function get_size(): Vec2 { return this[1]; }
    private inline function set_position(value: Vec2): Vec2 { return this[0] = value; }
    private inline function set_size(value: Vec2): Vec2 { return this[1] = value; }

    private inline function get_end(): Vec2 {
        return position + size;
    }

    public inline function get_area(): Float {
        return size.x * size.y;
    }

    public inline function get_center(): Vec2 {
        return position + (size / 2);       
    }

    public function expand(to: Vec2): Rect {
        var begin = position;
        var newEnd = end;

        if (to.x < begin.x) {
            begin.x = to.x;
        }
        if (to.y < begin.y) {
            begin.y = to.y;
        }

        if (to.x > newEnd.x) {
            newEnd.x = to.x;
        }
        if (to.y > newEnd.y) {
            newEnd.y = to.y;
        }

        return new Rect(begin.x, begin.y, newEnd.x - begin.x, newEnd.y - begin.y);
    }

    public function growIndividual(left: Float, right: Float, top: Float, bottom: Float): Rect {
        var x = position.x - left;
        var y = position.y - top;
        var width = size.x + left + right;
        var height = size.y + top + bottom;
        return new Rect(x, y, width, height);
    }

    public function grow(amount: Float): Rect {
        var x = position.x - amount;
        var y = position.y - amount;
        var width = size.x + amount * 2;
        var height = size.y + amount * 2;
        return new Rect(x, y, width, height);
    }

    public inline function hasPoint(point: Vec2): Bool {
        return point.x >= position.x && point.x <= position.x + size.x &&
               point.y >= position.y && point.y <= position.y + size.y;
    }

    public inline function intersects(b: Rect): Bool {
        return position.x < b.position.x + b.size.x &&
               position.x + size.x > b.position.x &&
               position.y < b.position.y + b.size.y &&
               position.y + size.y > b.position.y;
    }

    public function intersection(b: Rect): Rect {
        var newRect = b;
        if (!intersects(newRect)) {
            return new Rect(0, 0, 0, 0);
        }

        newRect.position.x = Math.max(b.position.x, position.x);
        newRect.position.y = Math.min(b.position.y, position.y);

        var otherEnd = b.position + b.size;

        newRect.size.x = Math.min(otherEnd.x, end.x) - newRect.position.x;
        newRect.size.y = Math.min(otherEnd.y, end.y) - newRect.position.y;

        return newRect;
    }

    public inline function encloses(b: Rect): Bool {
        return b.position.x >= position.x && b.position.y >= position.y &&
			   b.position.x + b.size.x <= position.x + size.x &&
			   b.position.y + b.size.y <= position.y + size.y;
    }

    public function merge(b: Rect): Rect {
        var newRect = new Rect(0, 0, 0, 0);

        newRect.position.x = Math.min(b.position.x, position.x);
        newRect.position.y = Math.min(b.position.y, position.y);

        newRect.size.x = Math.max(b.position.x + b.size.x, position.x + size.x);
        newRect.size.y = Math.max(b.position.y + b.size.y, position.y + size.y);

        newRect.size = newRect.size - newRect.position;
        return newRect;
    }

    public inline function isAlmostEqual(b: Rect): Bool {
        return position.isAlmostEqual(b.position) && size.isAlmostEqual(b.size);
    }

    @:op(A == B)
    private inline function equals(right: Rect): Bool {
        return position == right.position && size == right.size;
    }

    @:op(A != B)
    private inline function notEquals(right: Rect): Bool {
        return !(this == right);
    }

    
}