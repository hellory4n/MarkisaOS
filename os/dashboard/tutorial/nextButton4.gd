extends Button

func _pressed():
	(get_node("/root/dashboard/interface/dock/stuff/appsLauncher") as Button).pressed = false
	get_node("/root/dashboard/tutorial/5desktop").visible = true
	get_node("/root/dashboard/tutorial/4desktop").visible = false
