extends Button

func _pressed():
	var ha = get_parent()
	for m in ha.get_children():
		if m is PanelContainer:
			m.queue_free()
	
	get_parent().LoadMorePosts()
