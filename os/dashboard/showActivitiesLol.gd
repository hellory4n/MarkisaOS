extends Button

func _pressed():
	get_node("/root/dashboard/activities").visible = true
