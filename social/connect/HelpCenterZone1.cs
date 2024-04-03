namespace markisa.network {

public class HelpCenterZone1
{

public static MksConnectZone Data { get; set; } = new MksConnectZone {
    Background = "res://apps/passionfruit/connect/backgrounds/helpCenter.png",
    Music = "res://apps/passionfruit/connect/music/fairlyCorporateSong.mp3",
    Month = 1,
    Posts = new MksPost[] {
        new MksPost {
            User = "Joe McPerson",
            ProfilePicture = "res://os/assets/userIcons/cat.png",
            Verified = true,
            Content = "How do I do thing?",
            Replies = new MksPost[] {
                new MksPost {
                    User = "Mall Wares",
                    ProfilePicture = "res://os/assets/userIcons/cat.png",
                    Content = "Simply download this application",
                    Link = "malware.org"
                }
            }
        },

        new MksPost {
            User = "Joe McPerson",
            ProfilePicture = "res://os/assets/userIcons/cat.png",
            Verified = true,
            Content = "How to get money online?",
            Replies = new MksPost[] {
                new MksPost {
                    User = "Mall Wares",
                    ProfilePicture = "res://os/assets/userIcons/cat.png",
                    Content = "Simply download this application",
                    Link = "malware.org"
                }
            }
        },

        new MksPost {
            User = "Joe McPerson",
            ProfilePicture = "res://os/assets/userIcons/cat.png",
            Verified = true,
            Content = "How to overthrow the local government?",
            Replies = new MksPost[] {
                new MksPost {
                    User = "Mall Wares",
                    ProfilePicture = "res://os/assets/userIcons/cat.png",
                    Content = "This application will guide you through this exciting process",
                    Link = "malware.org"
                }
            }
        },
    }
};

}

}