using Godot;
using markisa.foundation;
using System;

namespace passionfruit.coreapps.settings {

public class SetLanguage : Node
{
    public override void _Ready()
    {
        ButtonGroup FUC = GetNode<CheckBox>("../englishInnit").Group;
        FUC.Connect("pressed", this, nameof(OnShitAndFuckery));

        // it would be weird to show that english is selected while port of geese is the current language
        var con = new Config<SystemInfo>();
        // checking if a string starts with something isn't supported in switch cases
        if (TranslationServer.GetLocale().StartsWith("pt")) {
            GetNode<CheckBox>("../brazilMentioned").Pressed = true;
        }
        if (TranslationServer.GetLocale().StartsWith("es")) {
            GetNode<CheckBox>("../insertStereotypicalMexicanMusicHere").Pressed = true;
        }
    }

    public void OnShitAndFuckery(Button brh)
    {
        string locale;
        switch (brh.Text) {
            case "Português (Brasil)": locale = "pt"; break;
            case "Español": locale = "es"; break;
            default: locale = "en"; break;
        }

        TranslationServer.SetLocale(locale);

        // save shit
        var fig = new Config<SystemInfo>();
        fig.Data.Language = locale;
        fig.Save();
    }
}

}