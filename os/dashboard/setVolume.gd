extends HSlider

export var mode := 0

func _on_HSlider_value_changed(value):
	if mode == 0:
		AudioServer.set_bus_volume_db(
			AudioServer.get_bus_index("sound"),
			linear2db(value)
		)
	elif mode == 1:
		AudioServer.set_bus_volume_db(
			AudioServer.get_bus_index("music"),
			linear2db(value)
		)
	else:
		AudioServer.set_bus_volume_db(
			AudioServer.get_bus_index("pc"),
			linear2db(value)
		)
