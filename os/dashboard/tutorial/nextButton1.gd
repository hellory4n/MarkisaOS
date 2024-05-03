extends Button

func _pressed():
	(get_node("/root/dashboard/interface/panel/stuff/stickyNotes") as Button).pressed = true
	get_node("/root/dashboard/tutorial/2desktop").visible = true
	get_node("/root/dashboard/tutorial/1").visible = false
