using System.Reflection;
using Microsoft.EntityFrameworkCore;
using online_s.Configurations;

namespace OnlineShop.Models.ScaffDir;

public partial class ShopDbContext : DbContext
{
    public ShopDbContext()
    {
    }

    public ShopDbContext(DbContextOptions<ShopDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Adress> Adresses { get; set; }

    public virtual DbSet<Brand> Brands { get; set; }

    public virtual DbSet<Cart> Carts { get; set; }

    public virtual DbSet<Category> Categories { get; set; }

    public virtual DbSet<Color> Colors { get; set; }

    public virtual DbSet<OrderProduct> OrderProducts { get; set; }

    public virtual DbSet<ProductVariant> ProductVariants { get; set; }

    public virtual DbSet<Order> Orders { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    public virtual DbSet<Review> Reviews { get; set; }

    public virtual DbSet<Section> Sections { get; set; }

    public virtual DbSet<Size> Sizes { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        
        modelBuilder.HasSequence("adress_address_id_seq");
        modelBuilder.HasSequence("brand_brand_id_seq");
        modelBuilder.HasSequence("cart_cart_user_id_seq");
        modelBuilder.HasSequence("category_category_id_seq");
        modelBuilder.HasSequence("color_color_id_seq");
        modelBuilder.HasSequence("productvariant_pv_id_seq");
        modelBuilder.HasSequence("order_order_id_seq");
        modelBuilder.HasSequence("product_product_id_seq");
        modelBuilder.HasSequence("review_review_id_seq");
        modelBuilder.HasSequence("section_section_id_seq");
        modelBuilder.HasSequence("size_size_id_seq");
        modelBuilder.HasSequence("user_user_id_seq");

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
