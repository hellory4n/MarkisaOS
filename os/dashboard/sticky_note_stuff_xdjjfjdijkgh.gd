extends TextEdit

func _ready() -> void:
    var jgkjddfajgjsgkd := UserNotes.load()
    text = jgkjddfajgjsgkd.text

func _on_timer_timeout() -> void:
    if has_focus():
        var serisjh := UserNotes.new()
        serisjh.text = text
        UserNotes.save(serisjh)