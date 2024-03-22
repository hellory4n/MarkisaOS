using Godot;
using markisa.mkstoolkit;
using System;

namespace passionfruit.coreapps.files {

public class NewFileFolder : OptionButton
{
    [Export(PropertyHint.NodePathValidTypes, "Panel")]
    public NodePath EpicAwesomeEpicThingy;
    [Export(PropertyHint.NodePathValidTypes, "LineEdit")]
    public NodePath EpicEpicEpicEpic;
    [Export(PropertyHint.NodePathValidTypes, "ItemList")]
    public NodePath ThThThThin;

    int theFuckingThingThatIsBeingCreated = 0;

    public void ItemSelected(int index)
    {
        // item 0 is just the "new" text, you can't create a new new
        if (index == 0) {
            return;
        }

        var epicPopup = GetNode<MksPopup>(EpicAwesomeEpicThingy);
        epicPopup.ShowPopup();

        // go back to the "new" text
        theFuckingThingThatIsBeingCreated = index;
        Selected = 0;

        var epicThingy = GetNode<NewItemNameInput>(EpicEpicEpicEpic);
        epicThingy.heheheha = theFuckingThingThatIsBeingCreated;
        GD.Print(theFuckingThingThatIsBeingCreated);

        var Th = GetNode<ListFiles>(ThThThThin);
        epicThingy.fucking = Th.CurrentFolder;
        Th.Refresh(Th.CurrentFolder); 
    }
}

}