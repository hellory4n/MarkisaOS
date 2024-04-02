extends AudioStreamPlayer

func _process(delta):
	stream_paused = !get_parent().visible
