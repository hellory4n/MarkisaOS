extends Control

func _ready():
	# hide the cursor since the entire OS just crashed
	Input.warp_mouse_position(Vector2.ZERO)
	Input.mouse_mode = Input.MOUSE_MODE_CONFINED_HIDDEN
