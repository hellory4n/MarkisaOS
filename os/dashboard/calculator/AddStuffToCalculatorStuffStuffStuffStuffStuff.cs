using Godot;
using System;

namespace markisa.dashboard {

public class AddStuffToCalculatorStuffStuffStuffStuffStuff : Button
{
    [Export]
    public string TheBullshitToAdd = "";

    public override void _Pressed()
    {
        GetNode<LineEdit>("../../expression").AppendAtCursor(TheBullshitToAdd);
    }
}

}