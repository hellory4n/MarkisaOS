using Godot;
using System;
using System.Collections.Generic;

namespace markisa.mkstoolkit {

public class Webview : Control
{
    /// <summary>
    /// The title of the website.
    /// </summary>
    [Export]
    public string Title { get; set; } = "";
    /// <summary>
    /// The description of the website.
    /// </summary>
    [Export(PropertyHint.MultilineText)]
    public string Description { get; set; } = "";
    /// <summary>
    /// The tags of this website.
    /// </summary>
    [Export]
    public List<string> Tags { get; set; } = new List<string>();
    /// <summary>
    /// The icon of the website, recommended resolution of 28x28
    /// </summary>
    [Export]
    public Texture Icon { get; set; }
    /// <summary>
    /// The music this website plays.
    /// </summary>
    [Export]
    public AudioStream Music { get; set; }
    /// <summary>
    /// If `true`, this website is currently the active one.
    /// </summary>
    public bool IsActive { get; set; }
    AudioStreamPlayer awesomePlayer;

    public override void _Ready()
    {
        awesomePlayer = new AudioStreamPlayer {
            Stream = Music,
            Bus = "music",
            Autoplay = true
        };
        AddChild(awesomePlayer);
    }

    public override void _Process(float delta)
    {
        awesomePlayer.StreamPaused = !IsActive;
    }
}

}