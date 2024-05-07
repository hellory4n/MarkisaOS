using markisa.foundation;
using System;
using System.Linq;

namespace markisa.network
{

public class SocialInfo : IConfigData
{
    public string GetFilename() => "%user/social.mksconf";

    public MksEmail[] Emails { get; set; } = new MksEmail[] {};
    public string[] Contacts { get; set; } = {};
}

}