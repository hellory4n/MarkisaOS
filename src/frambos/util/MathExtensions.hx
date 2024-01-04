package frambos.util;

import Math;

class MathExtensions {
    public static final CMP_EPSILON = 0.00001;

    /**
     * Floats can have errors, so this checks if something is almost equal.
     */
    public static function isAlmostEqual(a: Float, b: Float): Bool {
        // first check if it's exactly the same
        if (a == b) {
            return true;
        }

        // then check for approximate equality
        var tolerance = CMP_EPSILON * Math.abs(a);
		if (tolerance < CMP_EPSILON) {
			tolerance = CMP_EPSILON;
		}
		return Math.abs(a - b) < tolerance;
    }
}