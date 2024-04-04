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
                    while (source[i] != '"') {
                        literal += source[i];
                        i++;
                    }

                    literal.Replace("\\", "\"");
                    GD.Print(literal);
                    tokens.Add(new ConversationToken {
                        Type = ConversationTokenType.String,
                        Literal = literal
                    });
                    break;
                
                // keywords
                case 'a':
                case 'b':
                case 'c':
                case 'd':
                case 'e':
                case 'f':
                case 'h':
                case 'i':
                case 'j':
                case 'k':
                case 'l':
                case 'm':
                case 'n':
                case 'o':
                case 'p':
                case 'q':
                case 'r':
                case 's':
                case 't':
                case 'u':
                case 'v':
                case 'w':
                case 'x':
                case 'y':
                case 'z':
                    string literol = "";
                    while (source[i] != ' ') {
                        literol += source[i];
                        i++;
                    }

                    if (literol == "choose") {
                        tokens.Add(new ConversationToken { Type = ConversationTokenType.Choose });
                    }
                    else if (literol == "option") {
                        tokens.Add(new ConversationToken { Type = ConversationTokenType.Option });
                    }
                    else if (literol == "block") {
                        tokens.Add(new ConversationToken { Type = ConversationTokenType.Block });
                    }
                    break;
            }
        }

        return tokens.ToArray();
    }
}

}