namespace markisa.network {

public class ComedyZone1
{

public static MksConnectZone Data { get; set; } = new MksConnectZone {
    Background = "res://apps/passionfruit/connect/backgrounds/comedy.png",
    Music = "res://apps/passionfruit/connect/music/hereComesTheFunny.mp3",
    Month = 1,
    Posts = new MksPost[] {
        new MksPost {
            User = "Context Out Of Context",
            ProfilePicture = "res://os/assets/userIcons/cat.png",
            Verified = true,
            Content = "MOUNTAIN\nBOTTOM TEXT",
            Images = new string[] { "res://os/assets/wallpapers/highPeaks.jpg" }
        },

        new MksPost {
            User = "Context Out Of Context",
            ProfilePicture = "res://os/assets/userIcons/cat.png",
            Verified = true,
            Content = "There is a suspicious impostor among us.",
        },

        new MksPost {
            User = "Context Out Of Context",
            ProfilePicture = "res://os/assets/userIcons/cat.png",
            Verified = true,
            Content = "yeah i like dark humor *racism*",
        },
    }
};

}

}