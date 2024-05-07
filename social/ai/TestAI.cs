using Godot;
using markisa.foundation;
using System;

namespace markisa.network {

public partial class OneSingletonToRuleThemAll : Node
{
    bool happened = false;

    /*public void TestAI()
    {
        if (happened) {
            return;
        }

        if (GetNodeOrNull("/root/dashboard") != null) {
            var xd = GetNode<TextEdit>("/root/dashboard/interface/stickyNotes/TextEdit");
            if (xd.Text.StartsWith("fucking")) {
                Frambos.SendEmail(new MksEmail {
                    User = "Lelcube (god)",
                    ProfilePicture = "res://os/assets/userIcons/cat.png",
                    Content = "I've been spying on you and what you just did is truly frustrageous, i'm gonna fucking take you for a ride"
                });
                happened = true;
            }
        }
    }*/
}

}