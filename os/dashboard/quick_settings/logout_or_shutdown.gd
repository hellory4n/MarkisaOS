extends Button

@export var thing: ColorRect
@export var shutdown := false
@export var awesome_shutdown_button_thing_lmao: ______________why

func _pressed():
	# do an awesome animation
	thing.visible = true
	thing.pivot_offset = thing.size / 2
	thing.modulate = Color.TRANSPARENT
	thing.scale = Vector2.ZERO
	var tween := create_tween()
	tween.set_parallel(true)
	tween.tween_property(thing, "scale", Vector2.ONE, 0.2).set_trans(Tween.TRANS_EXPO).set_ease(Tween.EASE_OUT)
	tween.tween_property(thing, "modulate", Color.WHITE, 0.2).set_trans(Tween.TRANS_CUBIC).set_ease(Tween.EASE_OUT)
	
	# dumb way of making a warning sound play
	var jhjdjhdjhg := SystemSoundPlayer.new()
	jhjdjhdjhg.sound = SystemSoundPlayer.SystemSounds.WARNING
	jhjdjhdjhg.autoplay = true
	add_child(jhjdjhdjhg)
	
	awesome_shutdown_button_thing_lmao.shutdown = shutdown
