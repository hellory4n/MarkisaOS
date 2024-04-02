namespace markisa.network {

public class CreativityZone1
{

public static MksConnectZone Data { get; set; } = new MksConnectZone {
    Background = "res://apps/passionfruit/connect/backgrounds/creativity.png",
    Month = 1,
    Posts = new MksPost[] {
        new MksPost {
            User = "Picasso (homeless) (gay) (comms open)",
            ProfilePicture = "res://os/assets/userIcons/cat.png",
            Verified = true,
            Content = "LOOK AT MY FUCKING ART",
            Images = new string[] { "res://os/assets/highPeaks/menuButton/normal.png" }
        },
    }
};

}

}