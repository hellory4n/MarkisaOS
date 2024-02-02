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
    static PackedScene notificationShit = GD.Load<PackedScene>("res://os/dashboard/notification.tscn");
    static SceneTree sceneTreeSoICanMakeAStaticFunction;

    public override void _Ready()
    {
        var dir = new Directory();
        if (dir.FileExists("user://forcemobile")) {
            forceMobile = true;
        }

        sceneTreeSoICanMakeAStaticFunction = GetTree();
    }

    /// <summary>
    /// It shows a notification :)
    /// </summary>
    public static void Notify(string app, string text)
    {
        var shit = notificationShit.Instance<Panel>();
        sceneTreeSoICanMakeAStaticFunction.Root.AddChild(shit);

        shit.GetNode<RichTextLabel>("text").AppendBbcode($"[b]{app}[/b]\n{text}");
        shit.GetNode<AnimationPlayer>("animation").Play("ghggh");

        // show it in the notification bullshit
        // quite the mouthful
        var noyodthyodtijhidtihujdit = shit.GetNode("/root/dashboard/interface/notifications/ScrollContainer/VBoxContainer");
        var G = notificationShit.Instance<Panel>();
        G.GetNode<RichTextLabel>("text").AppendBbcode($"[b]{app}[/b]\n{text}");
        noyodthyodtijhidtihujdit.AddChild(G);
    }
}

}
