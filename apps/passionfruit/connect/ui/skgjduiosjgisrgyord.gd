extends Label

onready var lol = get_parent().get_parent().get_parent()

func _process(_delta):
	if lol.modulate != Color.transparent:
		raise()
