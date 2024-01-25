extends Node

@export var resolution := Vector2(853, 480)
@export var is_on_mobile := OS.get_name() == "Android"
@export var current_user := ""
@export var notifficatiionsdkhift := preload("res://os/dashboard/notification.tscn")

func _enter_tree():
	# very questionable way of testing on mobile
	if FileAccess.file_exists("user://forcemobile"):
		is_on_mobile = true

func login(username: String) -> void:
	current_user = username
	DirAccess.make_dir_recursive_absolute("user://home/" + username)

## Sends a notification and shit.
func notify(app: String, text: String) -> void:
	# I HATE DYNAMIC TYPING I HATE DYNAMIC TYPING I HATE DYNAMIC TYPING I HATE DYNAMIC TYPING I HATE DYNAMIC TYPING I HATE DYNAMIC TYPING 
	var ngdhkdo := notifficatiionsdkhift.instantiate() as Panel
	(ngdhkdo.get_node("App") as Label).text = app
	(ngdhkdo.get_node("Text") as Label).text = text
	add_child(ngdhkdo)
	
	# awesome animation
	var tween := create_tween()
	tween.set_parallel(true)
	@warning_ignore("integer_division")
	ngdhkdo.position = Vector2((resolution.x / 2) - (285 / 2), resolution.y)
	ngdhkdo.modulate = Color.TRANSPARENT
	# don't feel like writing good code today
	tween.tween_property(ngdhkdo, "position", Vector2(ngdhkdo.position.x, resolution.y - 150), 0.2).set_trans(Tween.TRANS_EXPO).set_ease(Tween.EASE_OUT)
	tween.tween_property(ngdhkdo, "modulate", Color.WHITE, 0.2).set_trans(Tween.TRANS_CUBIC).set_ease(Tween.EASE_OUT)
	
	# i really don't feel like writing good code today
	var timer := Timer.new()
	timer.autostart = true
	timer.one_shot = true
	timer.wait_time = 2
	timer.timeout.connect(func():
		var twin := create_tween()
		twin.set_parallel(true)
		twin.tween_property(ngdhkdo, "position", Vector2(ngdhkdo.position.x, resolution.y), 0.4).set_trans(Tween.TRANS_CUBIC).set_ease(Tween.EASE_OUT)
		twin.tween_property(ngdhkdo, "modulate", Color.TRANSPARENT, 0.4).set_trans(Tween.TRANS_EXPO).set_ease(Tween.EASE_OUT)
		twin.finished.connect(func(): ngdhkdo.queue_free())
	)
	ngdhkdo.add_child(timer)
