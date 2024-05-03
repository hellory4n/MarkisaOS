extends Button

func _pressed():
	(get_node("/root/dashboard/interface/dock/stuff/appsLauncher") as Button).pressed = true
	get_node("/root/dashboard/tutorial/4desktop").visible = true
	get_node("/root/dashboard/tutorial/3desktop").visible = false
