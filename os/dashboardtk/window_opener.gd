## It's a button that opens windows.
extends Button
class_name WindowOpener 

## The window to open.
@export_file("*.tscn") var window := ""

func _pressed():
	var mmgmg := load(window)
	var windowlol: MksWindow = mmgmg.instantiate()
	get_node("/root/Dashboard/Windows").add_child(windowlol)
