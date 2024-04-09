namespace markisa.foundation {

/// <summary>
/// Btw everything is -100 to 100
/// </summary>
class StoryProgress : IConfigData
{
    public string GetFilename() => "%user/storyProgress.mksconf";
    
    /// <summary>
    /// The current month you're in, from 1 to 12 (the game ends in december)
    /// </summary>
    public uint Month { get; set; } = 1;
    /// <summary>
    /// Randomized every time you start a new month
    /// </summary>
    public uint Day { get; set; } = 1;
    /// <summary>
    /// -100 = everyone loves you, 100 = everyone loves the government
    /// </summary>
    public int PublicSupport { get; set; } = 0;
    /// <summary>
    /// -100 = the government has lost all control, 100 = everything you do could fuck you over
    /// </summary>
    public int GovernmentRepression { get; set; } = 0;
    /// <summary>
    /// -100 = complete economic collapse, 100 = fully automated luxury capitalism
    /// </summary>
    public int EconomicStability { get; set; } = 0;
    /// <summary>
    /// -100 = anything but the government, 100 = anything for the government
    /// </summary>
    public int MilitaryLoyalty { get; set; } = 0;
    /// <summary>
    /// -100 = complete outsider, 100 = you're the fucking president
    /// </summary>
    public int GovernmentStatus { get; set; } = 0;
    /// <summary>
    /// -100 = everyone is just chill, 100 = there's violent protests every 5 minutes
    /// </summary>
    public int CivilUnrest { get; set; } = 0;
    /// <summary>
    /// -100 = all of the infrastructure is fine, all of the infrastructure is broken
    /// </summary>
    public int TechnologicalAdvantage { get; set; } = 0;
    /// <summary>
    /// -100 = it's pretty clear that it's just lies, 100 = everyone believes the government
    /// </summary>
    public int PropagandaEffectiveness { get; set; } = 0;
}

}