using Godot;
using markisa.foundation;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace passionfruit.coreapps.betatools {

public class TranslationStuff : TabContainer
{
    public override void _Ready()
    {
        var config = new Config<StringFinder>();

        int i = 0;
        foreach (HashSet<TranslationString> j in config.Data.Strings) {
            Function(j, i);
            i++;
        }
    }

    void Function(HashSet<TranslationString> g, int i)
    {
        var scroll = new ScrollContainer();
        var v = new VBoxContainer {
            SizeFlagsHorizontal = (int)SizeFlags.ExpandFill
        };
        AddChild(scroll);
        scroll.AddChild(v);

        var button = new Button {
            Text = "Export (copies to clipboard)",
            MouseFilter = MouseFilterEnum.Pass
        };
        v.AddChild(button);

        foreach (TranslationString hehe in g) {
            var burgeouiseTextLabel = new RichTextLabel {
                FitContentHeight = true,
                Text = hehe.MessageId,
                MouseFilter = MouseFilterEnum.Pass
            };

            var textButMakeItEdit = new TextEdit {
                RectMinSize = new Vector2(0, 300),
                MouseFilter = MouseFilterEnum.Pass,
                Text = hehe.MessageString != "" ? hehe.MessageString : "Translation goes here"
            };

            v.AddChild(burgeouiseTextLabel);
            v.AddChild(textButMakeItEdit);
        }

        button.Connect("pressed", this, nameof(ExportShit), new Godot.Collections.Array { JsonConvert.SerializeObject(g), v.GetChildren(), i });
    }

    void ExportShit(string _g, Godot.Collections.Array godotDotCollectionsDotArray, int i)
    {
        // godot fucking sucks
        var g = JsonConvert.DeserializeObject<HashSet<TranslationString>>(_g);
        // there's no FindIndex on HashSets
        var gButList = g.ToList();
        // or on godot arrays
        var itsNotAnArrayItsAListOrDynamicArray = godotDotCollectionsDotArray.Cast<Node>().ToList();

        string output = "";
        foreach (TranslationString trStr in g) { // fuck you
            // find the the the the the the the the the the the the the INDEX
            int stringIndex = gButList.FindIndex(x => x.MessageId == trStr.MessageId);

            // then do something confusing to find the the the the the the JSGNJSH
            int textEditIndex = itsNotAnArrayItsAListOrDynamicArray.FindIndex(
                x => x is RichTextLabel wealthyLabel && wealthyLabel.Text == trStr.MessageId
            ) + 1;

            trStr.MessageString = ((TextEdit)godotDotCollectionsDotArray[textEditIndex]).Text;
            GD.Print(godotDotCollectionsDotArray[textEditIndex].GetType().FullName);
            GD.Print(i);

            // now we can do the .po stuff :)))))))))
            output += $"#:{trStr.Path}\nmsgid \"{trStr.MessageId}\"\nmsgstr \"{trStr.MessageString.Replace("\\n", "\n")}\"\n\n";
        }

        // i think microsoft added a bunch of methods to List<T> & Dictionary<K, V> & then forgot that there
        // was more than 2 collection types
        var config = new Config<StringFinder>();
        var uh = config.Data.Strings.ToList();
        uh.RemoveAt(i);
        config.Data.Strings = uh.ToHashSet();
        config.Data.Strings.Add(g);
        config.Save();

        OS.Clipboard = output;
    }
}

}