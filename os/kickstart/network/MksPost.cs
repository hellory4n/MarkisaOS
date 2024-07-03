namespace markisa.network {

public class MksPost
{
    public string User { get; set; } = "";
    public string ProfilePicture { get; set; } = "";
    public bool Verified { get; set; } = false;
    public string Content { get; set; } = "";
    public string[] Images { get; set; } = new string[] {};
    public string Link { get; set; } = "";
    public MksPost[] Replies { get; set; } = new MksPost[] {};
    public PostZone[] Zones { get; set; } = new PostZone[] {};
}

public enum PostZone
{
    HelpCenter,
    Comedy,
    Technology,
    Entertainment,
    Creativity,
    Discussion
}

}