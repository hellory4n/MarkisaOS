extends Button

enum Modes { APP_LAUNCHER, QUICK_SETTINGS, NOTIFICATIONS, STICKY_NOTES }

@export var panel: Panel
@export var panel_type := Modes.APP_LAUNCHER
var from: Vector2
var to: Vector2

func _ready():
	match panel_type:
		Modes.APP_LAUNCHER:
			from = Vector2(-400, Frambos.resolution.y - 300)
			to = Vector2(64, Frambos.resolution.y - 300)
		Modes.QUICK_SETTINGS:
			from = Vector2(Frambos.resolution.x - 300, -300)
			to = Vector2(Frambos.resolution.x - 300, 40)
		Modes.NOTIFICATIONS:
			from = Vector2(Frambos.resolution.x - 350, -400)
			to = Vector2(Frambos.resolution.x - 350, 40)
		Modes.STICKY_NOTES:
			from = Vector2(64, -400)
			to = Vector2(64, 40)

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
