namespace OnlineShop.Models.ScaffDir;

public partial class User
{
    public long UserId { get; set; }

    public short UserType { get; set; }

    public string? UserEmail { get; set; }

    public string UserPassword { get; set; } = null!;

    public string? UserFirstname { get; set; }

    public string? UserLastname { get; set; }

    public string? UserPhoneNumber { get; set; }

    public virtual ICollection<Adress> Adresses { get; set; } = new List<Adress>();

    public virtual ICollection<Cart> Carts { get; set; } = new List<Cart>();

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();

    public virtual ICollection<Review> Reviews { get; set; } = new List<Review>();
}
