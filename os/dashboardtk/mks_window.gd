## MarkisaOS' custom implementation of a window.
@tool
extends Control
class_name MksWindow

## If true, the window will be floating and draggable. Else, it will be maximized.
@export var floating := true

var title_height: float
var title_rect: Rect2
var background_style: StyleBox
var title_style: StyleBox
var bg: Panel
var title: Panel

# dumb shit
var frames: int

func _ready():
    # make the internal bullshit
    bg = Panel.new()
    bg.set_anchors_preset(Control.PRESET_FULL_RECT)
    
    title = Panel.new()
    title.set_anchors_preset(PRESET_TOP_WIDE)
    title.offset_top = -45
    title.custom_minimum_size -= Vector2(0, 45)
    
    add_child(bg, false, Node.INTERNAL_MODE_FRONT)
    add_child(title, false, Node.INTERNAL_MODE_FRONT)
    
    theme_changed.connect(_on_theme_changed.bind())

func _process(delta):
    # loading it in _ready doesn't work
    frames += 1
    if frames > 2:
        _on_theme_changed()

func _on_theme_changed():
    title_rect = Rect2(position.x, position.y - title_height, size.x, title_height)
    
    background_style = get_theme_stylebox("active_background", "MksWindow")
    title_style = get_theme_stylebox("active_title", "MksWindow")
    
    if bg != null and title != null:
        bg.add_theme_stylebox_override("panel", background_style)
        title.add_theme_stylebox_override("panel", title_style)

# just show a preview in the editor
func _draw():
    if Engine.is_editor_hint():
        draw_rect(get_rect(), Color("#070E1A"))
