package frambos.util;

/**
 * Represents a color with each component ranging from 0 to 1. You can also spell it as `Colour`
 */
abstract Color(Array<Float>) to Array<Float> {
    /**
     * The red part of the color, ranges between 0 and 1.
     */
    public var r(get, set): Float;
    /**
     * The green part of the color, ranges between 0 and 1.
     */
    public var g(get, set): Float;
    /**
     * The blue part of the color, ranges between 0 and 1.
     */
    public var b(get, set): Float;
    /**
     * The alpha part of the color, ranges between 0 and 1.
     */
    public var a(get, set): Float;
    /**
     * The red part of the color, but multiplied by 256.
     */
    public var r8(get, set): Int;
    /**
     * The green part of the color, but multiplied by 256.
     */
     public var g8(get, set): Int;
     /**
     * The blue part of the color, but multiplied by 256.
     */
    public var b8(get, set): Int;
    /**
     * The alpha part of the color, but multiplied by 256.
     */
     public var a8(get, set): Int;
    
    public inline function new(r: Float, g: Float, b: Float, a: Float) {
        this = new Array<Float>();
        this.push(MathExtensions.clamp(r, 0, 1));
        this.push(MathExtensions.clamp(g, 0, 1));
        this.push(MathExtensions.clamp(b, 0, 1));
        this.push(MathExtensions.clamp(a, 0, 1));
    }

    private inline function get_r(): Float { return this[0]; }
    private inline function get_g(): Float { return this[1]; }
    private inline function get_b(): Float { return this[2]; }
    private inline function get_a(): Float { return this[3]; }
    private inline function set_r(value: Float): Float { return this[0] = value; }
    private inline function set_g(value: Float): Float { return this[1] = value; }
    private inline function set_b(value: Float): Float { return this[2] = value; }
    private inline function set_a(value: Float): Float { return this[3] = value; }

    private inline function get_r8(): Int { return cast this[0] * 256; }
    private inline function get_g8(): Int { return cast this[1] * 256; }
    private inline function get_b8(): Int { return cast this[2] * 256; }
    private inline function get_a8(): Int { return cast this[3] * 256; }
    private inline function set_r8(value: Int): Int { return cast this[0] = value / 256; }
    private inline function set_g8(value: Int): Int { return cast this[1] = value / 256; }
    private inline function set_b8(value: Int): Int { return cast this[2] = value / 256; }
    private inline function set_a8(value: Int): Int { return cast this[3] = value / 256; }

    @:op(A == B)
    private inline function equals(right: Color): Bool {
        return r == right.r && g == right.g && b == right.b && a == right.a;
    }

    @:op(A != B)
    private inline function notEquals(right: Color): Bool {
        return r != right.r && g != right.g && b != right.b && a != right.a;
    }
}

// for bri'ish people
/**
 * Represents a color with each component ranging from 0 to 1. You can also spell it as `Color`
 */
typedef Colour = Color;