using Godot;
using markisa.foundation;
using System;

namespace markisa.dashboard {

public class TimeMoneyDashboardPanelMobileMicrosoftWindows : Label
{
    public void Beans()
    {
        var m = Frambos.Now;
        var j = new Config<Banking>();
        Text = $"{m.Year}-{m.Month:D2}-{m.Day:D2} {m.Hour:D2}:{m.Minute:D2}\nØ{j.Data.Cash}";
    }
}

}