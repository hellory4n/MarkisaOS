extends Button

func _pressed():
	(get_node("/root/dashboard/interface/panel/stuff/stickyNotes") as Button).pressed = false
	(get_node("/root/dashboard/interface/panel/stuff/quickSettings") as Button).pressed = true
	get_node("/root/dashboard/tutorial/3mobile").visible = true
	get_node("/root/dashboard/tutorial/2mobile").visible = false
