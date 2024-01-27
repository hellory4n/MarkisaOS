extends LineEdit

func _on_shit(text_bullshit: String) -> void:
	text_bullshit = text_bullshit.replace("÷", "/")
	text_bullshit = text_bullshit.replace("×", "*")

	# couldn't find a less hideous way to make a character whitelist or whatever
	# don't feel like making some regex bullshit either
	var fuckr := ""
	for jgsdjg in text_bullshit:
		if jgsdjg in ["0", "1", "2", "3", "4", "5", "6", "7", "8", "9", "(", ")", ".", "+", "-", "*", "/"]:
			fuckr += jgsdjg
	
	var express = Expression.new()
	var error = express.parse(fuckr)

	# error isn't OK D:
	# somebody help error
	if error != OK:
		text = "Syntax error"
		return
	
	var result = express.execute()
	if express.has_execute_failed():
		text = "Calculation error"
	else:
		text = "%s" % result

func _fuck_fuck_fuck_fuck() -> void:
	_on_shit(text)
