namespace OnlineShop.Domain.Entity;

public class Category
{
    public long CategoryId { get; set; }

    public long? CategorySubcategoryId { get; set; }

    public string CategoryName { get; set; } = null!;

    public virtual Category? CategorySubcategory { get; set; }

    public virtual ICollection<Category> InverseCategorySubcategory { get; set; } = new List<Category>();

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
    
    public virtual ICollection<Section> Sections { get; set; } = new List<Section>();
}
