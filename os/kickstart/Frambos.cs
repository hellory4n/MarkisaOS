using Godot;
using System;

namespace markisa.foundation
{

public class Frambos : Node
{
    public static Vector2 Resolution { get; set; } = new Vector2(853, 480);
    public static bool IsOnMobile => OS.GetName() == "Android" || forceMobile;
    public static string CurrentUser { get; set; } = "";
    public static string CurrentUserDisplayName { get; set; } = "";
    public static uint MajorVersion => 0;
    public static uint MinorVersion => 13;
    public static uint PatchVersion => 1;
    static bool forceMobile = false;
        //static PackedScene notificationShit = GD.Load<PackedScene>()

    public override void _Ready()
    {
        var dir = new Directory();
        if (dir.FileExists("user://forcemobile")) {
            forceMobile = true;
        }
    }
}

}
