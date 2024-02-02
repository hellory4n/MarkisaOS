extends Button
class_name WindowOpener

export(String, FILE, "*.tscn") var window := ""

func _pressed():
	var mmgkjfh := load(window) as PackedScene
	var widnowlow = mmgkjfh.instance()
	get_node("/root/dashboard/windows").add_child(widnowlow)
