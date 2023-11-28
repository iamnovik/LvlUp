
namespace OnlineShop.Models.ScaffDir;

public class Adress
{
    public long AddressId { get; set; } 

    public long AddressUserId { get; set; }

    public string AddressAddress { get; set; } = null!;

    public virtual User AddressUser { get; set; } = null!;

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
}
