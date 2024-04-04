using System;
using Godot;

namespace markisa.network {

class ConversationLoader
{
    public static void Load(string path)
    {
        var result = new MksConversation();

        // first use a cursed mechanism to get the strings
        var res = GD.Load<Resource>(path);
        result.Name = (string)res.Get("username");
        var content = (string)res.Get("content");

        // then actually process the shits
        ConversationToken[] xd = ConversationLexer.Tokenize(content);
        GD.Print(string.Join<ConversationToken>(", ", xd));
    }
}

}