using Godot;
using markisa.mkstoolkit;
using System;
using System.Collections.Generic;
using System.Linq;

namespace markisa.network {

public class HyperConnectinator3000 : Node
{
    public static Dictionary<PostZone, List<MksPost>> Index { get; private set; } = new Dictionary<PostZone, List<MksPost>>() { {PostZone.Comedy, new List<MksPost>()}, {PostZone.Creativity, new List<MksPost>()}, {PostZone.Discussion, new List<MksPost>()}, {PostZone.Entertainment, new List<MksPost>()}, {PostZone.HelpCenter, new List<MksPost>()}, {PostZone.Technology, new List<MksPost>()} };
    //public static Dictionary<PostZone, List<MksPost>> Index { get; private set; } = 

    public static string MurdersOfMurderers()
    {
        // first fuck around
        foreach (var post in TrendingZone1.Data.Posts) {
            foreach (var tłowšvryž in post.Zones) {
                Index[tłowšvryž].Add(post);
            }
        }

        // then find out
        string code = "new Dictionary<PostZone, List<MksPost>>() { ";
        foreach (var yikyhkjyky in Index) {
            code += $"{{ PostZone.{yikyhkjyky.Key}, new List<MksPost> {{ ";

            foreach (var gjdfjijgjdgjf in yikyhkjyky.Value) {
                code += "new MksPost { ";
                // KILL ME
                code += $"User = \"{gjdfjijgjdgjf.User}\", ";
                code += $"ProfilePicture = \"{gjdfjijgjdgjf.ProfilePicture}\", ";
                code += $"Verified = {(gjdfjijgjdgjf.Verified ? "true" : "false")}, ";
                code += $"Content = \"{gjdfjijgjdgjf.Content.Replace("\"", "\\\"")}\", ";
                code += $"Link = \"{gjdfjijgjdgjf.Link}\", ";

                // The industrial revolution and
                code += "Images = new string[] { ";
                foreach (var fff in gjdfjijgjdgjf.Images) {
                    code += $"\"{fff}\", ";
                }
                code += "}, ";

                // its consequences have been
                code += "Zones = new PostZone[] { ";
                foreach (var fff in gjdfjijgjdgjf.Zones) {
                    code += $"PostZone.{fff}, ";
                }
                code += "}, ";

                // a disaster for the human race
                code += "Replies = new MksPost[] { ";
                foreach (var nm in gjdfjijgjdgjf.Replies) {
                    code += "new MksPost { ";
                    code += $"User = \"{gjdfjijgjdgjf.User}\", ";
                    code += $"ProfilePicture = \"{gjdfjijgjdgjf.ProfilePicture}\", ";
                    code += $"Verified = {(gjdfjijgjdgjf.Verified ? "true" : "false")}, ";
                    code += $"Content = \"{gjdfjijgjdgjf.Content.Replace("\"", "\\\"")}\", ";
                    code += $"Link = \"{gjdfjijgjdgjf.Link}\", ";
                    code += "Images = new string[] { ";
                    foreach (var fff in gjdfjijgjdgjf.Images) {
                        code += $"\"{fff}\", ";
                    }
                    code += "}, }, ";
                }
                code += "}, }, ";
            }

            code += "}, ";
        }
        code += " }";
        Index.Clear();
        return code;
    }
}

}