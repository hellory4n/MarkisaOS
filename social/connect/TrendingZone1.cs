namespace markisa.network {

public class TrendingZone1
{

public static MksConnectZone Data { get; set; } = new MksConnectZone {
    Background = "res://apps/passionfruit/connect/backgrounds/trending.png",
    Month = 1,
    Posts = new MksPost[] {
        new MksPost {
            Username = "Joe McPerson",
            ProfilePicture = "res://os/assets/userIcons/cat.png",
            Verified = true,
            Content = "I'm not a cat!!!!!"
        },

        new MksPost {
            Username = "SMNN News",
            ProfilePicture = "res://os/assets/userIcons/cat.png",
            Verified = true,
            Content = "BREAKING: <ping>Joe McPerson</ping> is a cat.",
            Images = new string[] { "res://os/assets/userIcons/cat.png" }
        },

        new MksPost {
            Username = "Taylor F. Ed",
            ProfilePicture = "res://os/assets/userIcons/cat.png",
            Content = "Who else loves methamphetamine???????? I'm certainly not a federal agent."
        },

        new MksPost {
            Username = "Mall Wares",
            ProfilePicture = "res://os/assets/userIcons/cat.png",
            Content = "Check out this awesome application, it makes you security",
            Link = "malware.org"
        }
    }
};

}

}