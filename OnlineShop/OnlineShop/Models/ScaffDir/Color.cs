namespace OnlineShop.Models.ScaffDir;

public partial class Color
{
    public short ColorId { get; set; }

    public string? ColorName { get; set; }

    public virtual ICollection<ProductVariant> ProductVariants { get; set; } = new List<ProductVariant>();
}
