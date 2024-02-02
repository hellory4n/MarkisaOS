using Godot;
using System;
using System.Data;
using System.Globalization;

namespace markisa.dashboard {

public class EvaluateBullshit : LineEdit
{
    public void Fuck(string newText)
    {
        newText = newText.Replace('÷', '/');
        newText = newText.Replace('×', '*');
        newText = newText.Replace(',', '.');

        // this certainly does something
        try {
            var hi = new DataTable();
            var column = new DataColumn("result", typeof(double), newText);
            hi.Columns.Add(column);
            DataRow row = hi.NewRow();
            hi.Rows.Add(row);

            double result = (double)row["result"];
            Text = result.ToString(CultureInfo.InvariantCulture);
        }
        catch (Exception e) {
            Text = "Error";
            throw e;
        }
    }

    public void Suffering() => Fuck(Text);
}

}