using Godot;
using markisa.foundation;
using markisa.mkstoolkit;
using System;

namespace passionfruit.coreapps.betatools {

public class ResetTranslations : Button
{
    public override void _Pressed()
    {
        var config = new Config<StringFinder>();
        config.Data.Strings.Clear();
        config.Save();
        GetParent().GetParent().GetParent().GetParent<MksWindow>().Close();
    }
}

}