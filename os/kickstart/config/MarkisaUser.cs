namespace markisa.foundation
{

public class MarkisaUser : IConfigData
{
    public string GetFilename() => "%user/user.mksconf";

    public uint MajorVersion { get; set; } = 0;
    public uint MinorVersion { get; set; } = 19;
    public uint PatchVersion { get; set; } = 0;

    /// <summary>
    /// The name displayed for the user, not the one used for saving the user's data.
    /// </summary>
    public string DisplayName { get; set; } = "John Doe";
    /// <summary>
    /// The name used when saving user data. Also used on the web, where it gets the @ symbol in front of it.
    /// </summary>
    public string Username { get; set; } = "johndoe1232194363";
    /// <summary>
    /// The photo the user uses.
    /// </summary>
    public string Photo { get; set; } = "res://os/assets/userIcons/cat.png";
}

}