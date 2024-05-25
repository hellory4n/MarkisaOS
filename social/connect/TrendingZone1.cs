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
                    User = "Daily Thoughts",
                    ProfilePicture = "social/connectpeople/dailyThoughts.png",
                    Content = "how did you do that bold thing?"
                },

                new MksPost {
                    User = "Ross Tibeeth",
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
    }
};

}

}