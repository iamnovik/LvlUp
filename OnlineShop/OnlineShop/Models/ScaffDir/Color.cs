namespace OnlineShop.Models.ScaffDir;

public class Color
{
    public short ColorId { get; set; }

    public string ColorName { get; set; } = null!;

    public virtual ICollection<ProductVariant> ProductVariants { get; set; } = new List<ProductVariant>();
}
