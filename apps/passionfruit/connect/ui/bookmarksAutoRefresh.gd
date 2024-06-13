extends Timer

func _process(_delta):
	paused = !get_parent().visible
