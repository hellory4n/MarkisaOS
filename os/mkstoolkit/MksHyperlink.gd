extends Button

export var website := "example.com"

func _pressed():
	GdScriptBridge.Hyperlink(self, website)
