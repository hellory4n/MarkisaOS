extends Node

onready var paradoxBar = $"../paradoxBar"
onready var progress = $"../progress"
onready var finished = $"../finished"

func _process(_delta):
	if paradoxBar.value >= paradoxBar.max_value:
		progress.visible = false
		finished.visible = true
	else:
		progress.visible = true
		finished.visible = false
	
