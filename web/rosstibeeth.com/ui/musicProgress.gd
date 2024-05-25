extends ProgressBar

onready var m := get_node("../lol") as AudioStreamPlayer

func _ready():
	max_value = m.stream.get_length()

func _process(_delta):
	value = m.get_playback_position()
