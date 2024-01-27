extends Button

## clear
@export var clear: LineEdit

# clear
func _pressed() -> void:
	clear.text = "" # clear