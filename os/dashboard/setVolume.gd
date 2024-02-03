extends HSlider

export var sound := false

func _on_HSlider_value_changed(value):
	if sound:
		AudioServer.set_bus_volume_db(
			AudioServer.get_bus_index("sound"),
			linear2db(value)
		)
	else:
		AudioServer.set_bus_volume_db(
			AudioServer.get_bus_index("music"),
			linear2db(value)
		)
