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
## The icon that will be shown in the dock, recommended resolution of 40x40
@export var dock_icon: Texture2D
## The smaller icon, recommended resolution of 28x28
@export var small_icon: Texture2D
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
			lol = Frambos.resolution
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
var icon_display: Button
var close_button: Button
var dock_button: Button

# dumb shit
var frames: int
const DraggableTitle = preload("res://os/dashboardtk/draggable_title.tscn")
@onready var tween := create_tween()

func _ready():
	# every window must be maximized on android, whether the windows like it or not (help)
	if Frambos.is_on_mobile:
		floating = false
		size_percentage = Vector2(100, 100)
	
	# make the internal bullshit
	bg = Panel.new()
	bg.set_anchors_preset(Control.PRESET_FULL_RECT)
	
	title = Panel.new()
	title.set_anchors_preset(PRESET_TOP_WIDE)
	title.offset_top = -45
	title.custom_minimum_size -= Vector2(0, 45)
	
	if floating and !Engine.is_editor_hint():
		draggable_title = DraggableTitle.instantiate()
		draggable_title.window = self
	
	title_name = Label.new()
	title_name.set_anchors_preset(PRESET_FULL_RECT)
	title_name.horizontal_alignment = HORIZONTAL_ALIGNMENT_CENTER
	title_name.vertical_alignment = VERTICAL_ALIGNMENT_CENTER
	title_name.text_overrun_behavior = TextServer.OVERRUN_TRIM_ELLIPSIS
	
	close_button = Button.new()
	close_button.custom_minimum_size = Vector2(45, 45)
	close_button.flat = true
	close_button.icon_alignment = HORIZONTAL_ALIGNMENT_CENTER
	close_button.vertical_icon_alignment = VERTICAL_ALIGNMENT_CENTER
	close_button.expand_icon = true
	close_button.set_anchors_preset(PRESET_RIGHT_WIDE)
	close_button.offset_left = -45
	close_button.add_theme_stylebox_override("focus", StyleBoxEmpty.new())
	close_button.pressed.connect(_on_close_request.bind())
	
	icon_display = Button.new()
	icon_display.custom_minimum_size = Vector2(45, 45)
	icon_display.flat = true
	icon_display.icon_alignment = HORIZONTAL_ALIGNMENT_CENTER
	icon_display.vertical_icon_alignment = VERTICAL_ALIGNMENT_CENTER
	icon_display.expand_icon = true
	icon_display.mouse_filter = Control.MOUSE_FILTER_IGNORE
	
	add_child(bg, false, Node.INTERNAL_MODE_FRONT)
	add_child(title, false, Node.INTERNAL_MODE_FRONT)
	title.add_child(title_name)
	title.add_child(close_button)
	title.add_child(icon_display)
	
	if floating and !Engine.is_editor_hint():
		add_child(draggable_title, false, Node.INTERNAL_MODE_FRONT)
	
	theme_changed.connect(_on_theme_changed.bind())
	
	# make sure the size is right
	if not Engine.is_editor_hint():
		size = (Frambos.resolution * size_percentage / 100) - Vector2(0, 45)
	
	# go to the center of the screen
	if not Engine.is_editor_hint():
		var cool_size := size + Vector2(0, 45)
		position = (Frambos.resolution + Vector2(64, 40)) / 2 - (cool_size / 2)
	
	# show up in the dock
	if not Frambos.is_on_mobile and not Engine.is_editor_hint():
		var haha := get_node("/root/Dashboard/GuiStuff/Dock/Dock/Apps")
		dock_button = Button.new()
		dock_button.icon = dock_icon
		dock_button.theme_type_variation = "DockButton"
		haha.add_child(dock_button)
		
		dock_button.pressed.connect(func():
			move_to_front()
		)
	
	# do the awesome window opening animation
	scale = Vector2.ZERO
	modulate = Color.TRANSPARENT
	tween.set_parallel(true)
	tween.tween_property(self, "scale", Vector2.ONE, 0.2).set_trans(Tween.TRANS_CUBIC).set_ease(Tween.EASE_OUT)
	tween.tween_property(self, "modulate", Color.WHITE, 0.2).set_trans(Tween.TRANS_EXPO).set_ease(Tween.EASE_OUT)

func _process(_delta):
	# loading it in _ready doesn't work
	frames += 1
	if frames > 2:
		_on_theme_changed()
	
	# make sure the draggable shit is correct
	if floating and !Engine.is_editor_hint():
		draggable_title.scale = Vector2(size.x, 45)
	
	# sync the window title icon stuff
	title_name.text = window_name
	icon_display.icon = small_icon

func _on_theme_changed():
	title_rect = Rect2(position.x, position.y - title_height, size.x, title_height)
	
	background_style = get_theme_stylebox("background", "MksWindow")
	title_style = get_theme_stylebox("title_bg", "MksWindow")
	
	if bg != null and title != null:
		bg.add_theme_stylebox_override("panel", background_style)
		title.add_theme_stylebox_override("panel", title_style)
		close_button.icon = get_theme_icon("close", "MksWindow")
		close_button.add_theme_color_override("icon_normal_color", get_theme_color("icon_modulate", "MksWindow"))
		close_button.add_theme_color_override("icon_hover_color", get_theme_color("icon_modulate", "MksWindow"))
		close_button.add_theme_color_override("icon_hover_pressed_color", get_theme_color("icon_modulate", "MksWindow"))
		close_button.add_theme_color_override("icon_pressed_color", get_theme_color("icon_modulate", "MksWindow"))
		close_button.add_theme_color_override("icon_focus_color", get_theme_color("icon_modulate", "MksWindow"))

func _get_configuration_warnings():
	if content_root == null:
		return ["Please set a content root for things to actually work and stuff"]
	elif !floating and size_percentage != Vector2(100, 100):
		return ["This would make users assume it's a floating window when it's not, please set the size percentage to 100, 100 or enable the floating property"]
	else:
		return []

func _on_close_request():
	tween = create_tween()
	tween.set_parallel(true)
	tween.tween_property(self, "scale", Vector2.ZERO, 0.3) \
		.set_trans(Tween.TRANS_EXPO) \
		.set_ease(Tween.EASE_OUT) \
		.finished.connect(func(): queue_free())
	tween.tween_property(self, "modulate", Color.TRANSPARENT, 0.3).set_trans(Tween.TRANS_CUBIC).set_ease(Tween.EASE_OUT)
	
	dock_button.queue_free()
