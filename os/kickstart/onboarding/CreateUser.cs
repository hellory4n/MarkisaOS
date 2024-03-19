using Godot;
using markisa.foundation;
using System;

namespace markisa.kickstart {

public class CreateUser : Button
{
    [Export(PropertyHint.NodePathValidTypes, "LineEdit")]
    public NodePath fuckingUsername;
    [Export(PropertyHint.NodePathValidTypes, "LineEdit")]
    public NodePath fuckingDisplayName;
    [Export(PropertyHint.NodePathValidTypes, "OptionButton")]
    public NodePath fuckingPhoto;
    [Export]
    public PackedScene myPackedQuestionMarkScenePeriod; // My packed? Scene.

    public override void _Process(float delta)
    {
        var hehe = GetNode<LineEdit>(fuckingUsername).Text.ToLower();
        Disabled = hehe == "con" || hehe == "prn" || hehe == "aux" || hehe == "nul" ||
                   hehe == "com0" || hehe == "com1" || hehe == "com2" || hehe == "com3" ||
                   hehe == "com4" || hehe == "com5" || hehe == "com6" || hehe == "com7" ||
                   hehe == "com8" || hehe == "com9" || hehe == "lpt0" || hehe == "lpt1" ||
                   hehe == "lpt2" || hehe == "lpt3" || hehe == "lpt4" || hehe == "lpt5" ||
                   hehe == "lpt6" || hehe == "lpt7" || hehe == "lpt8" || hehe == "lpt9";
    }

    public override void _Pressed()
    {
        // fuck
        var shitfuckeryUsername = GetNode<LineEdit>(fuckingUsername);
        var shitfuckeryDisplayName = GetNode<LineEdit>(fuckingDisplayName);
        var shitfuckeryPhoto = GetNode<OptionButton>(fuckingPhoto);

        // epic way of making the username thing correct since i can't be bothered to deal with regex
        string username = shitfuckeryUsername.Text.Replace("<", "");
        username = username.Replace(">", "");
        username = username.Replace(":", "");
        username = username.Replace("\\", "");
        username = username.Replace("/", "");
        username = username.Replace("?", "");
        username = username.Replace("*", "");
        username = username.Replace(".", "");
        username = username.Replace(" ", "");
        username = username.ToLower();
        
        // photo stuff
        string photo = "";
        switch (shitfuckeryPhoto.Selected) {
            case 0: photo = "res://os/assets/userIcons/cat.png"; break;
            case 1: photo = "res://os/assets/userIcons/flower.png"; break;
            case 2: photo = "res://os/assets/userIcons/balloons.png"; break;
            case 3: photo = "res://os/assets/userIcons/car.png"; break;
            case 4: photo = "res://os/assets/userIcons/dog.png"; break;
            case 5: photo = "res://os/assets/userIcons/duck.png"; break;
            case 6: photo = "res://os/assets/userIcons/pancakes.png"; break;
            case 7: photo = "res://os/assets/userIcons/brushes.png"; break;
            case 8: photo = "res://os/assets/userIcons/shuttle.png"; break;
            case 9: photo = "res://os/assets/userIcons/football.png"; break;
        }

        var heheheha = new MarkisaUser {
            MajorVersion = Frambos.MajorVersion,
            MinorVersion = Frambos.MinorVersion,
            PatchVersion = Frambos.PatchVersion,
            DisplayName = shitfuckeryDisplayName.Text,
            Username = username,
            Photo = photo
        };

        

        Frambos.CurrentUser = username;
        Frambos.CurrentUserDisplayName = heheheha.DisplayName;
        var dir = new Directory();
        dir.MakeDirRecursive($"user://home/{Frambos.CurrentUser}");
        var consOfFigs = new Config<MarkisaUser> {
            Data = heheheha
        };
        consOfFigs.Save();

        var njsjhmjdfhfkdo = myPackedQuestionMarkScenePeriod.Instance(); // My packed? Scene.
        GetTree().Root.AddChild(njsjhmjdfhfkdo);
        // quite a few parents obtained
        GetParent().GetParent().GetParent().GetParent().QueueFree();

        var m = GetNode<ComputerNoises>("/root/ComputerNoises");
        m.DashboardExists = true;
    }
}

}