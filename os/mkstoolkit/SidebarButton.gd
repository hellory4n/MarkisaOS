extends Button
class_name SidebarButton

export var sidebarRoot: NodePath
onready var sidebarRootStuff := get_node(sidebarRoot)

func _pressed():
	for child in sidebarRootStuff.get_children():
		child.visible = child.name == name
