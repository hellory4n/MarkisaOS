namespace markisa.network {

public class TrendingZone1
{

public static MksConnectZone Data { get; set; } = new MksConnectZone {
    Background = "res://apps/passionfruit/connect/backgrounds/trending.png",
    Music = "res://apps/passionfruit/connect/music/quiteABitGoingOn.mp3",
    Month = 1,
    Posts = new MksPost[] {
        new MksPost {
            User = "Joe McPerson",
            ProfilePicture = "res://os/assets/userIcons/cat.png",
            Verified = true,
            Content = "I'm not a cat!!!!!",
            Replies = new MksPost[] {
                new MksPost {
                    User = "Amon Lee Hughman",
                    ProfilePicture = "res://os/assets/userIcons/cat.png",
                    Content = "Yes you are."
                },

                new MksPost {
                    User = "Elon Musk",
                    ProfilePicture = "res://os/assets/userIcons/cat.png",
                    Content = "You are awesome"
                }
            }
        },

        new MksPost {
            User = "SMNN News",
            ProfilePicture = "res://os/assets/userIcons/cat.png",
            Verified = true,
            Content = "BREAKING: <ping>Joe McPerson</ping> is a cat.",
            Images = new string[] { "res://os/assets/userIcons/cat.png" },
            Replies = new MksPost[] {
                new MksPost {
                    User = "Amon Lee Hughman",
                    ProfilePicture = "res://os/assets/userIcons/cat.png",
                    Content = "[reaction image]"
                },

                new MksPost {
                    User = "Elon Musk",
                    ProfilePicture = "res://os/assets/userIcons/cat.png",
                    Content = "Concerning..."
                }
            }
        },

        new MksPost {
            User = "Taylor F. Ed",
            ProfilePicture = "res://os/assets/userIcons/cat.png",
            Content = "Who else loves methamphetamine???????? I'm certainly not a federal agent.",
            Replies = new MksPost[] {
                new MksPost {
                    User = "Posts by Feds",
                    ProfilePicture = "res://os/assets/userIcons/cat.png",
                    Content = "Fantastic"
                },

                new MksPost {
                    User = "Bill Gates",
                    ProfilePicture = "res://os/assets/userIcons/cat.png",
                    Content = "😍😍😍"
                }
            }
        },

        new MksPost {
            User = "Mall Wares",
            ProfilePicture = "res://os/assets/userIcons/cat.png",
            Content = "Check out this awesome application, it makes you security",
            Link = "malware.org",
            Replies = new MksPost[] {
                new MksPost {
                    User = "Elon Musk",
                    ProfilePicture = "res://os/assets/userIcons/cat.png",
                    Content = "I will look into that"
                }
            }
        }
    }
};

}

}