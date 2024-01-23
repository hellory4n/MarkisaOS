## It plays a system sound.
extends SoundPlayer
class_name SystemSoundPlayer

enum SystemSounds {
	STARTUP,
	SHUTDOWN,
	LOGOUT,
	WARNING,
	ERROR,
	NOTIFICATION,
	CRITICAL_ERROR,
	QUESTION,
	SUCCESS
}

@export var sound := SystemSounds.STARTUP

func _ready():
	match sound:
		SystemSounds.STARTUP: stream = preload("res://os_assets/system_sounds/startup.mp3")
		SystemSounds.SHUTDOWN: stream = preload("res://os_assets/system_sounds/shutdown.mp3")
		SystemSounds.LOGOUT: stream = preload("res://os_assets/system_sounds/logout.mp3")
		SystemSounds.WARNING: stream = preload("res://os_assets/system_sounds/warning.mp3")
		SystemSounds.ERROR: stream = preload("res://os_assets/system_sounds/error.mp3")
		SystemSounds.NOTIFICATION: stream = preload("res://os_assets/system_sounds/notification.mp3")
		SystemSounds.CRITICAL_ERROR: stream = preload("res://os_assets/system_sounds/critical_error.mp3")
		SystemSounds.QUESTION: stream = preload("res://os_assets/system_sounds/question.mp3")
		SystemSounds.SUCCESS: stream = preload("res://os_assets/system_sounds/success.mp3")
	
	super()
