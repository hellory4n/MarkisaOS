extends Button

func _toggled(button_pressed):
	get_node("/root/dashboard/windows").visible = not button_pressed
