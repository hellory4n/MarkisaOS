namespace markisa.network {

public class TrendingZone1
{

public static MksConnectZone Data { get; set; } = new MksConnectZone {
    Background = "res://apps/passionfruit/connect/backgrounds/trending.png",
    Music = "res://apps/passionfruit/connect/music/quiteABitGoingOn.mp3",
    Month = 1,
    Posts = new MksPost[] {
        new MksPost {
            User = "Ross Tibeeth (.com)",
            ProfilePicture = "res://web/rosstibeeth.com/assets/rossHimself.png",
            Verified = true,
            Content = "My wood album [b]James VS The Stars[/b] is out! This is a breakthrough in music composition and storytelling",
            Images = new string[] { "res://web/rosstibeeth.com/assets/jvstAd.png" },
            Link = "rosstibeeth.com",
            Replies = new MksPost[] {
                new MksPost {
                    User = "iredvent",
                    ProfilePicture = "res://web/rosstibeeth.com/assets/rossHimself.png",
                    Content = "can i marry you"
                },

                new MksPost {
                    User = "Ross Tibeeth",
                    Verified = true,
                    ProfilePicture = "res://web/rosstibeeth.com/assets/rossHimself.png",
                    Content = "<ping>iredvent</ping> wtf"
                },

                new MksPost {
                    User = "Daily Thoughts",
                    ProfilePicture = "social/connectpeople/dailyThoughts.png",
                    Content = "how did you do that bold thing?"
                },

                new MksPost {
                    User = "Ross Tibeeth",
                    Verified = true,
                    ProfilePicture = "res://web/rosstibeeth.com/assets/rossHimself.png",
                    Content = "<ping>Daily Thoughts</ping> [ b] this without the spaces[ /b]"
                },

                new MksPost {
                    User = "Daily Thoughts",
                    ProfilePicture = "social/connectpeople/dailyThoughts.png",
                    Content = "<ping>Ross Tibeeth</ping> [b]test[/b]"
                },

                new MksPost {
                    User = "Daily Thoughts",
                    ProfilePicture = "social/connectpeople/dailyThoughts.png",
                    Content = "holy shit"
                },
            }
        },

        new MksPost {
            User = "iredvent",
            ProfilePicture = "res://web/rosstibeeth.com/assets/rossHimself.png",
            Content = "ROSS IS A BITCH he broke up with me :(",
            Replies = new MksPost[] {
                new MksPost {
                    User = "Ross Smith",
                    ProfilePicture = "res://os/assets/userIcons/duck.png",
                    Content = "Who are you?"
                },

                new MksPost {
                    User = "Ross Tibeeth (.com)",
                    Verified = true,
                    ProfilePicture = "res://web/rosstibeeth.com/assets/rossHimself.png",
                    Content = "i never dated you"
                },

                new MksPost {
                    User = "Daily Thoughts",
                    ProfilePicture = "social/connectpeople/dailyThoughts.png",
                    Content = "understandable"
                },
            }
        },

        new MksPost {
            User = "Daily Thoughts",
            ProfilePicture = "social/connectpeople/dailyThoughts.png",
            Content = "if i kill my neighbor it's murder, if i kill the president it's an assassination",
            Replies = new MksPost[] {
                new MksPost {
                    User = "Ross Smith",
                    ProfilePicture = "res://os/assets/userIcons/duck.png",
                    Content = "What?????"
                },

                new MksPost {
                    User = "Rob Smith",
                    ProfilePicture = "res://os/assets/userIcons/duck.png",
                    Content = "Stop copying me"
                },

                new MksPost {
                    User = "Ross Smith",
                    ProfilePicture = "res://os/assets/userIcons/duck.png",
                    Content = "?"
                },
            }
        },
    }
};

}

}