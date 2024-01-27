extends Resource
class_name UserNotes 

const PATH := "user://home/%user/user_notes.tres"

## The text lol
@export var text := ""

static func save(data: UserNotes):
	ResourceSaver.save(data, PATH.replace("%user", Frambos.current_user))

static func load() -> UserNotes:
	if ResourceLoader.exists(PATH.replace("%user", Frambos.current_user)):
		return load(PATH.replace("%user", Frambos.current_user))
	else:
		save(UserNotes.new())
		return load(PATH.replace("%user", Frambos.current_user))
