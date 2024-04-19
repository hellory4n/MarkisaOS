namespace markisa.network {

public class Technology1
{

public static MksStore Data { get; set; } = new MksStore {
    Month = 1,
    Items = new MksStoreItem[] {
        new MksStoreItem {
            Seller = "Passionfruit Corporation",
            Name = "Espionage Pro",
            Photo = "res://os/assets/wallpapers/coffee.jpg",
            Rating = 0,
            Price = 999.99M,
            Description = "It just spies on you 24/7"
        },
    }
};

}

}