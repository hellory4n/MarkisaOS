using Godot;
using markisa.foundation;
using System;

namespace passionfruit.coreapps.settings {

public class SystemInfoButSettings : RichTextLabel
{
    public override void _Ready()
    {
        switch (TranslationServer.GetLocale()) {
            case "pt":
                BbcodeText = "[center]MarkisaOS {version}\n© 2071 Passionfruit S.A.\npor hellory4n, alex343xd, parfesan,e tradutores\nRodando no {device}[/center]"
                    .Replace("{version}", $"v{Frambos.MajorVersion}.{Frambos.MinorVersion}.{Frambos.PatchVersion}")
                    .Replace("{device}", Tr("Markistation 2071 Home")); // TODO: allow buying markistation and shit
                break;
            
            case "es":
                BbcodeText = "[center]MarkisaOS {version}\nDerechos de autor a 2071 Passionfruit Corporation\nPor hellory4n, alex343xd, parfesan y traductores\nOperando en {device}[/center]"
                    .Replace("{version}", $"v{Frambos.MajorVersion}.{Frambos.MinorVersion}.{Frambos.PatchVersion}")
                    .Replace("{device}", Tr("Markistation 2071 Home")); // TODO: allow buying markistation and shit
                break;
            
            case "id":
                BbcodeText = "[center]MarkisaOS {version}\n© 2071 Passionfruit Corporation\noleh hellory4n, alex343xd, parfesan, dan para penerjemah\nDijalankan di {device}[/center]"
                    .Replace("{version}", $"v{Frambos.MajorVersion}.{Frambos.MinorVersion}.{Frambos.PatchVersion}")
                    .Replace("{device}", Tr("Markistation 2071 Home")); // TODO: allow buying markistation and shit
                break;
            
            default:
                BbcodeText = "MarkisaOS {version}\n© 2071 Passionfruit Corporation\nby hellory4n, alex343xd, parfesan, and translators\nRunning on {device}"
                    .Replace("{version}", $"v{Frambos.MajorVersion}.{Frambos.MinorVersion}.{Frambos.PatchVersion}")
                    .Replace("{device}", "Markistation 2071 Home"); // TODO: allow buying markistation and shit
                break;
        }
    }
}

}
