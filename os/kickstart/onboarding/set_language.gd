extends OptionButton

func _ready():
	if TranslationServer.get_locale().begins_with("pt"):
		selected = 1

func _on_item_selected(index):
	var locale: String
	match index:
		0: locale = "en"
		1: locale = "pt"
	
	TranslationServer.set_locale(locale)
	
	# also save the thing
	var system_info := SystemInfo.load()
	system_info.language = locale
	SystemInfo.save(system_info)
