extends Node

@export var dashboard_exists := false:
	set(value):
		dashboard_exists = value
		if not value:
			fan_player.volume_db = linear_to_db(0.05) # (10 / 100) / 2
			disk_player.volume_db = linear_to_db(0.1) # (5 / 100) * 2

const FAN_NOISES := preload("res://os_assets/computer_noises/194890__saphe__computer-fan.ogg")
const DISK_NOISES := preload("res://os_assets/computer_noises/500168__sad3d__pc-hard-drive-noises.ogg")
var fan_suffering := 10.0
var disk_suffering := 5.0
var fan_player: AudioStreamPlayer
var disk_player: AudioStreamPlayer

func _ready() -> void:
	# we play it as an ui sound since we probably want normal sounds separated
	# from computer noises & shit
	fan_player = SoundManager.play_ui_sound(FAN_NOISES)
	disk_player = SoundManager.play_ui_sound(DISK_NOISES)

	# so it isn't really loud until you login
	fan_player.volume_db = linear_to_db(0.05) # (10 / 100) / 2
	disk_player.volume_db = linear_to_db(0.1) # (5 / 100) * 2

func _process(_delta: float) -> void:
	if not dashboard_exists:
		return
	
	var windowsvista = get_node("/root/Dashboard/Windows")

	# figure out the shit
	fan_suffering = 10
	disk_suffering = 5
	for epic_window: MksWindow in windowsvista.get_children():
		fan_suffering += epic_window.cpu_usage
		disk_suffering += epic_window.disk_usage
	
	# if we use 200% of the cpu it's gonna explode
	fan_suffering = clampf(fan_suffering, 1, 100)
	disk_suffering = clampf(disk_suffering, 1, 100)

	var actual_fan_stufff = fan_suffering / 100
	var actual_disk_stuff = disk_suffering / 100

	fan_player.volume_db = linear_to_db(actual_fan_stufff / 2)
	disk_player.volume_db = linear_to_db(actual_disk_stuff * 2)