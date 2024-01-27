extends Button

@export var window_stuff: Control

func _toggled(toggled_on: bool) -> void:
	window_stuff.visible = not toggled_on