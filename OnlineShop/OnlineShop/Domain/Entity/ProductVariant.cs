namespace OnlineShop.Domain.Entity;

public class ProductVariant
{
    public long pvId { get; set; }

    public long pvProductId { get; set; }

    public int pvSizeId { get; set; }

    public short pvColorId { get; set; }

    public int pvQuantity { get; set; }

    public virtual ICollection<Cart> Carts { get; set; } = new List<Cart>();

    public virtual Color pvColor { get; set; } = null!;

    public virtual Product pvProduct { get; set; } = null!;

    public virtual Size pvSize { get; set; } = null!;
}
