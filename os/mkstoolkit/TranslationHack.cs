using Godot;
using System;

namespace markisa.mkstoolkit {

/// <summary>
/// Translations don't work when there's newlines involved :(
/// </summary>
public class TranslationHack : Node
{
    [Export(PropertyHint.NodePathValidTypes, "RichTextLabel")]
    public NodePath label;
    [Export(PropertyHint.MultilineText)]
    public string PortugueseText = "";
    [Export(PropertyHint.MultilineText)]
    public string SpanishText = "";
    [Export(PropertyHint.MultilineText)]
    public string IndonesianText = "";

    public override void _Ready()
    {
        var rich = GetNode<RichTextLabel>(label);
        if (TranslationServer.GetLocale().StartsWith("pt")) {
            rich.Clear();
            rich.AppendBbcode(PortugueseText);
        }
        else if (TranslationServer.GetLocale().StartsWith("id")) {
            rich.Clear();
            rich.AppendBbcode(IndonesianText);
        }
        else if (TranslationServer.GetLocale().StartsWith("es")) {
            rich.Clear();
            rich.AppendBbcode(SpanishText);
        }
    }
}

}