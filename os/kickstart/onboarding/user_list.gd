extends VBoxContainer

@export var dashboard: PackedScene
@export var parenttttt: Node

func _ready():
	# yes
	var group := ButtonGroup.new()
	group.pressed.connect(_on_thing.bind())
	
	DirAccess.make_dir_recursive_absolute("user://home/")
	var lol = DirAccess.open("user://home/")
	lol.list_dir_begin()
	var filename = lol.get_next()
	while filename != "":
		# get the display name and photo and shit
		Frambos.current_user = filename
		var m: MarkisaUser = MarkisaUser.load()
		
		# make the button stuff
		var button := Button.new()
		button.theme_type_variation = "Secondary"
		button.text = m.display_name
		button.tooltip_text = filename
		button.expand_icon = true
		button.icon = load(m.photo)
		button.text_overrun_behavior = TextServer.OVERRUN_TRIM_ELLIPSIS
		button.button_group = group
		add_child(button)
		
		filename = lol.get_next()

func _on_thing(button: Button):
	# i know
	Frambos.current_user = button.tooltip_text
	
	var hejkhjkshjkg := dashboard.instantiate()
	get_tree().root.add_child(hejkhjkshjkg)
	parenttttt.queue_free()
