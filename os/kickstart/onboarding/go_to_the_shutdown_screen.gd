extends Button

@export var shutdown: PackedScene
@export var one_parent_to_rule_them_all: Node

func _pressed():
	var haha := shutdown.instantiate()
	get_tree().root.add_child(haha)
	one_parent_to_rule_them_all.queue_free()
