using Godot;
using markisa.network;
using System;
using System.Collections.Generic;
using System.Linq;

namespace markisa.foundation
{

public class Frambos : Node
{
    public static Vector2 Resolution { get; set; } = new Vector2(853, 480);
    public static bool IsOnMobile => OS.GetName() == "Android" || forceMobile;
    public static string CurrentUser { get; set; } = "";
    public static string CurrentUserDisplayName { get; set; } = "";
    public static uint MajorVersion => 0;
    public static uint MinorVersion => 18;
    public static uint PatchVersion => 0;
    /// <summary>
    /// The current time in game.
    /// </summary>
    public static DateTime Now { get {
        if (CurrentUser == "") {
            return new DateTime();
        }

        var config = new Config<StoryProgress>();
        var m = new DateTime(2071, (int)config.Data.Month, (int)config.Data.Day, DateTime.Now.Hour,
                             DateTime.Now.Minute, DateTime.Now.Second);
        return m;
    }}

    static bool forceMobile = false;
    static PackedScene notificationShit = GD.Load<PackedScene>("res://os/dashboard/notification.tscn");
    static PackedScene peekAtText = GD.Load<PackedScene>("res://os/dashboard/textpeek.tscn");
    static Panel text;
    static LineEdit peek;
    static SceneTree oopMoment;

    static Dictionary<SystemSound, AudioStream> AwesomeSounds { get; } = new Dictionary<SystemSound, AudioStream> {
        {SystemSound.Startup,       GD.Load<AudioStream>("res://os/assets/systemSounds/startup.mp3")},
        {SystemSound.Shutdown,      GD.Load<AudioStream>("res://os/assets/systemSounds/shutdown.mp3")},
        {SystemSound.Error,         GD.Load<AudioStream>("res://os/assets/systemSounds/error.mp3")},
        {SystemSound.Notification,  GD.Load<AudioStream>("res://os/assets/systemSounds/notification.mp3")},
        {SystemSound.Confirm,       GD.Load<AudioStream>("res://os/assets/systemSounds/confirm.mp3")},
    };

    readonly Texture cursor = GD.Load<Texture>("res://os/assets/highPeaks/cursors/cursor.png");
    readonly Texture pointingHand = GD.Load<Texture>("res://os/assets/highPeaks/cursors/pointingHand.png");
    readonly Texture ibeam = GD.Load<Texture>("res://os/assets/highPeaks/cursors/ibeam.png");

    public override void _Ready()
    {
        var dir = new Directory();
        if (dir.FileExists("user://forcemobile")) {
            forceMobile = true;
        }
        
        // don't make everything ginormous on desktop
		// there's an option to do that from the project settings but it means
		// i don't get to see how it would look on mobile, so i prefer this
		if (!IsOnMobile) {
			GetTree().SetScreenStretch(
				SceneTree.StretchMode.Mode2d, SceneTree.StretchAspect.Keep, OS.GetScreenSize());
			Resolution = OS.GetScreenSize();
		}
        // on mobile we have to handle notches instead
		else {
            // we check the actual OS so forcing mobile on desktop isn't
            // completely broken
            Vector2 fullSize = GetViewport().GetVisibleRect().Size;
            Vector2 safeArea = OS.GetWindowSafeArea().Size;
            // we have to do this thing since high DPI phones exist, and that means
            // things would get pretty small
            var safeAspect = safeArea.x / safeArea.y;
            var widthLol = 480 * safeAspect;

            GetTree().SetScreenStretch(
                SceneTree.StretchMode.Mode2d, SceneTree.StretchAspect.Keep, new Vector2(widthLol, 480));
            
            Resolution = new Vector2(widthLol, 480);
		}

        // lcoalziation glboalstizagioyn internalizitation
		var config = new Config<SystemInfo>();

		var file = new File();
		if (file.FileExists("user://yestheuserhasindeedopenedthegameforthefirsttime")) {
			TranslationServer.SetLocale(config.Data.Language);
		}
		else {
			TranslationServer.SetLocale(OS.GetLocaleLanguage());
			config.Data.Language = OS.GetLocaleLanguage();
			config.Save();

			// so we don't overwrite what the user chose everytime the game launches :)
			file.Open("user://yestheuserhasindeedopenedthegameforthefirsttime", File.ModeFlags.Write);
			file.Close();
		}

        oopMoment = GetTree();

        text = peekAtText.Instance<Panel>();
        // add_child: Parent node is busy setting up children, add_node() failed. Consider using call_deferred("add_child", child) instead.
        GetTree().Root.CallDeferred("add_child", text);
        peek = text.GetNode<LineEdit>("peek");
        text.Visible = false;

        // awesome custom cursors :)
        Input.SetCustomMouseCursor(cursor, Input.CursorShape.Arrow, new Vector2(11, 8));
        Input.SetCustomMouseCursor(pointingHand, Input.CursorShape.PointingHand, new Vector2(17, 8));
        Input.SetCustomMouseCursor(ibeam, Input.CursorShape.Ibeam, new Vector2(11, 8));
    }

