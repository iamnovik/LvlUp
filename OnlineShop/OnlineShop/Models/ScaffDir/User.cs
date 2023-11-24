namespace OnlineShop.Models.ScaffDir;

public class User
{
    public long UserId { get; set; }

    public UserType UserType { get; set; }

    public string UserEmail { get; set; } = null!;

    public string UserPassword { get; set; } = null!;

    public string UserFirstname { get; set; } = null!;

    public string UserLastname { get; set; } = null!;

    public string UserPhoneNumber { get; set; } = null!;

    public virtual ICollection<Adress> Adresses { get; set; } = new List<Adress>();

    public virtual ICollection<Cart> Carts { get; set; } = new List<Cart>();

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();

    public virtual ICollection<Review> Reviews { get; set; } = new List<Review>();
}
