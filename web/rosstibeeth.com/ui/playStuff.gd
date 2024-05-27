extends Button

func _pressed():
	(get_node("m") as AudioStreamPlayer).play()
