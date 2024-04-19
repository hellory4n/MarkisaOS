namespace markisa.network {

public class MksStoreItem
{
    public string Seller { get; set; } = "";
    public string Name { get; set; } = "";
    public string Photo { get; set; } = "";
    public string Description { get; set; } = "";
    public decimal Price { get; set; } = 0;
    public uint Rating { get; set; } = 10; // 10/10
}

}