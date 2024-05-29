extends Label

func _ready():
	gsgs()

func gsgs():
	randomize()
	var g = floor(rand_range(0, 2))
	if g == 0:
		modulate = Color.red
		text = tr("Your Markistation is under threat")
	else:
		modulate = Color.white
		text = tr("Your Markistation is safe and clean")
