extends Button

@export var thing: ColorRect

func _pressed():
	# undo the awesome animation
	var tween := create_tween()
	tween.set_parallel(true)
	tween.tween_property(thing, "scale", Vector2.ZERO, 0.4).set_trans(Tween.TRANS_CUBIC).set_ease(Tween.EASE_OUT)
	tween.tween_property(thing, "modulate", Color.TRANSPARENT, 0.4).set_trans(Tween.TRANS_EXPO).set_ease(Tween.EASE_OUT)
	tween.finished.connect(func(): thing.visible = false)
