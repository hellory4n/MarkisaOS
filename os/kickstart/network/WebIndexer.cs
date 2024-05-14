using Godot;
using System;

[Tool]
public class WebIndexer : Node
{
    public override void _Ready()
    {
        #if DEBUG
        // i release beta versions on saturday, i need to update the indexing
        if (DateTime.Now.DayOfWeek != DayOfWeek.Saturday) {
            return;
        }

        OS.Execute("zenity", new string[] { "--warning", "--text=\"\"UPDATE THE WEBSITE INDEX!!!!1\"\"" });

        // update the index :)
        string filename = "";
        var dir = new Directory();
        dir.ListDirBegin(true);
        while (filename != "") {
            // add stuff to open the scene but just for the tags lol
            filename = dir.GetNext();
        }
        dir.ListDirEnd();
        #endif
    }
}
