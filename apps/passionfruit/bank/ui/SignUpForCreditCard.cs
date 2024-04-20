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
            Content = Tr("Dear {user},(/n)(/n)We regret to inform you that your recent application for a credit card has been declined. We understand that this may be disappointing news, and we appreciate the time you took to apply with us.(/n)(/n)Thank you for considering the National Lelclub Bank for your financial needs. We appreciate the opportunity to serve you, and we wish you the best in your financial journey.(/n)(/n)Sincerely,(/n)Andrew Talley(/n)National Lelclub Bank").Replace("(/n)", "\n").Replace("{user}", Frambos.CurrentUserDisplayName)
        };

        Frambos.SendEmail(mail);
    }
}
