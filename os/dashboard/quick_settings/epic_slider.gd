extends HSlider

@export var music := false

func _value_changed(new_value):
	if music:
		SoundManager.set_music_volume(new_value)
	else:
		SoundManager.set_sound_volume(new_value)
