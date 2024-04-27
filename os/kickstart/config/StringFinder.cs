using System.Collections.Generic;

namespace markisa.foundation {

public class StringFinder : IConfigData
{
    public string GetFilename() => "stringFinder.mksconf";
    
    public bool Enabled { get; set; } = false;
    // i know
    public HashSet<HashSet<TranslationString>> Strings { get; set; } = new HashSet<HashSet<TranslationString>>();
}

public class TranslationString
{
    public string Path { get; set; } = "";
    public string MessageId { get; set; } = "";
    public string MessageString { get; set; } = "";
}

}