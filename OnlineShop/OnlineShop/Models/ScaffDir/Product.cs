namespace OnlineShop.Models.ScaffDir;

public partial class Product
{
    public long ProductId { get; set; }

    public string? ProductName { get; set; }

    public long ProductBrandId { get; set; }

    public long ProductCategoryId { get; set; }

    public decimal ProductPrice { get; set; }

    public virtual ICollection<ProductVariant> ProductVariants { get; set; } = new List<ProductVariant>();

    public virtual Brand ProductBrand { get; set; } = null!;

    public virtual Category ProductCategory { get; set; } = null!;

    public virtual ICollection<Review> Reviews { get; set; } = new List<Review>();
}
