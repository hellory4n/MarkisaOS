namespace markisa.network {

public class LocalMarket1
{

public static MksStore Data { get; set; } = new MksStore {
    Month = 1,
    Items = new MksStoreItem[] {
        new MksStoreItem {
            Id = "joe_galaxy",
            Seller = "Joe",
            Name = "A galaxy",
            Photo = "res://os/assets/wallpapers/space.jpg",
            Rating = 5,
            Price = 5,
            Description = "Its a fuckinggallxay"
        },
    }
};

}

}