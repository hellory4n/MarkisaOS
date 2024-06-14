extends Button

onready var getparent = get_parent()
var getchildren

func _ready():
	getchildren = getparent.get_children()

func _pressed():
	for m in getchildren:
		if m is PanelContainer:
			m.queue_free()
	
	getparent.LoadMorePosts()
