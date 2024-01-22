## A popup you attach to MksWindows.
@tool
extends Control
class_name MksPopup

var background_style: StyleBox
var bg: Panel

# dumb shit
var frames: int

func _ready():
	# make the internal shit
	bg = Panel.new()
	bg.set_anchors_preset(Control.PRESET_FULL_RECT)
	add_child(bg, false, Node.INTERNAL_MODE_FRONT)
	
	theme_changed.connect(_on_theme_changed.bind())
	
	if not Engine.is_editor_hint():
		set_anchors_preset(PRESET_CENTER_TOP)
		visible = false
		modulate = Color.TRANSPARENT
		position = Vector2(position.x, -size.y)

func _process(_delta):
	# loading it in _ready doesn't work
	frames += 1
	if frames > 2:
		_on_theme_changed()

func _on_theme_changed():
	background_style = get_theme_stylebox("panel", "MksPopup")
    
	if bg != null:
		bg.add_theme_stylebox_override("panel", background_style)

func show_popup():
	var tween = create_tween()
	tween.set_parallel(true)
	visible = true
	tween.tween_property(self, "position", Vector2(position.x, 0), 0.2).set_trans(Tween.TRANS_CUBIC).set_ease(Tween.EASE_OUT)
	tween.tween_property(self, "modulate", Color.WHITE, 0.2).set_trans(Tween.TRANS_EXPO).set_ease(Tween.EASE_OUT)

func hide_popup():
	var tween = create_tween()
	tween.set_parallel(true)
	tween.tween_property(self, "position", Vector2(position.x, -size.y), 0.3).set_trans(Tween.TRANS_EXPO).set_ease(Tween.EASE_OUT)
	tween.tween_property(self, "modulate", Color.TRANSPARENT, 0.3).set_trans(Tween.TRANS_CUBIC).set_ease(Tween.EASE_OUT)
