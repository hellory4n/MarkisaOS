using Godot;
using markisa.mkstoolkit;
using System;
using System.Linq;

namespace markisa.kickstart {

public class ComputerNoises : Node
{
    readonly AudioStream fanNoises = GD.Load<AudioStream>("res://os/assets/computerNoises/194890__saphe__computer-fan.ogg");
    readonly AudioStream diskNoises = GD.Load<AudioStream>("res://os/assets/computerNoises/500168__sad3d__pc-hard-drive-noises.ogg");
    readonly AudioStream clickBeginNoises = GD.Load<AudioStream>("res://os/assets/computerNoises/534103__pbimal__mouse-click-single-00-begin.ogg");
    readonly AudioStream clickEndNoises = GD.Load<AudioStream>("res://os/assets/computerNoises/534103__pbimal__mouse-click-single-00-end.ogg");
    readonly AudioStream keyboardNoises = GD.Load<AudioStream>("res://os/assets/computerNoises/629020__kolombooo__button-click-edited.ogg");

    // i have to make a backing field to not cause an infinite loop :(
    bool doesTheDashboardTrulyExistThough = false;
    public bool DashboardExists {
        get { return doesTheDashboardTrulyExistThough; }
        set {
            doesTheDashboardTrulyExistThough = value;
            if (!value) {
                fanPlayer.VolumeDb = GD.Linear2Db(0.05f); // (10 / 100) / 2
                diskPlayer.VolumeDb = GD.Linear2Db(0.1f); // (5 / 100) * 2
            }
        }
    }

    public double FanSuffering { get; set; } = 10;
    public double DiskSuffering { get; set; } = 5;
    AudioStreamPlayer fanPlayer;
    AudioStreamPlayer diskPlayer;
    AudioStreamPlayer clickBegin;
    AudioStreamPlayer clickEnd;
    AudioStreamPlayer keyboard;

    public override void _Ready()
    {
        // setup the bullshit
        fanPlayer = new AudioStreamPlayer {
            Stream = fanNoises,
            Autoplay = true,
            Bus = "pc"
        };
        diskPlayer = new AudioStreamPlayer {
            Stream = diskNoises,
            Autoplay = true,
            Bus = "pc"
        };
        clickBegin = new AudioStreamPlayer {
            Stream = clickBeginNoises,
            VolumeDb = GD.Linear2Db(0.5f),
            Bus = "pc"
        };
        clickEnd = new AudioStreamPlayer {
            Stream = clickEndNoises,
            VolumeDb = GD.Linear2Db(0.5f),
            Bus = "pc"
        };
        keyboard = new AudioStreamPlayer {
            Stream = keyboardNoises,
            Bus = "pc"
        };
        AddChild(fanPlayer);
        AddChild(diskPlayer);
        AddChild(clickBegin);
        AddChild(clickEnd);
        AddChild(keyboard);

        // so it isn't really loud before you login
        fanPlayer.VolumeDb = GD.Linear2Db(0.05f); // (10 / 100) / 2
        diskPlayer.VolumeDb = GD.Linear2Db(0.1f); // (5 / 100) * 2
    }

    public override void _Process(float delta)
    {
        if (!DashboardExists) {
            return;
        }

        Node windowsVista = GetNode("/root/dashboard/windows");

        // figure out the shit
        FanSuffering = 10;
        DiskSuffering = 5;
        foreach (MksWindow epicWindow in windowsVista.GetChildren()) {
            FanSuffering += epicWindow.MemoryUsage;
            DiskSuffering += epicWindow.DiskUsage;
        }

        // if we use 200% of the cpu it's gonna explode
        FanSuffering = Math.Min(FanSuffering, 100);
        DiskSuffering = Math.Min(DiskSuffering, 100);

        double actualFanStuff = FanSuffering / 100;
        double actualDiskStuff = DiskSuffering / 100;

        fanPlayer.VolumeDb = GD.Linear2Db((float)(actualFanStuff / 2));
        diskPlayer.VolumeDb = GD.Linear2Db((float)(actualDiskStuff / 2));
    }

    // clicking and typing noises lol
    public override void _Input(InputEvent @event)
    {
        if (@event is InputEventMouseButton lol) {
            if (lol.IsReleased()) {
                clickEnd.Play();
            }
            else {
                clickBegin.Play();
            }
        }

        if (@event is InputEventKey haha) {
            if (!haha.IsReleased()) {
                keyboard.Play();
            }
        }
    }
}

}