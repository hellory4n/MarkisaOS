using Godot;
using System;
using System.Collections.Generic;

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
    public static uint PatchVersion => 2;
    static bool forceMobile = false;
    static PackedScene notificationShit = GD.Load<PackedScene>("res://os/dashboard/notification.tscn");
    static SceneTree sceneTreeSoICanMakeAStaticFunction;

    static Dictionary<SystemSound, AudioStream> AwesomeSounds { get; } = new Dictionary<SystemSound, AudioStream> {
        {SystemSound.Startup,       GD.Load<AudioStream>("res://os/assets/systemSounds/startup.mp3")},
        {SystemSound.Shutdown,      GD.Load<AudioStream>("res://os/assets/systemSounds/shutdown.mp3")},
        {SystemSound.Logout,        GD.Load<AudioStream>("res://os/assets/systemSounds/logout.mp3")},
        {SystemSound.CriticalError, GD.Load<AudioStream>("res://os/assets/systemSounds/criticalError.mp3")},
        {SystemSound.Error,         GD.Load<AudioStream>("res://os/assets/systemSounds/error.mp3")},
        {SystemSound.Notification,  GD.Load<AudioStream>("res://os/assets/systemSounds/notification.mp3")},
        {SystemSound.Question,      GD.Load<AudioStream>("res://os/assets/systemSounds/question.mp3")},
        {SystemSound.Success,       GD.Load<AudioStream>("res://os/assets/systemSounds/success.mp3")},
        {SystemSound.Warning,       GD.Load<AudioStream>("res://os/assets/systemSounds/warning.mp3")}
    };

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

    // when you call it would show as Play(SystemSound.Something), i'm truly a jeenyous
    // i spent more time than i'd like coming up with a terrible spelling of genius
    /// <summary>
    /// Plays a system sound :))
    /// </summary>
    public static void Play(SystemSound sound)
    {
        var dollarsign = new AudioStreamPlayer {
            Stream = AwesomeSounds[sound],
            Autoplay = true,
            Bus = "sound"
        };
        // quite a convoluted way of saying `this.`
        sceneTreeSoICanMakeAStaticFunction.Root.GetNode("/root/Frambos").AddChild(dollarsign);
    }
}

public enum SystemSound
{
    Startup,
    Shutdown,
    Logout,
    Warning,
    Error,
    Notification,
    CriticalError,
    Question,
    Success
}

}
