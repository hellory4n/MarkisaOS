using Godot;
using markisa.mkstoolkit;
using System;
using System.Linq;

namespace markisa.kickstart {

public class ComputerNoises : Node
{
    readonly AudioStream fanNoises = GD.Load<AudioStream>("res://os/assets/computerNoises/194890__saphe__computer-fan.ogg");
    readonly AudioStream diskNoises = GD.Load<AudioStream>("res://os/assets/computerNoises/500168__sad3d__pc-hard-drive-noises.ogg");

    // i have to make a backing field to not cause an infinite loop :(
    bool doesTheDashboardTrulyExistsThough = false;
    public bool DashboardExists {
        get { return doesTheDashboardTrulyExistsThough; }
        set {
            doesTheDashboardTrulyExistsThough = value;
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
        AddChild(fanPlayer);
        AddChild(diskPlayer);

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
}

}