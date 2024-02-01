extends Button
class_name MksPopupHide

export(NodePath) var popup
onready var realPopup = get_node(popup)

func _pressed():
	realPopup.HidePopup()
