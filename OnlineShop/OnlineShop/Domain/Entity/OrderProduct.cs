namespace OnlineShop.Domain.Entity;

public class OrderProduct
{
    public long OrderProductOrderId { get; set; }

    public long OrderProductProductId { get; set; }

    public int OrderProductQuantity { get; set; }

    public virtual Order OrderProductOrder { get; set; } = null!;

    public virtual ProductVariant ProductVariants { get; set; } = null!;
}
