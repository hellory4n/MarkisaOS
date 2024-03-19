using Godot;
using markisa.foundation;
using System;

namespace markisa.kickstart {

public class UserList : VBoxContainer
{
    [Export]
    public PackedScene packed;

    public override void _Ready()
    {
        var dir = new Directory();
        dir.MakeDirRecursive("user://home/");
        dir.Open("user://home");
        dir.ListDirBegin(true);
        string filename = dir.GetNext();

        while (filename != "") {
            // get the display name and photo and shit
            Frambos.CurrentUser = filename;
            var m = new Config<MarkisaUser>();

            // make the button stuff
            var button = new Button {
                ThemeTypeVariation = "Secondary",
                Text = m.Data.DisplayName,
                HintTooltip = filename,
                ExpandIcon = true,
                Icon = GD.Load<Texture>(m.Data.Photo),
                ClipText = true
            };
            button.Connect("pressed", this, nameof(Heheheha),
                new Godot.Collections.Array { button }
            );

            AddChild(button);
            filename = dir.GetNext();
        }
    }

    public void Heheheha(Button button)
    {
        Frambos.CurrentUser = button.HintTooltip; // i know
        Frambos.CurrentUserDisplayName = button.Text;
        var dir = new Directory();
        dir.MakeDirRecursive($"user://home/{Frambos.CurrentUser}");

        var ehjfjgjstiesigs = packed.Instance();
        GetTree().Root.AddChild(ehjfjgjstiesigs);
        // so many parents
        GetParent().GetParent().GetParent().GetParent().GetParent().QueueFree();

        var m = GetNode<ComputerNoises>("/root/ComputerNoises");
        m.DashboardExists = true;
    }
}

}