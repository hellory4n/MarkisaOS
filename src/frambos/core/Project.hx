package frambos.core;

import frambos.util.Version;

/**
 * Provides static variables to get information about this project.
 */
class Project {
	/**
	 * The version of the game.
	 */
	public static final GAME_VERSION = new Version(0, 13, 0);
    /**
     * The version of the Frambos game engine.
     */
    public static final ENGINE_VERSION = new Version(0, 7, 0);

    /**
     * If `true`, the user is using a computer instead of a phone.
     */
    #if desktop
    public static final IS_DESKTOP = true;
    #else
    public static final IS_DESKTOP = false;
    #end
}