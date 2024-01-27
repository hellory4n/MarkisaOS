extends Button

@export var lol: LineEdit
@export var the_fucking_text := ""

func _pressed() -> void:
	lol.insert_text_at_caret(the_fucking_text)