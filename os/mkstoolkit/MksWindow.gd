tool
extends Control
class_name MksWindow

# this script solely exists to show up in the "add node" dialog,
# i really wouldn't want to write something as complicated as this
# in gdscript
func _ready():
	var m := preload("res://os/mkstoolkit/internal/MksWindowCSharp.tscn") as PackedScene
	var bbh = m.instance()
	add_child(bbh)

func _draw():
	if Engine.editor_hint:
		draw_rect(Rect2(Vector2.ZERO, rect_size), Color("#070E19"))
