namespace markisa.foundation
{

class SystemInfo : IConfigData
{
    public string GetFilename() => "systemInfo.mksconf";

    /// <summary>
    /// If true, the user has already installed their system.
    /// </summary>
    public bool Installed { get; set; } = false;
    /// <summary>
    /// A list of achievements the user has unlocked.
    /// </summary>
    public string[] Achievements { get; set; } = new string[] {};
    /// <summary>
    /// The current language :)
    /// </summary>
    public string Language { get; set; } = "en";
}

}