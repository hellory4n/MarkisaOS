extends Label

export var seconds := 0.0
export var end := 1.0

func _process(delta):
	var m = get_node("../lol") as AudioStreamPlayer
	if m.get_playback_position() > seconds && m.get_playback_position() < end:
		modulate = Color("#008cff")
	else:
		modulate = Color("#ffffff")
