namespace markisa.foundation
{

public class Banking : IConfigData
{
    public string GetFilename() => "%user/banking.mksconf";

    public BankTransaction[] Transactions { get; set; } = {};
    public decimal Cash { get; set; } = 0;
    public decimal Assets { get; set; } = 0;
    public decimal Debt { get; set; } = 0;
}

public class BankTransaction
{
    public decimal Amount { get; set; } = 0;
    public string Account { get; set; } = "";
    /// <summary>
    /// If true, the user sent. Else, the user received.
    /// </summary>
    public bool Send { get; set; } = false;
}

}