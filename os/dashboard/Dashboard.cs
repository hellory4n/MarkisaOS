using Godot;
using markisa.foundation;
using System;

namespace markisa.dashboard {

public class Dashboard : Control
{
    public override void _Ready()
    {
        Frambos.Play(SystemSound.Startup);

        // mobile mode :)
        if (Frambos.IsOnMobile) {
            GetNode<Control>("interface/panel").Visible = false;
            GetNode<Control>("interface/dock").Visible = false;
            GetNode<Control>("interface/mobileui").Visible = true;
            GetNode<Control>("mobileTimeMoney").Visible = true;
        }
        else {
            GetNode<Control>("interface/panel").Visible = true;
            GetNode<Control>("interface/dock").Visible = true;
            GetNode<Control>("interface/mobileui").Visible = false;
            GetNode<Control>("mobileTimeMoney").Visible = false;
        }

        // load the fucking settings
        var config = new Config<DashboardConfig>();
        GetNode<TextureRect>("wallpaper").Texture = GD.Load<Texture>(config.Data.Wallpaper);

        // show tutorial?
        var config2 = new Config<SystemInfo>();
        if (!config2.Data.Installed) {
            string tutorialPath = Frambos.IsOnMobile ? "tutorial/1mobile" : "tutorial/1desktop";

            GetNode<Control>("tutorial").Visible = true;
            GetNode<Control>(tutorialPath).Visible = true;
        }

        // get free money!!!!!!
        // we do the check here since if this is a new player, the notification should come after the tutorial
        if (config2.Data.Installed) {
            var freemoneyconf = new Config<FreeMoneySchedule>();
            if (freemoneyconf.Data.TimeToReceive) {
                var moneyconf = new Config<Banking>();
                moneyconf.Data.Cash += 1300;
                freemoneyconf.Data.TimeToReceive = false;
                freemoneyconf.Data.PreviousMonth++;
                moneyconf.Save();
                freemoneyconf.Save();
                
                Frambos.Notify("The Government", "You received Ø1,300 as part of the government's war aid program. Your next payment will be next month.");
                Frambos.Play(SystemSound.Notification);
            }
        }
    }

    public void TutorialComplete()
    {
        var config = new Config<SystemInfo>();
        config.Data.Installed = true;
        config.Save();

        var freemoneyconf = new Config<FreeMoneySchedule>();
        if (freemoneyconf.Data.TimeToReceive) {
            var moneyconf = new Config<Banking>();
            moneyconf.Data.Cash += 1300;
            freemoneyconf.Data.TimeToReceive = false;
            freemoneyconf.Data.PreviousMonth++;
            moneyconf.Save();
            freemoneyconf.Save();
            
            Frambos.Notify("The Government", "You received Ø1,300 as part of the government's war aid program. Your next payment will be next month.");
            Frambos.Play(SystemSound.Notification);
        }
    }
}

}