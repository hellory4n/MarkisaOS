extends Resource
class_name Package

enum Category {
	ACCESSORIES,
	DEVELOPMENT,
	GAMES,
	GRAPHICS,
	INTERNET,
	MULTIMEDIA,
	OFFICE,
	SYSTEM,
	UTILITIES
}

@export var display_name := "Cool app"
@export var author := "Passionfruit Corporation"
@export var icon := ""
## A path to the scene with the app, with a MksWindow as its root.
@export var executable := ""
## A path to the scene with the uninstaller for this app. If null, this app cannot be uninstalled.
@export var uninstaller: String
@export var categories: Array[Category]
@export var translated_name = {
	"en": "Cool app",
	"pt": "Estarrecedoramente",
	"es": "ñ",
	"ru": "ы"
}
