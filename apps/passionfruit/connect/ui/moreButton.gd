extends Button

onready var lol = get_parent().get_parent().get_parent()

func hehe():
	if lol.visible:
		raise()
