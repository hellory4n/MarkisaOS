namespace markisa.network {

class MksMessage
{
    public string User { get; set; }
    public string Content { get; set; }
    public string[] Images { get; set; }
    public string Link { get; set; }
    public MksMessageReply[] ReplyChoices { get; set; }
}

}