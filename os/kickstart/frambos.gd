extends Node

@export var resolution := Vector2(853, 480)
@export var is_on_mobile := OS.get_name() == "Android"

func _enter_tree():
    # very questionable way of testing on mobile
    if FileAccess.file_exists("user://forcemobile"):
        is_on_mobile = true
