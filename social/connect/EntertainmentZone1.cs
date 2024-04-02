namespace markisa.network {

public class EntertainmentZone1
{

public static MksConnectZone Data { get; set; } = new MksConnectZone {
    Background = "res://apps/passionfruit/connect/backgrounds/entertainment.png",
    Music = "res://apps/passionfruit/connect/music/garbageGoodCorporate.mp3",
    Month = 1,
    Posts = new MksPost[] {
        new MksPost {
            User = "Unemployed Guy",
            ProfilePicture = "res://os/assets/userIcons/cat.png",
            Content = "MOVIE: THE MOVIE: PART II: PART II HAS A WOMAN!!!!!!!!!!!\n\nTHE MOVIE THE MOVIE PART II FRANCHISE HAS GONE WOKE :(",
        },

        new MksPost {
            User = "Netfilms",
            ProfilePicture = "res://os/assets/userIcons/cat.png",
            Verified = true,
            Content = "Movie: The Movie: Part II: Part II has the first woman in human history.",
        },

        new MksPost {
            User = "Funny Cartoon Man",
            ProfilePicture = "res://os/assets/userIcons/cat.png",
            Verified = true,
            Content = "WATCH MY LATEST VIDEO ABOUT ADULT JOKES IN CARTOONS",
        },
    }
};

}

}