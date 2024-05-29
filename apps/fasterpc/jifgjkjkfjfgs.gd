extends Node

func aFunc():
	Frambos.Play(4)
	var g = get_node("../label") as Label
	g.text = tr("Your Markistation is safe and clean")
	g.modulate = Color.white
	get_node("../ParadoxBar").disconnect("finished", self, "aFunc")
	get_node("../ParadoxBar").visible = false
