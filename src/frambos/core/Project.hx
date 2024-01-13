package frambos.core;

import frambos.util.Vec2;
import frambos.util.Version;

/**
 * Provides static variables to get information about this project.
 */
class Project {
	/**
	 * The version of the game.
	 */
	public static final VERSION = new Version(0, 13, 0);
    /**
     * The version of the Frambos game engine.
     */
    public static final ENGINE_VERSION = new Version(0, 6, 0);

    /**
     * If `true`, all of the setting up bonanza has been finished. Useful when you're doing stuff right when the game starts.
     */
    public static var engineSetupDone = false;
    /**
     * The fake resolution the game uses.
     */
    public static var SCREEN_SIZE(get, never): Vec2;

    @:allow(Main)
    static var _width: Int;
    @:allow(Main)
    static var _height: Int;

    static function get_SCREEN_SIZE(): Vec2 {
        return new Vec2(_width, _height);
    }
}