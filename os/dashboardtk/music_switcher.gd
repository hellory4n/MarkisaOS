## It switches the currently playing music :)
extends Node
class_name MusicSwitcher

@export var stream: AudioStream
@export var autoplay := false
@export var stream_paused := false:
	set(value):
		stream_paused = value
		if value:
			SoundManager.pause_music(stream)
		else:
			SoundManager.resume_music(stream)

func _ready():
	if autoplay:
		play()

func _process(_delta):
	if is_queued_for_deletion():
		stop()

func play():
	SoundManager.play_music(stream, 0.5)

func stop():
	SoundManager.stop_music(0.5)
