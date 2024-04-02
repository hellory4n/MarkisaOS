namespace markisa.network {

public class DiscussionZone1
{

public static MksConnectZone Data { get; set; } = new MksConnectZone {
    Background = "res://apps/passionfruit/connect/backgrounds/discussion.png",
    Month = 1,
    Posts = new MksPost[] {
        new MksPost {
            User = "Shakespeare",
            ProfilePicture = "res://os/assets/userIcons/cat.png",
            Verified = true,
            Content = "To be or not to be.",
        },

        new MksPost {
            User = "Aristotle",
            ProfilePicture = "res://os/assets/userIcons/cat.png",
            Verified = true,
            Content = "The only thing I know is that I know nothing.",
        },

        new MksPost {
            User = "Martin Luther King Jr.",
            ProfilePicture = "res://os/assets/userIcons/cat.png",
            Verified = true,
            Content = "I just had a dream, it was fucking wild ngl",
        },

        new MksPost {
            User = "Albert Einstein",
            ProfilePicture = "res://os/assets/userIcons/cat.png",
            Content = "hellory4n is a genius",
        },

        new MksPost {
            User = "Abraham Lincoln",
            ProfilePicture = "res://os/assets/userIcons/cat.png",
            Verified = true,
            Content = "Starting a war so you can keep being racist is pretty bad amirite",
        },

        new MksPost {
            User = "Julius Caesar",
            ProfilePicture = "res://os/assets/userIcons/cat.png",
            Verified = true,
            Content = "Even you, Brutus?",
        },
    }
};

}

}