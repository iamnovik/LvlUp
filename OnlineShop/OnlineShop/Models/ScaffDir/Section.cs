namespace OnlineShop.Models.ScaffDir;

public partial class Section
{
    public long SectionId { get; set; }

    public string? SectionName { get; set; }

    public virtual ICollection<Category> Categories { get; set; } = new List<Category>();
}
