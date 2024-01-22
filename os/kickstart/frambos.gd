extends Node

@export var resolution := Vector2(853, 480)
@export var is_on_mobile := OS.get_name() == "Android"
@export var current_user := ""

func _enter_tree():
	# very questionable way of testing on mobile
	if FileAccess.file_exists("user://forcemobile"):
		is_on_mobile = true

func login(username):
	current_user = username
	DirAccess.make_dir_recursive_absolute("user://home/" + username)
