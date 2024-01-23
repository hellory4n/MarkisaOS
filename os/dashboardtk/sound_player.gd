## It plays a sound effect. Use MusicSwitcher if you want music.
extends Node
class_name SoundPlayer

## The AudioStream object to be played.
@export var stream: AudioStream
## If true, audio plays when added to scene tree.
@export var autoplay := false
var internal_player: AudioStreamPlayer

func _ready():
	if autoplay:
		play()

## Plays the audio.
func play():
	internal_player = SoundManager.play_sound(stream)

## Stops the audio.
func stop():
	internal_player.stop()
