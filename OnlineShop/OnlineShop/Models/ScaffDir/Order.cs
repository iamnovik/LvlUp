namespace OnlineShop.Models.ScaffDir;

public partial class Order
{
    public long OrderId { get; set; }

    public decimal? OrderPrice { get; set; }

    public long OrderUserId { get; set; }

    public long OrderAddressId { get; set; }

    public int OrderStatus { get; set; }

    public DateTime? OrderTimeCreate { get; set; }

    public virtual Adress OrderAddress { get; set; } = null!;

    public virtual User OrderUser { get; set; } = null!;
}
