namespace markisa.foundation
{

class DashboardConfig : IConfigData
{
    public string GetFilename() => "%user/dashboardConfig.mksconf";

    public string Wallpaper { get; set; } = "res://os/assets/wallpapers/highPeaks.jpg";
    public string Theme { get; set; } = "res://os/assets/highPeaksBlue/theme.tres";
    public string[] ExtraThemes { get; set; } = new string[] {};
    public string[] ExtraWallpapers { get; set; } = new string[] {};
    public string StickyNoteText { get; set; } = "";
}

}