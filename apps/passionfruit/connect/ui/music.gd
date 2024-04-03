extends AudioStreamPlayer

func _process(_delta):
	stream_paused = !get_parent().visible
