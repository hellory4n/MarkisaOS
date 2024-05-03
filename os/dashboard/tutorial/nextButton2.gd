extends Button

func _pressed():
	(get_node("/root/dashboard/interface/panel/stuff/quickSettings") as Button).pressed = true
	get_node("/root/dashboard/tutorial/3desktop").visible = true
	get_node("/root/dashboard/tutorial/2desktop").visible = false
