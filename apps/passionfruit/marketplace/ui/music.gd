extends AudioStreamPlayer

onready var many_parents = get_parent().get_parent()
onready var even_more_parents = get_parent().get_parent().get_parent().get_parent().get_parent()

func _process(_delta):
	stream_paused = !many_parents.visible || !even_more_parents.get_IsActive()
