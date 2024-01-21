extends Node

@export var parent_bullshit_thing_y: Node
@export var dashboard: PackedScene
@export var tjtjt: TextureRect

func _ready():
    # don't make everything ginormous on desktop
    # there's an option to do that from the project settings but it means
    # i don't get to see how it would look on mobile, so i prefer this
    if not Frambos.is_on_mobile:
        get_tree().root.content_scale_size = DisplayServer.screen_get_size()
        Frambos.resolution = DisplayServer.screen_get_size()
    else:
        Frambos.resolution = get_tree().root.content_scale_size
    
    tjtjt.pivot_offset = tjtjt.size / 2
    
    # hide the cursor since seeing your cursor isn't common when the computer
    # is booting
    Input.warp_mouse(Vector2.ZERO)
    Input.mouse_mode = Input.MOUSE_MODE_CONFINED_HIDDEN
    
func _process(_delta: float):
    if Input.is_action_just_released("skip_boot"):
        load_thing()

func load_thing():
    var lol: Control = dashboard.instantiate()
    get_tree().root.add_child(lol)
    parent_bullshit_thing_y.queue_free()
    
    # bring back the cursor
    Input.warp_mouse(tjtjt.size / 2)
    Input.mouse_mode = Input.MOUSE_MODE_VISIBLE
