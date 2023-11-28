namespace OnlineShop.Models.ScaffDir;

public class Section
{
    public long SectionId { get; set; }

    public string SectionName { get; set; } = null!;

    public virtual ICollection<Category> Categories { get; set; } = new List<Category>();
}
