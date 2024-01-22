## I wonder if you should use it
extends Sprite2D
class_name __internaldonotuseorthingswillblowupandstuff__DraggableTitle__ 

# don't ask what this does, i stole this from https://gist.github.com/angstyloop/08200c6d816347c82ea1aed56c219f17
# and deleted all of the comments since they were pretty ridiculous
@export var window: MksWindow
static var active_window: MksWindow
var status = "none"
var tsize = Vector2()
var mpos = Vector2()

func _process(_delta):
	tsize = scale - Vector2(45, 0)
	if status == "dragging":
		window.global_position = mpos + offset + Vector2(0, 45)

func _input(ev: InputEvent):
	if (ev is InputEventMouseButton and ev.button_index == MOUSE_BUTTON_LEFT) or (ev is InputEventScreenTouch and ev.is_pressed()):
		var ev2 := ev as InputEventMouseButton
		if status != "dragging" and ev.pressed:
			var evpos = ev2.global_position
			
			var gpos = global_position
			
			var rect = Rect2()
			if is_centered():
				rect = Rect2(gpos.x - tsize.x / 2, gpos.y - tsize.y / 2, tsize.x, tsize.y)
			else:
				rect = Rect2(gpos.x, gpos.y, tsize.x, tsize.y)
				
			if rect.has_point(evpos):
				window.move_to_front()
				status = "clicked"
				offset = gpos - evpos
				active_window = window
		
		elif status == "dragging" and not ev.pressed:
			status = "released"
			active_window = null
	
	if status == "clicked" and active_window == window and (ev is InputEventMouseMotion or ev is InputEventScreenDrag):
		status = "dragging"

	mpos = get_global_mouse_position()
