using Godot;
using markisa.foundation;
using System;

namespace markisa.kickstart {

public class SetLanguageAndShit : OptionButton
{
    public override void _Ready()
    {
        if (TranslationServer.GetLocale().StartsWith("pt")) {
            Selected = 1;
        }
        else {
            Selected = 0;
        }
    }

    public void WhenSomeBullshitIsSelected(int index)
    {
        string locale;
        switch (index) {
            case 1: locale = "pt"; break;
            default: locale = "en"; break;
        }

        TranslationServer.SetLocale(locale);

        // also save the thing
        var cofngig = new Config<SystemInfo>();
        cofngig.Data.Language = locale;
        cofngig.Save();
    }
}

}