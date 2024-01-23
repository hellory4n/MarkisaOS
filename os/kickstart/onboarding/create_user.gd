extends Button

@export var username: LineEdit
@export var display_name: LineEdit
@export var photo: OptionButton
@export var dashboard: PackedScene
@export var atpaeotory: Node
@export var moosic: MusicSwitcher

func _pressed():
	# epic way of making the username thing correct since i can't be bothered to deal with regex
	var real_username := username.text.replace("<", "")
	real_username = real_username.replace(">", "")
	real_username = real_username.replace(":", "")
	real_username = real_username.replace("\"", "")
	real_username = real_username.replace("/", "")
	real_username = real_username.replace("\\", "")
	real_username = real_username.replace("|", "")
	real_username = real_username.replace("?", "")
	real_username = real_username.replace("*", "")
	
	# photo stuff
	var epic_photo: String
	match photo.selected:
		0: epic_photo = "res://os_assets/user_icons/cat.png"
		1: epic_photo = "res://os_assets/user_icons/flower.png"
		2: epic_photo = "res://os_assets/user_icons/balloons.png"
		3: epic_photo = "res://os_assets/user_icons/car.png"
		4: epic_photo = "res://os_assets/user_icons/dog.png"
		5: epic_photo = "res://os_assets/user_icons/duck.png"
		6: epic_photo = "res://os_assets/user_icons/pancakes.png"
		7: epic_photo = "res://os_assets/user_icons/brushes.png"
		8: epic_photo = "res://os_assets/user_icons/shuttle.png"
		9: epic_photo = "res://os_assets/user_icons/football.png"
	
	var heheheha = MarkisaUser.new()
	heheheha.version = ProjectSettings.get_setting("application/config/version")
	heheheha.display_name = display_name.text
	heheheha.username = real_username
	heheheha.photo = epic_photo
	
	Frambos.login(real_username)
	MarkisaUser.save(heheheha)
	
	var hejkhjkshjkg := dashboard.instantiate()
	get_tree().root.add_child(hejkhjkshjkg)
	atpaeotory.queue_free()
	moosic.stop()
