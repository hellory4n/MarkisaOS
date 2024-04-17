using Godot;
using markisa.foundation;
using markisa.network;
using System;

public class SignUpForCreditCard : Button
{
    public override void _Pressed()
    {
        var timer = new Timer {
            Autostart = true,
            WaitTime = 7,
            OneShot = true
        };
        AddChild(timer);
        timer.Connect("timeout", this, nameof(AnnounceTheInevitableFateOfTheUsersCreditCard));
    }

    public void AnnounceTheInevitableFateOfTheUsersCreditCard()
    {
        var mail = new MksEmail {
            User = Tr("National Lelclub Bank"),
            ProfilePicture = "res://apps/passionfruit/bank/nationalLelclubBank.png",
            Content = Tr(
@"Dear {user},

We regret to inform you that your recent application for a credit card has been declined. We understand that this may be disappointing news, and we appreciate the time you took to apply with us.

Thank you for considering the National Lelclub Bank for your financial needs. We appreciate the opportunity to serve you, and we wish you the best in your financial journey.

Sincerely,
Andrew Talley
National Lelclub Bank").Replace("{user}", Frambos.CurrentUserDisplayName)
        };

        Frambos.SendEmail(mail);
    }
}
