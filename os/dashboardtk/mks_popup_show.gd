## Shows a MarkisaOS popup.
extends Button
class_name MksPopupShow

## The popup to show.
@export var popup: MksPopup

func _pressed():
	popup.show_popup()
