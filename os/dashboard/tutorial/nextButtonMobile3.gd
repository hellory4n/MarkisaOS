extends Button

func _pressed():
	(get_node("/root/dashboard/interface/panel/stuff/quickSettings") as Button).pressed = false
	(get_node("/root/dashboard/interface/dock/stuff/appsLauncher") as Button).pressed = true
	get_node("/root/dashboard/tutorial/4mobile").visible = true
	get_node("/root/dashboard/tutorial/3mobile").visible = false
