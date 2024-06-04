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
            ProfilePicture = "res://social/connectpeople/dailyThoughts.png",
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
        
        new MksPost {
            User = "Daily Thoughts",
            ProfilePicture = "res://social/connectpeople/dailyThoughts.png",
            Content = "imagine if we're'all just virtual people on a game with a dumb idea",
            Replies = new MksPost[] {
                new MksPost {
                    User = "Rob Smith",
                    ProfilePicture = "res://os/assets/userIcons/duck.png",
                    Content = "RELATABLE"
                },
            }
        },

        new MksPost {
            User = "Daily Thoughts",
            ProfilePicture = "res://social/connectpeople/dailyThoughts.png",
            // translators: this can be any tongue twister, doesn't matter
            Content = "How much wood would a woodchuck chuck if a woodchuck could chuck wood?",
            Replies = new MksPost[] {
                new MksPost {
                    User = "John A. Melton",
                    ProfilePicture = "res://os/assets/userIcons/dog.png",
                    Content = "Haven't thought about that, I agree honestly"
                },
            }
        },

        new MksPost {
            User = "John A. Melton",
            ProfilePicture = "res://os/assets/userIcons/dog.png",
            Content = "Just noticed i have 206470572039523 downloads :)",
            Replies = new MksPost[] {
                new MksPost {
                    User = "Faster PC",
                    ProfilePicture = "res://social/connectpeople/fasterpc.png",
                    Content = "Wow, browsing through 206470572039523 downloads must be tricky, IF ONLY THERE WAS AN APP THAT HELPED WITH THAT (it's fasterpc)",
                    Link = "fasterpc.com"
                },

                new MksPost {
                    User = "Rob Smith",
                    ProfilePicture = "res://os/assets/userIcons/duck.png",
                    // translators: it's supposed to clip at the end
                    Content = "<ping>Faster PC</ping> don't download it's a virus don't download it's a virus don't download it's a virus don't download it's a virus don't download it's a virus don't download it's a virus don't download it's a virus don't download it's a virus don't download it's a virus don't download it's a virus don't download it's a virus don't download it's a virus don't download it's a virus don't download it's a virus don't download it's a virus don't download it's a virus don't download it's a virus don't download it's a virus don't download it's a virus don't download it's a virus don't download it's a virus don't download it's a virus don't download it's a virus don't download it's a virus don't download it's a virus don't download it's a virus don't downlo"
                },
            }
        },

        new MksPost {
            User = "Daniel McLeinad",
            ProfilePicture = "res://os/assets/userIcons/pancakes.png",
            Content = "eating a pizza, i'm miserable",
            Replies = new MksPost[] {
                new MksPost {
                    User = "Faster PC",
                    ProfilePicture = "res://social/connectpeople/fasterpc.png",
                    Content = "You know what's also miserable? YOUR COMPUTER WITH ALL THAT GARBAGE! DOWNLOAD FASTERPC TODAY",
                    Link = "fasterpc.com"
                },

                new MksPost {
                    User = "Rob Smith",
                    ProfilePicture = "res://os/assets/userIcons/duck.png",
                    Content = "relatable (also fasterpc is a virus)"
                },
            }
        },

        new MksPost {
            User = "Daniel McLeinad",
            ProfilePicture = "res://os/assets/userIcons/pancakes.png",
            Content = "still eating a pizza, i'm still miserable",
            Replies = new MksPost[] {
                new MksPost {
                    User = "Faster PC",
                    ProfilePicture = "res://social/connectpeople/fasterpc.png",
                    Content = "You know what's also miserable? YOUR COMPUTER WITH ALL THAT GARBAGE! DOWNLOAD FASTERPC TODAY",
                    Link = "fasterpc.com"
                },

                new MksPost {
                    User = "Rob Smith",
                    ProfilePicture = "res://os/assets/userIcons/duck.png",
                    Content = "True... (FASTER PC IS MALWARE)"
                },
            }
        },

        new MksPost {
            User = "Daniel McLeinad",
            ProfilePicture = "res://os/assets/userIcons/pancakes.png",
            // translators: james vs the stars is a reference to ross tibeeth, you probably already translated it
            Content = "just listened to james vs the stars, does anybody genuinely like this shit?",
            Replies = new MksPost[] {
                new MksPost {
                    User = "Daniel McLeinad",
                    ProfilePicture = "res://os/assets/userIcons/pancakes.png",
                    Content = "link here by the way",
                    Link = "rosstibeeth.com"
                },

                new MksPost {
                    User = "Faster PC",
                    ProfilePicture = "res://social/connectpeople/fasterpc.png",
                    Content = "You know what's something that people genuinely like? FASTERPC! CLEAN YOUR PC TODAY!",
                    Link = "fasterpc.com"
                },

                new MksPost {
                    User = "Ross Tibeeth (.com)",
                    ProfilePicture = "res://web/rosstibeeth.com/assets/rossHimself.png",
                    // translators: this is an answer to "does anybody genuinely like this shit?"
                    Content = "I do"
                },

                new MksPost {
                    User = "Rob Smith",
                    ProfilePicture = "res://os/assets/userIcons/duck.png",
                    Content = "<ping>Faster PC</ping> MALWARE"
                },
            }
        },

        new MksPost {
            User = "FasterPC",
            ProfilePicture = "res://social/connectpeople/fasterpc.png",
            Content = "Slow PC? Use FasterPC! It's free!",
            Link = "fasterpc.org",
            Replies = new MksPost[] {
                new MksPost {
                    User = "Rob Smith",
                    ProfilePicture = "res://os/assets/userIcons/duck.png",
                    Content = "MALWARE!!!"
                },

                new MksPost {
                    User = "FasterPC",
                    ProfilePicture = "res://social/connectpeople/fasterpc.png",
                    Content = "<ping>Rob Smith</ping> What?"
                },

                new MksPost {
                    User = "Rob Smith",
                    ProfilePicture = "res://os/assets/userIcons/duck.png",
                    Content = "<ping>FasterPC</ping> your app shows ads that scam people"
                },

                new MksPost {
                    User = "Faster PC",
                    ProfilePicture = "res://social/connectpeople/fasterpc.png",
                    Content = "<ping>FasterPC</ping> is a virus, <ping>Faster PC</ping> (this account) is the official!!",
                    Link = "fasterpc.com"
                },
            }
        },
    }
};

}

}