using Godot;
using System;

namespace markisa.mkstoolkit {

public static class NodeExtensions
{
    /// <summary>
    /// Finds the window this node is located in, or null if it isn't in any window.
    /// </summary>
    public static MksWindowImpl GetMksWindow(this Node node)
    {
        while (true) {
            Node parent = node.GetParent();
            if (parent.GetNodeOrNull("MksWindow_CSharp") != null) {
                return node.GetNode<MksWindowImpl>("MksWindow_CSharp");
            }
        }
    }
}

}