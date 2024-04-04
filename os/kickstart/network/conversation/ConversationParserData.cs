namespace markisa.network {

enum ConversationTokenType
{
    Semicolon,
    String,
    BraceOpen,
    BraceClose,
    Option,
    Choose,
    Block
}

class ConversationToken
{
    public ConversationTokenType Type { get; set; }
    public string Literal { get; set; }
}

}