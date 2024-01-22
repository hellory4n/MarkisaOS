extends Resource
class_name MarkisaUser

const PATH := "user://home/%user/markisa_user.tres"

## The version of the game the user last used.
@export var version := "0.13.0"
## The name displayed for the user, not the one used for saving the user's data.
@export var display_name := "John Doe"
## The name used when saving user data. Also used on the web, where it gets the @ symbol in front of it.
@export var username := "johndoe"
## The photo the user uses.
@export var photo := "res://os_assets/user_icons/cat.png"

static func save(data: MarkisaUser):
	ResourceSaver.save(data, PATH.replace("%user", Frambos.current_user))

static func load() -> MarkisaUser:
	if ResourceLoader.exists(PATH.replace("%user", Frambos.current_user)):
		return load(PATH.replace("%user", Frambos.current_user))
	else:
		save(MarkisaUser.new())
		return load(PATH.replace("%user", Frambos.current_user))
