using Godot;
using markisa.foundation;
using System;

namespace markisa.dashboard {

public class MoneyDashboardPanel : Button
{
    public void Beans()
    {
        var config = new Config<Banking>();
        Text = $"Ø{config.Data.Cash:F2}";
    }

    public override void _Pressed()
    {
        var shit = GD.Load<PackedScene>("res://apps/passionfruit/bank/app.tscn");
        GetNode("/root/dashboard/windows").AddChild(shit.Instance());
    }
}

}