extends Button
class_name MksHyperlink

export var website := "example.com"

func _pressed():
	GdScriptBridge.Hyperlink(self, website)
