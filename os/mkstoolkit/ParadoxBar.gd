extends ProgressBar
class_name ParadoxBar

export var instability := 3
signal finished

func _ready():
	randomize()

func _process(delta):
	if max_value == 0: return
	
	if rand_range(0, instability) < 1:
		value += rand_range(0, 90) * delta
	
	if value >= max_value:
		emit_signal("finished")
