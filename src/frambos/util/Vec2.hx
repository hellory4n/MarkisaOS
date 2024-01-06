package frambos.util;

import Math;
import frambos.util.MathExtensions;

/**
 * Represents a 2D coordinate, with the origin point being at the top left.
 */

abstract Vec2(Array<Float>) to Array<Float> {
    public var x(get, set): Float;
    public var y(get, set): Float;
    public static var ZERO(get, never): Vec2;
    public static var ONE(get, never): Vec2;
    public static var LEFT(get, never): Vec2;
    public static var RIGHT(get, never): Vec2;
    public static var UP(get, never): Vec2;
    public static var DOWN(get, never): Vec2;
    
    public inline function new(x:Float, y:Float) {
        this = new Array<Float>();
        this.push(x);
        this.push(y);
    }

    private inline function get_x(): Float { return this[0]; }
    private inline function get_y(): Float { return this[1]; }
    private inline function set_x(value: Float): Float { return this[0] = value; }
    private inline function set_y(value: Float): Float { return this[1] = value; }

    @:op(A + B)
    private inline function add(right: Vec2): Vec2 {
        return new Vec2(x + right.x, y + right.y);
    }

    @:op(A - B)
    private inline function subtract(right: Vec2): Vec2 {
        return new Vec2(x - right.x, y - right.y);
    }

    @:op(A * B)
    private inline function multiply(right: Float): Vec2 {
        return new Vec2(x * right, y * right);
    }

    @:op(A / B)
    private inline function divide(right: Float): Vec2 {
        return new Vec2(x / right, y / right);
    }

    @:op(A % B)
    private inline function modulo(right: Float): Vec2 {
        return new Vec2(x % right, y % right);
    }
    
    @:op(A * B)
    private inline function multiplyByVec(right: Vec2): Vec2 {
        return new Vec2(x * right.x, y * right.y);
    }

    @:op(A / B)
    private inline function divideByVec(right: Vec2): Vec2 {
        return new Vec2(x / right.x, y / right.y);
    }

    @:op(A % B)
    private inline function moduloByVec(right: Vec2): Vec2 {
        return new Vec2(x % right.x, y % right.y);
    }

    @:op(-A)
    private inline function negate(): Vec2 {
        return new Vec2(-x, -y);
    }

    @:op(A == B)
    private inline function equals(right: Vec2): Bool {
        return x == right.x && y == right.y;
    }

    @:op(A != B)
    private inline function notEquals(right: Vec2): Bool {
        return x != right.x && y != right.y;
    }

    @:op(A < B)
    private inline function lt(right: Vec2): Bool {
        return x < right.x && y < right.y;
    }

    @:op(A > B)
    private inline function gt(right: Vec2): Bool {
        return x > right.x && y > right.y;
    }

    @:op(A <= B)
    private inline function ltequals(right: Vec2): Bool {
        return x <= right.x && y <= right.y;
    }

    @:op(A >= B)
    private inline function gtequals(right: Vec2): Bool {
        return x >= right.x && y >= right.y;
    }

    @:op(A += B)
    private inline function addAssign(right: Vec2) {
        x += right.x;
        y += right.y;
    }

    @:op(A -= B)
    private inline function subtractAssign(right: Vec2) {
        x -= right.x;
        y -= right.y;
    }

    @:op(A *= B)
    private inline function multiplyAssign(right: Float) {
        x *= right;
        y *= right;
    }

    @:op(A /= B)
    private inline function divideAssign(right: Float) {
        x /= right;
        y /= right;
    }

    @:op(A %= B)
    private inline function moduloAssign(right: Float) {
        x %= right;
        y %= right;
    }

    @:op(A *= B)
    private inline function multiplyAssignByVec(right: Vec2) {
        x *= right.x;
        y *= right.y;
    }

    @:op(A /= B)
    private inline function divideAssignByVec(right: Vec2) {
        x /= right.x;
        y /= right.y;
    }

    @:op(A %= B)
    private inline function moduloAssignByVec(right: Vec2) {
        x %= right.x;
        y %= right.y;
    }

    public inline function min(value: Vec2): Vec2 {
        return new Vec2(Math.min(x, value.x), Math.min(y, value.y));
    }

    public inline function max(value: Vec2): Vec2 {
        return new Vec2(Math.max(x, value.x), Math.max(y, value.y));
    }

    static function get_ZERO(): Vec2 {
        return new Vec2(0, 0);
    }

    static function get_ONE(): Vec2 {
        return new Vec2(1, 1);
    }

    static function get_LEFT(): Vec2 {
        return new Vec2(-1, 0);
    }

    static function get_RIGHT(): Vec2 {
        return new Vec2(1, 0);
    }

    static function get_UP(): Vec2 {
        return new Vec2(0, -1);
    }

    static function get_DOWN(): Vec2 {
        return new Vec2(0, 1);
    }

    public inline function abs(): Vec2 {
        return new Vec2(Math.abs(x), Math.abs(y));
    }

    public inline function ceil(): Vec2 {
        return new Vec2(Math.ceil(x), Math.ceil(y));
    }

    public inline function clamp(min: Vec2, max: Vec2): Vec2 {
        return new Vec2(
            Math.max(min.x, Math.min(x, max.x)),
            Math.max(min.y, Math.min(y, max.y))
        );
    }

    public inline function distance(to: Vec2): Float {
        var dx = to.x - x;
        var dy = to.y - y;
        return Math.sqrt(dx * dx + dy * dy);
    }

    public inline function floor(): Vec2 {
        return new Vec2(Math.floor(x), Math.floor(y));
    }

    public inline function lerp(to: Vec2, weight: Float): Vec2 {
        weight = Math.max(0, Math.min(1, weight));
        var newX = (1 - weight) * x + weight * to.x;
        var newY = (1 - weight) * y + weight * to.y;
        return new Vec2(newX, newY);
    }

    public inline function round(): Vec2 {
        return new Vec2(Math.round(x), Math.round(y));
    }

    public inline function isAlmostEqual(b: Vec2): Bool {
        return MathExtensions.isAlmostEqual(x, b.x) && MathExtensions.isAlmostEqual(y, b.y);
    }
}
