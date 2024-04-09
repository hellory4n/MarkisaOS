using System;

namespace markisa.network
{

public class MksMail
{
    public string User { get; set; } = "";
    public string ProfilePicture { get; set; } = "";
    public string Content { get; set; } = "";
    public string[] Images { get; set; }
    public string Link { get; set; }
    // decided when the email is received
    public DateTime Time { get; set; }
}

}