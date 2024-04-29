using Godot;
using markisa.foundation;
using System;

namespace passionfruit.coreapps.settings {

public class TranslationMode : CheckBox
{
    public override void _Toggled(bool buttonPressed)
    {
        var config = new Config<StringFinder>();
        config.Data.Enabled = !config.Data.Enabled;
        config.Save();
    }
}

}