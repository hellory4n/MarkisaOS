extends Node

# if we do it on _ready() the browser shits itself,
# _process() is slightly delayed i think
func _process(_delta):
	($"../MksDownload" as Button)._pressed()
	($"../MksHyperlink" as Button)._pressed()
	queue_free()
