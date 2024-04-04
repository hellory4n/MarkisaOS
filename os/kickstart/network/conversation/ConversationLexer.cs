using System.Collections.Generic;
using Godot;

namespace markisa.network {

class ConversationLexer
{
    public static ConversationToken[] Tokenize(string source)
    {
        var tokens = new List<ConversationToken>();
        
        for (int i = 0; i < source.Length; i++) {
            char c = source[i];

            switch (c) {
                // single characters
                case ';': tokens.Add(new ConversationToken { Type = ConversationTokenType.Semicolon }); break;
                case '{': tokens.Add(new ConversationToken { Type = ConversationTokenType.BraceOpen }); break;
                case '}': tokens.Add(new ConversationToken { Type = ConversationTokenType.BraceClose }); break;

                // strings
                case '"':
                    string literal = "";
                    while (source[i + 1] != '"') {
                        // escaping
                        if (source[i + 1] == '\\' && source[i + 2] == '"') {
                            literal += '"';
                            i++;
                        }
                        else {
                            literal += source[i + 1];
                        }
                        i++;
                    }

                    tokens.Add(new ConversationToken {
                        Type = ConversationTokenType.String,
                        Literal = literal
                    });
                    break;
            }
        }

        return tokens.ToArray();
    }
}

}