using Godot;
using markisa.foundation;
using System;
using System.Linq;

public class SendYourLifeSavingsToANigerianPrince : Button
{
    ItemList m;
    SpinBox j;

    public override void _Ready()
    {
        m = GetNode<ItemList>("../contacts");
        j = GetNode<SpinBox>("../money");
    }

    public override void _Process(float delta)
    {
        Disabled = m.GetSelectedItems().Length == 0;
    }

    public override void _Pressed()
    {
        // fuck off
        var config = new Config<Banking>();
        config.Data.Cash -= (decimal)j.Value;

        config.Data.Transactions = config.Data.Transactions.Append(new BankTransaction {
            Amount = (decimal)j.Value,
            Account = m.GetItemText(m.GetSelectedItems()[0]),
            Send = true
        }).ToArray();

        config.Save();
        Frambos.Notify("Bank", "Money send successfully.");
        Frambos.Play(SystemSound.Success);
    }
}
