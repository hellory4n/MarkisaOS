extends Button

func _ready():
	var so_true := MarkisaUser.load()
	text = so_true.display_name
	tooltip_text = so_true.username
	icon = load(so_true.photo)
