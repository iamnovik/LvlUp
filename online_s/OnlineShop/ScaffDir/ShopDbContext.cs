using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using online_s.Configurations;

namespace online_s.ScaffDir;

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

    public virtual DbSet<OrderProduct> M2mOrderProducts { get; set; }

    public virtual DbSet<ProductVariant> ProductVariants { get; set; }

    public virtual DbSet<Order> Orders { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    public virtual DbSet<Review> Reviews { get; set; }

    public virtual DbSet<Section> Sections { get; set; }

    public virtual DbSet<Size> Sizes { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=Online_Shop;Username=postgres;Password=2958s24d;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new AdressConfiguration());

        modelBuilder.ApplyConfiguration(new BrandConfiguration());

        modelBuilder.ApplyConfiguration(new CartConfiguration());

        modelBuilder.ApplyConfiguration(new CategoryConfiguration());

        modelBuilder.ApplyConfiguration(new ColorConfiguration());

        modelBuilder.ApplyConfiguration(new OrderProductConfiguration());

        modelBuilder.ApplyConfiguration(new ProductVariantConfiguration());

        modelBuilder.ApplyConfiguration(new OrderConfiguration());

        modelBuilder.ApplyConfiguration(new ProductConfiguration());

        modelBuilder.ApplyConfiguration(new ReviewConfiguration());

        modelBuilder.ApplyConfiguration(new SectionConfiguration());

        modelBuilder.ApplyConfiguration(new SizeConfiguration());

        modelBuilder.ApplyConfiguration(new UserConfiguration());
        
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
