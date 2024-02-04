using Godot;
using markisa.mkstoolkit;
using System;

namespace passionfruit.systemMonitor {

public class ListStuff : ItemList
{
    public override void _Process(float delta)
    {
        Clear();
        Node windowsVista = GetNode("/root/dashboard/windows");
        foreach (MksWindow epicWindow in windowsVista.GetChildren()) {
            AddItem(epicWindow.WindowTitle);
            AddItem($"RAM: {epicWindow.MemoryUsage}%");
            AddItem($"Disk: {epicWindow.DiskUsage}%");

            SetItemDisabled(GetItemCount() - 1, true);
            SetItemDisabled(GetItemCount() - 2, true);
        }
    }
}

}