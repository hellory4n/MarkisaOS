using Godot;
using markisa.foundation;
using System;

namespace passionfruit.coreapps.banking {

public class ListTransactions : VBoxContainer
{
    public override void _Ready()
    {
        var config = new Config<Banking>();

        foreach (BankTransaction transaction in config.Data.Transactions) {
            string text;
            if (transaction.Send) {
                text = Tr("{money} sent to {person}")
                    .Replace("{money}", $"Ø{transaction.Amount}")
                    .Replace("{person}", Tr(transaction.Account));
            }
            else {
                text = Tr("{money} sent from {person}")
                    .Replace("{money}", $"Ø{transaction.Amount}")
                    .Replace("{person}", Tr(transaction.Account));
            }

            var label = new Label {
                Text = text,
                Align = Label.AlignEnum.Center,
                SizeFlagsHorizontal = (int)SizeFlags.ExpandFill
            };
            AddChild(label);
        }
    }
}

}