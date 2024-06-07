namespace markisa.foundation
{

public class ReducedMotion : IConfigData
{
    public string GetFilename() => "reducedMotion.mksconf";

    public bool Enabled { get; set; } = false;
}

}