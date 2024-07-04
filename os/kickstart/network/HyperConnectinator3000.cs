using Godot;
using System.Collections.Generic;
using System.Text;
using markisa.kickstart;
using System;
using System.Linq;

namespace markisa.network
{

    public class HyperConnectinator3000 : Node
{
    public static Dictionary<PostZone, List<List<MksPost>>> Index { get; private set; } = new Dictionary<PostZone, List<List<MksPost>>>();
    //public static Dictionary<PostZone, List<MksPost>> Index { get; private set; } = 

    public static string MurdersOfMurderers()
    {
        GD.Print("Seroa;oze -3");
        Index = new Dictionary<PostZone, List<List<MksPost>>>() {
            {PostZone.Comedy, new List<List<MksPost>>()},
            {PostZone.Creativity, new List<List<MksPost>>()},
            {PostZone.Discussion, new List<List<MksPost>>()},
            {PostZone.Entertainment, new List<List<MksPost>>()},
            {PostZone.HelpCenter, new List<List<MksPost>>()},
            {PostZone.Technology, new List<List<MksPost>>()},
        };

        // first fuck around (do the zone shit)
        GD.Print("Seroa;oze -2");
        foreach (var post in TrendingZone1.Data.Posts) {
            foreach (var tłowšvryž in post.Zones) {
                if (Index[tłowšvryž].Count == 0) {
                    Index[tłowšvryž].Add(new List<MksPost>() { post });
                }
                else {
                    Index[tłowšvryž][0].Add(post);
                }
            }
        }

        // then still fuck around (split shit)
        GD.Print("Seroa;oze -1");
        foreach (var tłowšvryž in Index) {
            // so random!
            var random = new Random();
            tłowšvryž.Value[0] = tłowšvryž.Value[0]
                .Select(x => (x, random.Next()))
                .OrderBy(tuple => tuple.Item2)
                .Select(tuple => tuple.x)
                .ToList();

            var HEHE = new List<MksPost>();
            int fuckoff = 0;
            foreach (var fdfdfdfdfd in tłowšvryž.Value[0]) {
                HEHE.Add(fdfdfdfdfd);
                fuckoff++;

                if (fuckoff == 8) {
                    MksPost[] kfjkfkkf = new MksPost[HEHE.Count];
                    HEHE.CopyTo(kfjkfkkf);
                    tłowšvryž.Value.Add(kfjkfkkf.ToList());

                    HEHE.Clear();
                    fuckoff = 0;
                }
            }
        }

        // then find out
        GD.Print("Seroa;oze 0");
        return Serialize(Index);
    }

    public static string Serialize(object obj)
    {
        GD.Print("Seroa;oze `1");
        var sb = new StringBuilder();
        SerializeObject(sb, obj, 0);
        GD.Print("Seroa;oze2");
        return sb.ToString();
    }

    private static void SerializeObject(StringBuilder sb, object obj, int indentLevel)
    {
        GD.Print("Seroa;oze ibhect 1");
        if (obj == null)
        {
            sb.Append("null");
            return;
        }

        GD.Print("Seroa;oze ibhect 2");
        var type = obj.GetType();
        if (type.IsPrimitive || obj is string)
        {
            sb.Append(obj.ToString());
            return;
        }

        GD.Print("Seroa;oze ibhect 3");
        if (obj is IEnumerable<object> list)
        {
            SerializeList(sb, list, indentLevel);
            return;
        }

        GD.Print("Seroa;oze ibhect 4");
        SerializeComplexObject(sb, obj, indentLevel);
        GD.Print("Seroa;oze ibhect 5");
    }

    private static void SerializeList(StringBuilder sb, IEnumerable<object> list, int indentLevel)
    {
        GD.Print("Seroa;oze lsit 1");
        sb.AppendLine("new List<object> {");
        foreach (var item in list)
        {
            SerializeObject(sb, item, indentLevel + 1);
            sb.AppendLine(",");
        }
        sb.Append("}");
        GD.Print("Seroa;oze lsit 2");
    }

    private static void SerializeComplexObject(StringBuilder sb, object obj, int indentLevel)
    {
        GD.Print("Seroa;oze compelx oject 1");
        var type = obj.GetType();
        sb.AppendLine($"new {type.Name} {{");
        foreach (var prop in type.GetProperties())
        {
            sb.Append($"{prop.Name} = ");
            SerializeObject(sb, prop.GetValue(obj), indentLevel + 1);
            sb.AppendLine(",");
        }
        GD.Print("Seroa;oze compelx oject 2");
        sb.Append("}");
        GD.Print("Seroa;oze compelx oject 3");
    }
}

}