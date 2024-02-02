extends Button

func _pressed():
	(get_node("/root/dashboard/AnimationPlayer") as AnimationPlayer).play("hideBigPopup")
