extends Button
class_name MksPopupShow

export(NodePath) var popup
onready var realPopup = get_node(popup)

func _pressed():
	realPopup.ShowPopup()
