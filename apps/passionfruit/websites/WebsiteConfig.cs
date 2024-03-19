using System.Collections.Generic;
using markisa.foundation;

namespace passionfruit.coreapps.websites {

class WebsiteConfig : IConfigData
{
    public string GetFilename() => "%user/apps/passionfruit/websiteConfig.mksconf";

    /// <summary>
    /// The user's browser history :)
    /// </summary>
    public List<string> History { get; set; } = new List<string>();
    /// <summary>
    /// The user's bookmarks :)))))
    /// </summary>
    public List<string> Bookmarks { get; set; } = new List<string>();
}

}