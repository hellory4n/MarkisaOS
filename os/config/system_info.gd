extends Resource
class_name SystemInfo

const PATH := "user://system_info.tres"

## If true, the user has already installed their system.
@export var installed := false
## A list of achievements the user has unlocked.
@export var achievements: Array[String]
## The language the user is using.
@export var language := "en"

static func save(data: SystemInfo):
	ResourceSaver.save(data, PATH)

static func load() -> SystemInfo:
	if ResourceLoader.exists(PATH):
		return load(PATH)
	else:
		save(SystemInfo.new())
		return load(PATH)
