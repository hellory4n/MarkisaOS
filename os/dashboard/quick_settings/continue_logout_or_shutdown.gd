extends Button
class_name ______________why 

@export var shutdown := false
@export var the_bullshit_that_will_die: Control


func _pressed():
	var jgjsgjsf: Node
	if shutdown:
		jgjsgjsf = load("res://os/kickstart/shutdown.tscn").instantiate()
	else:
		jgjsgjsf = load("res://os/kickstart/onboarding.tscn").instantiate()
	
	get_tree().root.add_child(jgjsgjsf)
	the_bullshit_that_will_die.queue_free()
	
	if not shutdown:
		# dumb way of making the logout sound play
		var jhjdjhdjhg := SystemSoundPlayer.new()
		jhjdjhdjhg.sound = SystemSoundPlayer.SystemSounds.LOGOUT
		jhjdjhdjhg.autoplay = true
		jgjsgjsf.add_child(jhjdjhdjhg)
	
	ComputerNoises.dashboard_exists = false
