using Godot;
using System;

namespace markisa.kickstart {

public class Frambos : Node
{
    public static Vector2 resolution { get; set; } = new Vector2(853, 480);
    public static bool isOnMobile => OS.GetName() == "Android";
    public static string currentUser { get; set; } = "";
    //static PackedScene notificationShit = GD.Load<PackedScene>()

    public static void login(string username)
    {
        currentUser = username;
        var fgfjgdfk = new Directory();
        fgfjgdfk.MakeDirRecursive("user://home/");
    }
}

}
