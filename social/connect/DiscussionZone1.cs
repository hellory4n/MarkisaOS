namespace markisa.network {

public class DiscussionZone1
{

public static MksConnectZone Data { get; set; } = new MksConnectZone {
    Background = "res://apps/passionfruit/connect/backgrounds/discussion.png",
    Music = "res://apps/passionfruit/connect/music/fancySchmancy.mp3",
    Month = 1,
    Posts = new MksPost[] {
        new MksPost {
            User = "Shakespeare",
            ProfilePicture = "res://os/assets/userIcons/cat.png",
            Verified = true,
            Content = "To be or not to be.",
            Replies = new MksPost[] {
                new MksPost {
                    User = "Teachers",
                    ProfilePicture = "res://os/assets/userIcons/cat.png",
                    Verified = true,
                    Content = "True..."
                }
            }
        },

        new MksPost {
            User = "Aristotle",
            ProfilePicture = "res://os/assets/userIcons/cat.png",
            Verified = true,
            Content = "The only thing I know is that I know nothing.",
            Replies = new MksPost[] {
                new MksPost {
                    User = "Albert Einstein (real)",
                    ProfilePicture = "res://os/assets/userIcons/cat.png",
                    Verified = true,
                    Content = "I know a lot"
                }
            }
        },

        new MksPost {
            User = "Martin Luther King Jr.",
            ProfilePicture = "res://os/assets/userIcons/cat.png",
            Verified = true,
            Content = "I just had a dream, it was fucking wild ngl",
            Replies = new MksPost[] {
                new MksPost {
                    User = "Martin Luther King Jr.",
                    ProfilePicture = "res://os/assets/userIcons/cat.png",
                    Verified = true,
                    Content = "Racism is bad."
                }
            }
        },

        new MksPost {
            User = "Albert Einstein",
            ProfilePicture = "res://os/assets/userIcons/cat.png",
            Content = "hellory4n is a genius",
            Replies = new MksPost[] {
                new MksPost {
                    User = "hellory4n",
                    ProfilePicture = "res://os/assets/userIcons/cat.png",
                    Verified = true,
                    Content = "As hellory4n I can confirm"
                },

                new MksPost {
                    User = "Albert Einstein (real)",
                    ProfilePicture = "res://os/assets/userIcons/cat.png",
                    Verified = true,
                    Content = "I'm the real Albert Einstein"
                }
            }
        },

        new MksPost {
            User = "Abraham Lincoln",
            ProfilePicture = "res://os/assets/userIcons/cat.png",
            Verified = true,
            Content = "Starting a war so you can keep being racist is pretty bad amirite",
            Replies = new MksPost[] {
                new MksPost {
                    User = "The concept of racism",
                    ProfilePicture = "res://os/assets/userIcons/cat.png",
                    Verified = true,
                    Content = ":("
                }
            }
        },

        new MksPost {
            User = "Julius Caesar",
            ProfilePicture = "res://os/assets/userIcons/cat.png",
            Verified = true,
            Content = "Even you, Brutus?",
            Replies = new MksPost[] {
                new MksPost {
                    User = "Brutus",
                    ProfilePicture = "res://os/assets/userIcons/cat.png",
                    Verified = true,
                    Content = "Fuck off"
                }
            }
        },
    }
};

}

}