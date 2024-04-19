using Godot;
using markisa.foundation;
using System;

namespace markisa.dashboard {

public class TimeDashboardPanel : Button
{
    public override void _Process(float delta)
    {
        var m = Frambos.Now;
        Text = $"{m.Year}-{m.Month:D2}-{m.Day:D2} {m.Hour:D2}:{m.Minute:D2}";
    }
}

}