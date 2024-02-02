using Godot;
using System;
using System.Globalization;
using System.Linq;

namespace markisa.dashboard {

public class EvaluateBullshit : LineEdit
{
    public void Fuck(string newText)
    {
        newText = newText.Replace('÷', '/');
        newText = newText.Replace('×', '*');
        newText = newText.Replace(',', '.'); // TODO: this probably doesn't work very well with some languages

        // couldn't find a less hideous way to make a character whitelist or whatever
        // don't feel like making some regex bullshit either
        string fuckr = "";
        char[] allowedCharacters = new char[] {
            '0', '1', '2', '3', '4', '5', '6', '7', '8', '9',
            '(', ')', '.', '+', '-', '*', '/'
        };
        foreach (var item in newText) {
            if (allowedCharacters.Contains(item)) {
                fuckr += item;
            }
        }

        var express = new Expression();
        Error bruhMoment = express.Parse(fuckr);

        if (bruhMoment != Error.Ok) {
            Text = "Syntax error";
            return;
        }

        try {
            float epicResult = (float)express.Execute();
            if (express.HasExecuteFailed()) {
                Text = "Calculation error";
            }
            else {
                Text = epicResult.ToString(CultureInfo.InvariantCulture);
            }
        }
        catch (Exception) {
            Text = "Calculation error, maybe the number is too big?";
        }
    }

    public void Suffering() => Fuck(Text);
}

}