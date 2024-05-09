extends Button
class_name MksDownload

export var file = ""
export(String, MULTILINE) var content = ""
export var time = 100

func _pressed():
	GdScriptBridge.Download(self, file, content, time)
