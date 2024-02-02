using markisa.foundation;

namespace markisa.kickstart {

class UserConvert
{
    public UserConvert()
    {
        var conf = new Config<MarkisaUser>();
        // v0.13.2 has no breaking changes, simply bump the version number
        if (conf.Data.MajorVersion == 0 && conf.Data.MinorVersion == 13 && conf.Data.PatchVersion == 1) {
            conf.Data.PatchVersion++;
            conf.Save();
        }
    }
}

}