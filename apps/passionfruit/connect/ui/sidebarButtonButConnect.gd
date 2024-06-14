extends Button

export var sidebarRoot: NodePath
export var thyAlgorithm: NodePath
onready var sidebarRootStuff := get_node(sidebarRoot)
onready var thyAlgorithmStuff := get_node(thyAlgorithm)

func _pressed():
	for child in sidebarRootStuff.get_children():
		child.visible = child.name == name
	
	thyAlgorithmStuff.LoadMorePosts()
