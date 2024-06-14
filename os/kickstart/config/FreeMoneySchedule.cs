namespace markisa.foundation
{

public class FreeMoneySchedule : IConfigData
{
    public string GetFilename() => "%user/freeMoneySchedule.mksconf";

    public uint PreviousMonth { get; set; } = 0;
    public bool TimeToReceive { get; set; } = true;
}

}