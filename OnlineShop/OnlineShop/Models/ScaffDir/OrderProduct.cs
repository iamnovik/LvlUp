namespace OnlineShop.Models.ScaffDir;

public partial class OrderProduct
{
    public long OrderProductOrderId { get; set; }

    public long OrderProductProductId { get; set; }

    public string? OrderProductQuantity { get; set; }

    public virtual Order OrderProductOrder { get; set; } = null!;

    public virtual ProductVariant ProductVariants { get; set; } = null!;
}
