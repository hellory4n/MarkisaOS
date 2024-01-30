using Godot;
using System;

namespace markisa.foundation
{
public class Frambos : Node
{
    public static Vector2 Resolution { get; set; } = new Vector2(853, 480);
    public static bool IsOnMobile => OS.GetName() == "Android";
    public static string CurrentUser { get; set; } = "";
    public static string CurrentUserDisplayName { get; set; } = "";
    //static PackedScene notificationShit = GD.Load<PackedScene>()
}
}
