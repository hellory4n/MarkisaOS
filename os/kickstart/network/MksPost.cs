namespace markisa.network {

public class MksPost
{
    public string User { get; set; }
    public string ProfilePicture { get; set; }
    public bool Verified { get; set; } = false;
    public string Content { get; set; }
    public string[] Images { get; set; }
    public string Link { get; set; }
    public MksPost[] Replies { get; set; }
}

}