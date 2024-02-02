using Godot;
using markisa.foundation;
using System;

namespace markisa.dashboard {

public class StickyNotesAndShit : TextEdit
{
    public override void _Ready()
    {
        var djghjgjfd = new Config<DashboardConfig>();
        Text = djghjgjfd.Data.StickyNoteText;
    }

    public void TimerBullshit()
    {
        if (HasFocus()) {
            var dkosjkygisrjk = new Config<DashboardConfig>();
            dkosjkygisrjk.Data.StickyNoteText = Text;
            dkosjkygisrjk.Save();
        }
    }
}

}