    public override void _Process(float delta)
    {
        // we don't need textpeek on a pc :)
        if (!IsOnMobile) {
            return;
        }

        text.Visible = OS.GetVirtualKeyboardHeight() > 0;

        // only controls can get the focus owner
        if (text.GetFocusOwner() is LineEdit ha) {
            // HE SAID IT
            // TEXT PEEK ‼️
            peek.Text = ha.Text;
        }

        if (text.GetFocusOwner() is TextEdit lol) {
            peek.Text = lol.GetLine(lol.CursorGetLine());
        }

        // so you can actually see shit :)))))))
        text.Raise();
    }

    /// <summary>
    /// It shows a notification :)
    /// </summary>
    public static void Notify(string app, string text, bool autoTranslate = true)
    {
        var shit = notificationShit.Instance<Panel>();
        oopMoment.Root.AddChild(shit);

        if (autoTranslate) {
            shit.GetNode<RichTextLabel>("text").AppendBbcode($"[b]{oopMoment.Tr(app)}[/b]\n{oopMoment.Tr(text)}");
        }
        else {
            shit.GetNode<RichTextLabel>("text").AppendBbcode($"[b]{app}[/b]\n{text}");
        }
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
        oopMoment.Root.GetNode("/root/Frambos").AddChild(dollarsign);
    }

    /// <summary>
    /// Gets the real path from an URL, or "404" if it's not found
    /// </summary>
    public static string GetRealWebPath(string url)
    {
        // maybe it happens to already be exactly what we want?
        if (ResourceLoader.Exists(url)) {
            return url;
        }
        
        // maybe the user put web:// and we need to handle that
        if (url.StartsWith("web://")) {
            if (ResourceLoader.Exists(url.Replace("web://", "res://web/"))) {
                return url.Replace("web://", "res://web/");
            }

            // maybe we need .tscn?
            if (ResourceLoader.Exists(url.Replace("web://", "res://web/") + ".tscn")) {
                return url.Replace("web://", "res://web/") + ".tscn";
            }

            // maybe we need home.tscn?
            if (ResourceLoader.Exists(url.Replace("web://", "res://web/") + "/home.tscn"))  {
                return url.Replace("web://", "res://web/") + "/home.tscn";
            }
        }

        // maybe the user didn't put web://
        if (!url.StartsWith("web://")) {
            if (ResourceLoader.Exists("res://web/" + url)) {
                return "res://web/" + url;
            }

            // maybe we need .tscn?
            if (ResourceLoader.Exists("res://web/" + url + ".tscn")) {
                return "res://web/" + url + ".tscn";
            }

            // maybe we need home.tscn?
            if (ResourceLoader.Exists("res://web/" + url + "/home.tscn"))  {
                return "res://web/" + url + "/home.tscn";
            }
        }

        // lol
        if (url == "") {
            return "res://apps/passionfruit/websites/browserSites/newtab.tscn";
        }

        // maybe it should be redirected?
        string he = "404";
        foreach (var item in Redirector5000.Stuff) {
            if (url.Replace(item.Key, item.Value) != url) {
                he = GetRealWebPath(url.Replace(item.Key, item.Value));
                break;
            } 
        }

        // yes
        // he should either be 404 or the redirected address
        return he;
    }

    /// <summary>
    /// Sends an email to the user.
    /// </summary>
    public static void SendEmail(MksEmail email)
    {
        if (CurrentUser == "") {
            return;
        }
        
        email.Time = Now;
        
        var config = new Config<SocialInfo>();
        config.Data.Emails = config.Data.Emails.Append(email).ToArray();
        if (!config.Data.Contacts.Contains(email.User)) {
            config.Data.Contacts = config.Data.Contacts.Append(email.User).ToArray();
        }
        config.Save();
        
        // localization is some tricky stuff
        if (email.User != "You") {
            switch (TranslationServer.GetLocale()) {
                default: Notify($"{email.User} sent an email", email.Content); break;
                case "pt": Notify($"{oopMoment.Tr(email.User)} enviou um email", oopMoment.Tr(email.Content)); break;
                case "es": Notify($"{oopMoment.Tr(email.User)} te a enviado un email", oopMoment.Tr(email.Content)); break;
                case "id": Notify($"{oopMoment.Tr(email.User)} mengirimkan email", oopMoment.Tr(email.Content)); break;
            }
            Play(SystemSound.Notification);
        }

        var configSequel = new Config<StringFinder>();
        configSequel.Data.Strings.Add(new HashSet<TranslationString>() {
            new TranslationString {
                Path = "res://apps/passionfruit/email/app.tscn",
                MessageId = email.User
            },

            new TranslationString {
                Path = "res://apps/passionfruit/email/app.tscn",
                MessageId = email.Content
            },
        });
        configSequel.Save();

        if (configSequel.Data.Enabled) {
            Notify("System", "Translation strings unlocked. Translate them at BetaTools.");
            Play(SystemSound.Notification);
        }
    }
}

public enum SystemSound
{
    Startup,
    Shutdown,
    Confirm,
    Error,
    Notification,
    CriticalError,
}

}
