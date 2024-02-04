extends Button

export var gkjdhjdg := ""
export var h: NodePath

func _pressed():
	var m = get_node(h)
	m.queue_free()
	var gjfdg = (load(gkjdhjdg) as PackedScene).instance()
	get_tree().root.add_child(gjfdg)
	
	ComputerNoises.DashboardExists = false
