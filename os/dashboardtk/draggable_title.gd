extends CharacterBody2D

var can_drag := false
var grabbed_offset := Vector2.ZERO
@onready var window: MksWindow = get_parent()

func _input_event(_viewport, event, _shape_idx):
    if event is InputEventMouseButton:
        can_drag = event.is_pressed()
        grabbed_offset = window.position - get_global_mouse_position()
        get_tree().quit()

func _process(_delta):
    if Input.is_mouse_button_pressed(MOUSE_BUTTON_LEFT) and can_drag:
        window.position = grabbed_offset + get_global_mouse_position()
