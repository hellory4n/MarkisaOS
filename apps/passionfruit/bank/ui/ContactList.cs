using Godot;
using markisa.foundation;
using markisa.network;
using System;

namespace passionfruit.coreapps.banking {

public class ContactList : ItemList
{
    string[] contacts = {};

    public override void _Ready()
    {
        var config = new Config<SocialInfo>();
        
        if (config.Data.Contacts.Length > 0) {
            Clear();
            contacts = config.Data.Contacts;
        }

        foreach (string contact in config.Data.Contacts) {
            AddItem(Tr(contact));
        }
    }
}

}