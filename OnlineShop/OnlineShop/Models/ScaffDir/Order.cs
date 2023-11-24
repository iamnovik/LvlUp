namespace OnlineShop.Models.ScaffDir;

public class Order
{
    public long OrderId { get; set; }

    public decimal? OrderPrice { get; set; }

    public long OrderUserId { get; set; }

    public long? OrderAddressId { get; set; }

    public OrderStatus OrderStatus { get; set; }

    public DateTime? OrderTimeCreate { get; set; }

    public virtual Adress OrderAddress { get; set; } = null!;

    public virtual User OrderUser { get; set; } = null!;
}
