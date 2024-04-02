namespace markisa.network {

public class TechnologyZone1
{

public static MksConnectZone Data { get; set; } = new MksConnectZone {
    Background = "res://apps/passionfruit/connect/backgrounds/technology.png",
    Music = "res://apps/passionfruit/connect/music/industrialRevolutionAndItsConsequences.mp3",
    Month = 1,
    Posts = new MksPost[] {
        new MksPost {
            User = "TechLeader",
            ProfilePicture = "res://os/assets/userIcons/cat.png",
            Verified = true,
            Content = "As an ex-metamate (real name for facebook employees) millionaire, I recommend you use JavaScript for banking applications.",
        },

        new MksPost {
            User = "Linus Drop Tips",
            ProfilePicture = "res://os/assets/userIcons/cat.png",
            Verified = true,
            Content = "conputer",
        },

        new MksPost {
            User = "Apple",
            ProfilePicture = "res://os/assets/userIcons/cat.png",
            Verified = true,
            Content = "Buy our latest garbage.",
        },

        new MksPost {
            User = "Not a security researcher",
            ProfilePicture = "res://os/assets/userIcons/cat.png",
            Verified = true,
            Content = "hi so i noticed something was 0.2s slower and found out that every major linux distro with the latest and greatest software has a backdoor xd",
        },

        new MksPost {
            User = "ThePrimeVideo",
            ProfilePicture = "res://os/assets/userIcons/cat.png",
            Verified = true,
            Content = "RUST. NEOVIM.",
        },
    }
};

}

}