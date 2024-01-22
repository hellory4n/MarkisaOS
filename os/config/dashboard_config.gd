extends Resource
class_name DashboardConfig

const PATH := "user://home/%user/dashboard_config.tres"

@export var wallpaper := "res://os_assets/wallpapers/high_peaks.jpg"
@export var theme := "res://os_assets/high_peaks_blue/theme.tres"
@export var themes: Array[String]
@export var wallpapers: Array[String]

static func save(data: DashboardConfig):
	ResourceSaver.save(data, PATH.replace("%user", Frambos.current_user))

static func load() -> DashboardConfig:
	if ResourceLoader.exists(PATH.replace("%user", Frambos.current_user)):
		return load(PATH.replace("%user", Frambos.current_user))
	else:
		save(DashboardConfig.new())
		return load(PATH.replace("%user", Frambos.current_user))
