using Godot;
using markisa.mkstoolkit;
using System;

namespace passionfruit.coreapps.websites {

public class OpenFromHistory : Button
{
    [Export]
    public NodePath Address;

    public override void _Pressed()
    {
        var itemList = GetNode<ItemList>("../../list");
        var barAddress = GetNode<AddressBar>(Address);
        barAddress.Text = itemList.GetItemText(itemList.GetSelectedItems()[0]);
        barAddress.Djfjsgjs(barAddress.Text);

        GetParent().GetParent<MksPopup>().HidePopup();
        Disabled = true;
    }
}

}