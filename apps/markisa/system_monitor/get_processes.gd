extends ItemList

func _process(_delta: float) -> void:
	clear()
	var windowsvista = get_node("/root/Dashboard/Windows")
	for epic_window: MksWindow in windowsvista.get_children():
		add_item(epic_window.window_name)
		add_item("CPU usage: %s%%" % epic_window.cpu_usage, null, false)
		add_item("Disk usage: %s%%" % epic_window.disk_usage, null, false)

func _on_item_selected(index: int) -> void:
	print("selected item %s" % get_item_text(index))
