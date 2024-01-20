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

func _ready():
    _on_theme_changed()
    
    # make the internal bullshit
    bg = Panel.new()
    bg.add_theme_stylebox_override("panel", background_style)
    
    title = Panel.new()
    title.add_theme_stylebox_override("panel", title_style)
    
    add_child(bg, false, Node.INTERNAL_MODE_FRONT)
    add_child(title, false, Node.INTERNAL_MODE_FRONT)
    
    theme_changed.connect(_on_theme_changed.bind())

func _on_theme_changed():
    title_height = get_theme_constant("title_height", "MksWindow")
    title_rect = Rect2(position.x, position.y - title_height, size.x, title_height)
    
    background_style = get_theme_stylebox("active_background")
    title_style = get_theme_stylebox("active_title")
    
    if bg != null and title != null:
        bg.add_theme_stylebox_override("panel", background_style)
        title.add_theme_stylebox_override("panel", title_style)
