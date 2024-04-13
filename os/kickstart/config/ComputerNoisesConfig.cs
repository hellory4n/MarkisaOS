namespace markisa.foundation
{

public class ComputerNoisesConfig : IConfigData
{
    public string GetFilename() => "computerNoises.mksconf";

    public bool Fan { get; set; } = true;
    public bool Disk { get; set; } = true;
    public bool Mouse { get; set; } = true;
    public bool Keyboard { get; set; } = true;
}

}