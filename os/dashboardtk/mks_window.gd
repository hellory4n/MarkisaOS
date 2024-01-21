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
@export var floating := true

var title_height: float
var title_rect: Rect2
var background_style: StyleBox
var title_style: StyleBox
var bg: Panel
var title: Panel
var draggable_shit: CharacterBody2D
var iminlovewiththeshapeofyou: CollisionShape2D # i am the very embodiment of comedy itself

# dumb shit
var frames: int
const DraggableTitle := preload("res://os/dashboardtk/draggable_title.tscn")

func _ready():
    # make the internal bullshit
    bg = Panel.new()
    bg.set_anchors_preset(Control.PRESET_FULL_RECT)
    
    title = Panel.new()
    title.set_anchors_preset(PRESET_TOP_WIDE)
    title.offset_top = -45
    title.custom_minimum_size -= Vector2(0, 45)
    
    draggable_shit = DraggableTitle.instantiate()
    draggable_shit.ready.connect(
        func(): iminlovewiththeshapeofyou = draggable_shit.get_node("CollisionShape2D")
    )
    
    add_child(bg, false, Node.INTERNAL_MODE_FRONT)
    add_child(title, false, Node.INTERNAL_MODE_FRONT)
    add_child(draggable_shit, false, Node.INTERNAL_MODE_FRONT)
    
    theme_changed.connect(_on_theme_changed.bind())

func _process(_delta):
    # loading it in _ready doesn't work
    frames += 1
    if frames > 2:
        _on_theme_changed()
    
    # make sure the draggable shit's collision is correct
    var m := RectangleShape2D.new()
    m.size = Vector2(size.x, 45)
    iminlovewiththeshapeofyou.shape = m
    iminlovewiththeshapeofyou.position = Vector2(size.x / 2, -23)

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
    else:
        draw_rect(Rect2((iminlovewiththeshapeofyou.shape as RectangleShape2D).size, iminlovewiththeshapeofyou.position), Color.RED, false)

func _get_configuration_warnings():
    if content_root == null:
        return ["Please set a content root for things to actually work and stuff"]
    else:
        return []
