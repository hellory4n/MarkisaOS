## MarkisaOS' custom implementation of a window.
@tool
extends Control
class_name MksWindow

## The node that contains the window contents.
@export var content_root: Control:
    set(value):
        content_root = value
        update_configuration_warnings()

## The title of the window.
@export var window_name := ""
## The icon that will be shown in the dock.
@export var dock_icon: Texture2D
## If true, the window will be floating and draggable. Else, it will be maximized.
@export var floating := true:
    set(value):
        floating = value
        update_configuration_warnings()

## How much % of the screen the window will be.
@export var size_percentage: Vector2:
    set(value):
        size_percentage = value
        var lol: Vector2
        if Engine.is_editor_hint():
            lol = Vector2(853, 480)
        else:
            lol = DisplayServer.window_get_size() as Vector2            
        size = (lol * value / 100) - Vector2(0, 45)
        update_configuration_warnings()

var title_height: float
var title_rect: Rect2
var background_style: StyleBox
var title_style: StyleBox
var bg: Panel
var title: Panel
var draggable_title: __internaldonotuseorthingswillblowupandstuff__DraggableTitle__
var title_name: Label

# dumb shit
var frames: int
const DraggableTitle = preload("res://os/dashboardtk/draggable_title.tscn")
@onready var tween := create_tween()

func _ready():
    # make the internal bullshit
    bg = Panel.new()
    bg.set_anchors_preset(Control.PRESET_FULL_RECT)
    
    title = Panel.new()
    title.set_anchors_preset(PRESET_TOP_WIDE)
    title.offset_top = -45
    title.custom_minimum_size -= Vector2(0, 45)
    
    if floating:
        draggable_title = DraggableTitle.instantiate()
        draggable_title.window = self
    
    title_name = Label.new()
    title_name.set_anchors_preset(PRESET_FULL_RECT)
    title_name.horizontal_alignment = HORIZONTAL_ALIGNMENT_CENTER
    title_name.vertical_alignment = VERTICAL_ALIGNMENT_CENTER
    title_name.text_overrun_behavior = TextServer.OVERRUN_TRIM_ELLIPSIS
    
    add_child(bg, false, Node.INTERNAL_MODE_FRONT)
    add_child(title, false, Node.INTERNAL_MODE_FRONT)
    title.add_child(title_name)
    
    if floating:
        add_child(draggable_title, false, Node.INTERNAL_MODE_FRONT)
    
    theme_changed.connect(_on_theme_changed.bind())
    
    # make sure the size is right
    size = (DisplayServer.window_get_size() as Vector2 * size_percentage / 100) - Vector2(0, 45)
    
    # go to the center of the screen
    var cool_size := size + Vector2(0, 45)
    position = DisplayServer.window_get_size() as Vector2 / 2 - (cool_size / 2)
    
    # do the awesome window opening animation
    scale = Vector2.ZERO
    tween.tween_property(self, "scale", Vector2.ONE, 0.2).set_trans(Tween.TRANS_CUBIC).set_ease(Tween.EASE_OUT)

func _process(_delta):
    # loading it in _ready doesn't work
    frames += 1
    if frames > 2:
        _on_theme_changed()
    
    # make sure the draggable shit is correct
    if floating:
        draggable_title.scale = Vector2(size.x, 45)
    
    # sync the window title stuff
    title_name.text = window_name

func _on_theme_changed():
    title_rect = Rect2(position.x, position.y - title_height, size.x, title_height)
    
    background_style = get_theme_stylebox("background", "MksWindow")
    title_style = get_theme_stylebox("title_bg", "MksWindow")
    
    if bg != null and title != null:
        bg.add_theme_stylebox_override("panel", background_style)
        title.add_theme_stylebox_override("panel", title_style)

func _get_configuration_warnings():
    if content_root == null:
        return ["Please set a content root for things to actually work and stuff"]
    elif !floating and size_percentage != Vector2(100, 100):
        return ["This would make users assume it's a floating window when it's not, please set the size percentage to 100, 100 or enable the floating property"]
    else:
        return []
