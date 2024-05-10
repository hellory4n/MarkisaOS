namespace markisa.foundation
{

public class AppStuff : IConfigData
{
    public string GetFilename() => "%user/appStuff.mksconf";

    public MksPackage[] InstalledApps { get; set; } = {};
}

}