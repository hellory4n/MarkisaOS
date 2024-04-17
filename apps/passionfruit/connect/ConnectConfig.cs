using markisa.foundation;
using markisa.network;

namespace passionfruit.coreapps.connect {

class ConnectConfig : IConfigData
{
    public string GetFilename() => "%user/apps/passionfruit/connect/connectConfig.mksconf";
    
    public MksPost[] Bookmarks { get; set; } = new MksPost[] {};
    public MksPost[] Posts { get; set; } = new MksPost[] {};
}

}