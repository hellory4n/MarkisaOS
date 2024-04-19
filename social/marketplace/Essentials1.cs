namespace markisa.network {

public class Essentials1
{

public static MksStore Data { get; set; } = new MksStore {
    Month = 1,
    Items = new MksStoreItem[] {
        new MksStoreItem {
            Seller = "Hexagon Inc.",
            Name = "Food Supplies",
            Photo = "res://os/assets/wallpapers/space.jpg",
            Rating = 8,
            Price = 25,
            Description = 
@"This is a box with food. It includes food, which is useful for when you're hungry. Studies show that food helps your life.

Features:
- It contains food
- Food is available
- Multiple types of food inside the box"
        },

        new MksStoreItem {
            Seller = "Hexagon Inc.",
            Name = "Hygiene Supplies",
            Photo = "res://os/assets/wallpapers/space.jpg",
            Rating = 8,
            Price = 25,
            Description = 
@"This is a box with hygiene products. It includes hygiene products, which is useful for when you're dirt. Studies show that hygiene helps your life.

Features:
- It contains hygiene products
- Hygiene products are available
- Multiple types of hygiene products inside the box"
        },

        new MksStoreItem {
            Seller = "Hexagon Inc.",
            Name = "Cleaning Supplies",
            Photo = "res://os/assets/wallpapers/space.jpg",
            Rating = 8,
            Price = 25,
            Description = 
@"This is a box with cleaning products. It includes cleaning products, which is useful for when your house is dirty. Studies show that a clean environment helps your life.

Features:
- It contains cleaning products
- Cleaning products are available
- Multiple types of cleaning products inside the box"
        },

        new MksStoreItem {
            Seller = "Hexagon Inc.",
            Name = "Medicine Supplies",
            Photo = "res://os/assets/wallpapers/space.jpg",
            Rating = 8,
            Price = 25,
            Description = 
@"This is a box with medicine. It includes medicine, which is useful for when you're sick. Studies show that medicine helps your life.

Features:
- It contains medicine
- Medicine is available
- Multiple types of medicine inside the box"
        },

        new MksStoreItem {
            Seller = "Hexagon Inc.",
            Name = "Office Supplies",
            Photo = "res://os/assets/wallpapers/space.jpg",
            Rating = 8,
            Price = 25,
            Description = 
@"This is a box with office supplies. It includes office supplies, which is useful for when you're working. Studies show that office supplies helps your work.

Features:
- It contains office supplies
- Office supplies are available
- Multiple types of office supplies inside the box"
        },

        new MksStoreItem {
            Seller = "Hexagon Inc.",
            Name = "Emergency Supplies",
            Photo = "res://os/assets/wallpapers/space.jpg",
            Rating = 8,
            Price = 25,
            Description = 
@"This is a box with emergency supplies. It includes emergency supplies, which is useful for when you're in an emergency. Studies show that emergency supplies helps with emergencies.

Features:
- It contains emergency supplies
- Emergency supplies are available
- Multiple types of emergency supplies inside the box"
        }
    }
};

}

}