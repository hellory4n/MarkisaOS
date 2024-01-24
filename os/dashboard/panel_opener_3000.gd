extends Button

enum Modes { APP_LAUNCHER }

@export var panel: Panel
@export var panel_type := Modes.APP_LAUNCHER
var from: Vector2
var to: Vector2

func _ready():
	match panel_type:
		Modes.APP_LAUNCHER:
			from = Vector2(-400, Frambos.resolution.y - 300)
			to = Vector2(64, Frambos.resolution.y - 300)

func _toggled(toggled_on):
	var tween := create_tween()
	tween.set_parallel(true)
	if toggled_on:
		panel.position = from
		panel.modulate = Color.TRANSPARENT
		tween.tween_property(panel, "position", to, 0.2).set_trans(Tween.TRANS_EXPO).set_ease(Tween.EASE_OUT)
		tween.tween_property(panel, "modulate", Color.WHITE, 0.2).set_trans(Tween.TRANS_CUBIC).set_ease(Tween.EASE_OUT)
	else:
		panel.position = to
		panel.modulate = Color.WHITE
		tween.tween_property(panel, "position", from, 0.4).set_trans(Tween.TRANS_CUBIC).set_ease(Tween.EASE_OUT)
		tween.tween_property(panel, "modulate", Color.TRANSPARENT, 0.4).set_trans(Tween.TRANS_EXPO).set_ease(Tween.EASE_OUT)
