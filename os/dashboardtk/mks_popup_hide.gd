## Hides a MarkisaOS popup.
extends Button
class_name MksPopupHide

## The popup to hide.
@export var popup: MksPopup

func _pressed():
	popup.hide_popup()
