extends TextureRect

func _ready():
	if Frambos.get_IsOnMobile():
		texture = preload("res://web/passionfruit.com/assets/markisaOsScreenshotMobile.png")
	else:
		texture = preload("res://web/passionfruit.com/assets/markisaOsScreenshotDesktop.png")
