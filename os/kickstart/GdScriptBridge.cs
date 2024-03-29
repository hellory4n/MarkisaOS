using Godot;
using markisa.foundation;
using markisa.mkstoolkit;
using System;

public class GdScriptBridge : Node
{
    /// <summary>
    /// Used by the MksDownload class to allow showing up in the add node dialog while also having logic written in C#
    /// </summary>
    public void Download(Button btn, string filename, string content, int maxValue)
    {
        // find the window
        Node parent = btn.GetParent();
        while (!(parent is MksWindow)) {
            parent = parent.GetParent();
        }
        var window = (MksWindow)parent;

        // show the download popup
        var popup = window.GetNode<MksPopup>("contents/downloads");
        popup.ShowPopup();

        // enable the ParadoxBar
        var paradox = popup.GetNode<ProgressBar>("hehehe/ha/paradoxBar");
        paradox.MaxValue = maxValue;
        paradox.Value = 0;

        paradox.Connect("finished", this, nameof(WhyThough), new Godot.Collections.Array {
            filename, content, paradox
        });
    }

    // actually download the file
    void WhyThough(string filename, string content, ProgressBar bar)
    {
        // this syntax is weird
        var file = new MksFile(filename) {
            Data = content
        };
        file.Save();

        Frambos.Notify("Websites", $"\"{filename}\" was downloaded.");
        Frambos.Play(SystemSound.Success);

        // so it doesn't show up 856893959395090390 times
        bar.Disconnect("finished", this, nameof(WhyThough));
    }
}
