using Godot;

namespace markisa.network {

class ConversationLoader
{
    public static void Load()
    {
        var result = new MksConversation();

        // first use a cursed mechanism to get the strings
        var res = GD.Load<Resource>("res://social/messaging/passionfruitSupport.tres");
        result.Name = (string)res.Get("username");
        var content = (string)res.Get("content");

        // then actually process the shits
    }
}

}