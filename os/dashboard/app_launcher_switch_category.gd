extends Button

@export var awesome_category: ScrollContainer
@export var the_parent: Panel

func _pressed():
	for child in the_parent.get_children():
		if child is ScrollContainer:
			child.visible = child == awesome_category
