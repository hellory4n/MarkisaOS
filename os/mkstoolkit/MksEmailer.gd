extends Button
class_name MksEmailer

export var user := ""
export var userPfp: Texture
export(String, MULTILINE) var emailText := ""

func _pressed():
	GdScriptBridge.Emailer(user, userPfp.resource_path, emailText)
