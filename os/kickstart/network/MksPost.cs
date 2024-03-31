namespace markisa.network {

public class MksPost
{
    public string Username { get; set; }
    public string ProfilePicture { get; set; }
    public bool Verified { get; set; }
    public string Content { get; set; }
    public string[] Images { get; set; }
    public string Link { get; set; }
    public MksPost[] Replies { get; set; }
}

}