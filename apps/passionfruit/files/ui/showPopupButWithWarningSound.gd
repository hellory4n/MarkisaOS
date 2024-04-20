extends Button

export(NodePath) var popup
onready var realPopup = get_node(popup)

func _pressed():
	realPopup.ShowPopup()
	Frambos.Play(2)
