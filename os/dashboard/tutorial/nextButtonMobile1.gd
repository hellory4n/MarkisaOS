extends Button

func _pressed():
	(get_node("/root/dashboard/interface/panel/stuff/stickyNotes") as Button).pressed = true
	get_node("/root/dashboard/tutorial/2mobile").visible = true
	get_node("/root/dashboard/tutorial/1mobile").visible = false
