using Godot;
using markisa.foundation;
using System;
using System.Linq;

namespace passionfruit.coreapps.banking {

public class ListTransactions : VBoxContainer
{
    public override void _Ready()
    {
        var config = new Config<Banking>();

        foreach (BankTransaction transaction in config.Data.Transactions.Reverse()) {
            string text;
            if (transaction.Send) {
                text = Tr("{money} sent to {person} - {time}")
                    .Replace("{money}", $"Ø{transaction.Amount}")
                    .Replace("{person}", Tr(transaction.Account))
                    .Replace("{time}", transaction.Time.ToString());
            }
            else {
                text = Tr("{money} sent from {person} - {time}")
                    .Replace("{money}", $"Ø{transaction.Amount}")
                    .Replace("{person}", Tr(transaction.Account))
                    .Replace("{time}", transaction.Time.ToString());
            }

            var label = new Label {
                Text = text,
                Align = Label.AlignEnum.Center,
                SizeFlagsHorizontal = (int)SizeFlags.ExpandFill,
                Autowrap = true
            };
            AddChild(label);
        }
    }
}

}