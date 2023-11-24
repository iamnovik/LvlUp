namespace OnlineShop.Models.ScaffDir;

public class Review
{
    public long ReviewId { get; set; }

    public long? ReviewUserId { get; set; }

    public long ReviewProductId { get; set; }

    public short ReviewRating { get; set; }

    public string? ReviewComment { get; set; }

    public virtual Product ReviewProduct { get; set; } = null!;

    public virtual User ReviewUser { get; set; } = null!;
}
