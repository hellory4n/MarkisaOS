using markisa.foundation;

namespace markisa.network {

public class OnItemArrival
{
    public OnItemArrival(MksStoreItem item)
    {
        switch (item.Id) {
            case "hexagon_food":
                Frambos.Play(SystemSound.Startup);
                break;
        }
    }
}

}