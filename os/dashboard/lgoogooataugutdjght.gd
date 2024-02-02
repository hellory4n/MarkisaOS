extends Button

func _pressed():
	# horrible way of passing information since i don't give a shit
	if editor_description == "shutdown":
		var shit = load("res://os/kickstart/shutdown.tscn") as PackedScene
		get_tree().root.add_child(shit.instance())
	else:
		var shit = load("res://os/kickstart/onboarding.tscn") as PackedScene
		get_tree().root.add_child(shit.instance())
	
	get_node("/root/dashboard").queue_free()
