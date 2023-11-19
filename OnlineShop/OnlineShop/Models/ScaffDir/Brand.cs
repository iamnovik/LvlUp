namespace OnlineShop.Models.ScaffDir;

public partial class Brand
{
    public long BrandId { get; set; }

    public string? BrandName { get; set; }

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
}
