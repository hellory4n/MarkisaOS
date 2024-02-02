extends Button

export(NodePath) var continuegyshk
export(NodePath) var animatinogublshit
export var shutdown := false
onready var cotnientuete := get_node(continuegyshk) as Button
onready var aniamtinionublshity := get_node(animatinogublshit) as AnimationPlayer

func _pressed():
	aniamtinionublshity.play("showBigPopup")
	# horrible way of passing information around since i don't give a shit
	if shutdown:
		cotnientuete.editor_description = "shutdown"
	else:
		cotnientuete.editor_description = "logoff"
