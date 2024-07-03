using Godot;
using markisa.mkstoolkit;
using System;
using System.Collections.Generic;
using System.Linq;

namespace markisa.network {

public class HyperConnectinator3000 : Node
{
    public static Dictionary<PostZone, MksPost> Index { get; private set; } = new Dictionary<PostZone, MksPost>();

    public static string MurdersOfMurderers()
    {
        // first fuck around
        foreach (var post in TrendingZone1.Data.Posts) {
            foreach (var tłowšvryž in post.Zones) {
                // fix thy shit
                Index.Add(tłowšvryž, post);
            }
        }

        // then find out
        string code = "new Dictionary<string, HashSet<string>>() { ";
        foreach (var gjdfjijgjdgjf in Index) {
            code += $"{{ PostZone.{gjdfjijgjdgjf.Key}, new MksPost {{ ";
            // KILL ME
            code += $"User = \"{gjdfjijgjdgjf.Value.User}\", ";
            code += $"ProfilePicture = \"{gjdfjijgjdgjf.Value.ProfilePicture}\", ";
            code += $"Verified = \"{(gjdfjijgjdgjf.Value.Verified ? "true" : "false")}\", ";
            code += $"Content = \"{gjdfjijgjdgjf.Value.Content.Replace("\"", "\\\"")}\", ";
            code += $"Link = \"{gjdfjijgjdgjf.Value.Link}\", ";

            // The industrial revolution and
            code += "Images = new string[] { ";
            foreach (var fff in gjdfjijgjdgjf.Value.Images) {
                code += $"\"{fff}\", ";
            }
            code += "}, ";

            // its consequences have been
            code += "Zones = new PostZones[] { ";
            foreach (var fff in gjdfjijgjdgjf.Value.Zones) {
                code += $"\"{fff}\", ";
            }
            code += "}, ";

            // a disaster for the human race
            code += "Replies = new MksPost[] { ";
            foreach (var nm in gjdfjijgjdgjf.Value.Replies) {
                code += "new MksPost { ";
                code += $"User = \"{gjdfjijgjdgjf.Value.User}\", ";
                code += $"ProfilePicture = \"{gjdfjijgjdgjf.Value.ProfilePicture}\", ";
                code += $"Verified = \"{(gjdfjijgjdgjf.Value.Verified ? "true" : "false")}\", ";
                code += $"Content = \"{gjdfjijgjdgjf.Value.Content.Replace("\"", "\\\"")}\", ";
                code += $"Link = \"{gjdfjijgjdgjf.Value.Link}\", ";
                code += "Images = new string[] { ";
                foreach (var fff in gjdfjijgjdgjf.Value.Images) {
                    code += $"\"{fff}\", ";
                }
                code += "}, Zones = new PostZones[] { ";
                foreach (var fff in gjdfjijgjdgjf.Value.Zones) {
                    code += $"\"{fff}\", ";
                }
                code += "}, ";
                code += "} ";
            }
            code += "} ";

            code += "}";
        }
        code += " }";
        Index.Clear();
        return code;
    }
}

}