package frambos.core;

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
}