extends Button

func _pressed():
	get_node("../../ParadoxBar").visible = true
	get_node("../../ParadoxBar").value = 0
