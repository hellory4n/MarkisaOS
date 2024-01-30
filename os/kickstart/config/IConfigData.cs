namespace markisa.foundation
{
interface IConfigData
{
    /// <summary>
    /// Gets the filename of the config. If you're making mods then it's a good idea to put the author before the filename, so instead of <c>data.mksconf</c>, you would make <c>author/data.mksconf</c>, to prevent breaking other mods. Examples:
    /// <list type="bullet">
    /// <item>Global data: <c>data.mksconf</c></item>
    /// <item>User data: <c>%user/data.mksconf</c></item>
    /// <item>App data: <c>%user/apps/data.mksconf</c></item>
    /// <item>Website data: <c>%user/web/example.com/data.mksconf</c></item>
    /// </list>
    /// </summary>
    /// <returns>The filename of the config.</returns>
    string GetFilename();
}
}