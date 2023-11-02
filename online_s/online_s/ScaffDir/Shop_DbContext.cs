using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace online_s.ScaffDir;

public partial class Shop_DbContext : DbContext
{
    public Shop_DbContext()
    {
    }

    public Shop_DbContext(DbContextOptions<Shop_DbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Adress> Adresses { get; set; }

    public virtual DbSet<Brand> Brands { get; set; }

    public virtual DbSet<Cart> Carts { get; set; }

    public virtual DbSet<Category> Categories { get; set; }

    public virtual DbSet<Color> Colors { get; set; }

    public virtual DbSet<M2mOrderProduct> M2mOrderProducts { get; set; }

    public virtual DbSet<M2mProductSizeColor> M2mProductSizeColors { get; set; }

    public virtual DbSet<M2mSectionCategory> M2mSectionCategories { get; set; }

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
        modelBuilder.Entity<Adress>(entity =>
        {
            entity.HasKey(e => e.AddressId);

            entity.ToTable("Adress");

            entity.HasIndex(e => e.AddressUserId, "IXFK_Adress_User");

            entity.Property(e => e.AddressId)
                .HasDefaultValueSql("nextval(('\"adress_address_id_seq\"'::text)::regclass)")
                .HasColumnName("address_id");
            entity.Property(e => e.AddressAddress)
                .HasMaxLength(50)
                .HasColumnName("address_address");
            entity.Property(e => e.AddressUserId).HasColumnName("address_user_id");

            entity.HasOne(d => d.AddressUser).WithMany(p => p.Adresses)
                .HasForeignKey(d => d.AddressUserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Adress_User");
        });

        modelBuilder.Entity<Brand>(entity =>
        {
            entity.ToTable("Brand");

            entity.Property(e => e.BrandId)
                .HasDefaultValueSql("nextval(('\"brand_brand_id_seq\"'::text)::regclass)")
                .HasColumnName("brand_id");
            entity.Property(e => e.BrandName)
                .HasMaxLength(50)
                .HasColumnName("brand_name");
        });

        modelBuilder.Entity<Cart>(entity =>
        {
            entity.HasKey(e => new { e.CartUserId, e.CartProductId }).HasName("PK_Cart_User_Product");

            entity.ToTable("Cart");

            entity.HasIndex(e => e.CartProductId, "IXFK_Cart_M2M_Product_Size_Color");

            entity.HasIndex(e => e.CartUserId, "IXFK_Cart_User");

            entity.Property(e => e.CartUserId)
                .HasDefaultValueSql("nextval(('\"cart_cart_user_id_seq\"'::text)::regclass)")
                .HasColumnName("cart_user_id");
            entity.Property(e => e.CartProductId).HasColumnName("cart_product_id");
            entity.Property(e => e.CartQuantity).HasColumnName("cart_quantity");

            entity.HasOne(d => d.CartProduct).WithMany(p => p.Carts)
                .HasForeignKey(d => d.CartProductId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Cart_M2M_Product_Size_Color");

            entity.HasOne(d => d.CartUser).WithMany(p => p.Carts)
                .HasForeignKey(d => d.CartUserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Cart_User");
        });

        modelBuilder.Entity<Category>(entity =>
        {
            entity.ToTable("Category");

            entity.HasIndex(e => e.CategorySubcategoryId, "IXFK_Category_Category");

            entity.Property(e => e.CategoryId)
                .HasDefaultValueSql("nextval(('\"category_category_id_seq\"'::text)::regclass)")
                .HasColumnName("category_id");
            entity.Property(e => e.CategoryName)
                .HasMaxLength(50)
                .HasColumnName("category_name");
            entity.Property(e => e.CategorySubcategoryId).HasColumnName("category_subcategory_id");

            entity.HasOne(d => d.CategorySubcategory).WithMany(p => p.InverseCategorySubcategory)
                .HasForeignKey(d => d.CategorySubcategoryId)
                .HasConstraintName("FK_Category_Category");
        });

        modelBuilder.Entity<Color>(entity =>
        {
            entity.ToTable("Color");

            entity.Property(e => e.ColorId)
                .HasDefaultValueSql("nextval(('\"color_color_id_seq\"'::text)::regclass)")
                .HasColumnName("color_id");
            entity.Property(e => e.ColorName)
                .HasMaxLength(50)
                .HasColumnName("color_name");
        });

        modelBuilder.Entity<M2mOrderProduct>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("M2M_order_product");

            entity.HasIndex(e => e.M2mOrderProductProductId, "IXFK_M2M_order_product_M2M_Product_Size_Color");

            entity.HasIndex(e => e.M2mOrderProductOrderId, "IXFK_M2M_order_product_Order");

            entity.Property(e => e.M2mOrderProductOrderId).HasColumnName("m2m_order_product_order_id");
            entity.Property(e => e.M2mOrderProductProductId).HasColumnName("m2m_order_product_product_id");
            entity.Property(e => e.M2mOrderProductQuantity)
                .HasMaxLength(50)
                .HasColumnName("m2m_order_product_quantity");

            entity.HasOne(d => d.M2mOrderProductOrder).WithMany()
                .HasForeignKey(d => d.M2mOrderProductOrderId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_M2M_order_product_Order");

            entity.HasOne(d => d.M2mOrderProductProduct).WithMany()
                .HasForeignKey(d => d.M2mOrderProductProductId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_M2M_order_product_M2M_Product_Size_Color");
        });

        modelBuilder.Entity<M2mProductSizeColor>(entity =>
        {
            entity.HasKey(e => e.M2mPscId);

            entity.ToTable("M2M_Product_Size_Color");

            entity.HasIndex(e => e.M2mPscColorId, "IXFK_M2M_Product_Size_Color_Color");

            entity.HasIndex(e => e.M2mPscProductId, "IXFK_M2M_Product_Size_Color_Product");

            entity.HasIndex(e => e.M2mPscSizeId, "IXFK_M2M_Product_Size_Color_Size");

            entity.Property(e => e.M2mPscId)
                .HasDefaultValueSql("nextval(('\"m2m_product_size_color_m2m_psc_id_seq\"'::text)::regclass)")
                .HasColumnName("M2M_PSC_id");
            entity.Property(e => e.M2mPscColorId).HasColumnName("M2M_PSC_color_id");
            entity.Property(e => e.M2mPscProductId).HasColumnName("M2M_PSC_product_id");
            entity.Property(e => e.M2mPscQuantity).HasColumnName("M2M_PSC_quantity");
            entity.Property(e => e.M2mPscSizeId).HasColumnName("M2M_PSC_size_id");

            entity.HasOne(d => d.M2mPscColor).WithMany(p => p.M2mProductSizeColors)
                .HasForeignKey(d => d.M2mPscColorId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_M2M_Product_Size_Color_Color");

            entity.HasOne(d => d.M2mPscProduct).WithMany(p => p.M2mProductSizeColors)
                .HasForeignKey(d => d.M2mPscProductId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_M2M_Product_Size_Color_Product");

            entity.HasOne(d => d.M2mPscSize).WithMany(p => p.M2mProductSizeColors)
                .HasForeignKey(d => d.M2mPscSizeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_M2M_Product_Size_Color_Size");
        });

        modelBuilder.Entity<M2mSectionCategory>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("M2M_section_category");

            entity.HasIndex(e => e.M2mSectionCategoryCategoryId, "IXFK_M2M_section_category_Category");

            entity.HasIndex(e => e.M2mSectionCategorySectionId, "IXFK_M2M_section_category_Section");

            entity.Property(e => e.M2mSectionCategoryCategoryId).HasColumnName("m2m_section_category_category_id");
            entity.Property(e => e.M2mSectionCategorySectionId).HasColumnName("m2m_section_category_section_id");

            entity.HasOne(d => d.M2mSectionCategoryCategory).WithMany()
                .HasForeignKey(d => d.M2mSectionCategoryCategoryId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_M2M_section_category_Category");

            entity.HasOne(d => d.M2mSectionCategorySection).WithMany()
                .HasForeignKey(d => d.M2mSectionCategorySectionId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_M2M_section_category_Section");
        });

        modelBuilder.Entity<Order>(entity =>
        {
            entity.ToTable("Order");

            entity.HasIndex(e => e.OrderAddressId, "IXFK_Order_Adress");

            entity.HasIndex(e => e.OrderUserId, "IXFK_Order_User");

            entity.Property(e => e.OrderId)
                .HasDefaultValueSql("nextval(('\"order_order_id_seq\"'::text)::regclass)")
                .HasColumnName("order_id");
            entity.Property(e => e.OrderAddressId).HasColumnName("order_address_id");
            entity.Property(e => e.OrderPrice)
                .HasColumnType("money")
                .HasColumnName("order_price");
            entity.Property(e => e.OrderStatus).HasColumnName("order_status");
            entity.Property(e => e.OrderTimeCreate)
                .HasColumnType("timestamp(6) without time zone")
                .HasColumnName("order_time_create");
            entity.Property(e => e.OrderUserId).HasColumnName("order_user_id");

            entity.HasOne(d => d.OrderAddress).WithMany(p => p.Orders)
                .HasForeignKey(d => d.OrderAddressId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Order_Adress");

            entity.HasOne(d => d.OrderUser).WithMany(p => p.Orders)
                .HasForeignKey(d => d.OrderUserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Order_User");
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.ToTable("Product");

            entity.HasIndex(e => e.ProductBrandId, "IXFK_Product_Brand");

            entity.HasIndex(e => e.ProductCategoryId, "IXFK_Product_Category");

            entity.Property(e => e.ProductId)
                .HasDefaultValueSql("nextval(('\"product_product_id_seq\"'::text)::regclass)")
                .HasColumnName("product_id");
            entity.Property(e => e.ProductBrandId).HasColumnName("product_brand_id");
            entity.Property(e => e.ProductCategoryId).HasColumnName("product_category_id");
            entity.Property(e => e.ProductName)
                .HasMaxLength(50)
                .HasColumnName("product_name");
            entity.Property(e => e.ProductPrice)
                .HasColumnType("money")
                .HasColumnName("product_price");

            entity.HasOne(d => d.ProductBrand).WithMany(p => p.Products)
                .HasForeignKey(d => d.ProductBrandId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Product_Brand");

            entity.HasOne(d => d.ProductCategory).WithMany(p => p.Products)
                .HasForeignKey(d => d.ProductCategoryId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Product_Category");
        });

        modelBuilder.Entity<Review>(entity =>
        {
            entity.ToTable("Review");

            entity.HasIndex(e => e.ReviewProductId, "IXFK_Review_Product");

            entity.HasIndex(e => e.ReviewUserId, "IXFK_Review_User");

            entity.Property(e => e.ReviewId)
                .HasDefaultValueSql("nextval(('\"review_review_id_seq\"'::text)::regclass)")
                .HasColumnName("review_id");
            entity.Property(e => e.ReviewComment)
                .HasMaxLength(200)
                .HasColumnName("review_comment");
            entity.Property(e => e.ReviewProductId).HasColumnName("review_product_id");
            entity.Property(e => e.ReviewRating).HasColumnName("review_rating");
            entity.Property(e => e.ReviewUserId).HasColumnName("review_user_id");

            entity.HasOne(d => d.ReviewProduct).WithMany(p => p.Reviews)
                .HasForeignKey(d => d.ReviewProductId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Review_Product");

            entity.HasOne(d => d.ReviewUser).WithMany(p => p.Reviews)
                .HasForeignKey(d => d.ReviewUserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Review_User");
        });

        modelBuilder.Entity<Section>(entity =>
        {
            entity.ToTable("Section");

            entity.Property(e => e.SectionId)
                .HasDefaultValueSql("nextval(('\"section_section_id_seq\"'::text)::regclass)")
                .HasColumnName("section_id");
            entity.Property(e => e.SectionName)
                .HasMaxLength(50)
                .HasColumnName("section_name");
        });

        modelBuilder.Entity<Size>(entity =>
        {
            entity.ToTable("Size");

            entity.Property(e => e.SizeId)
                .HasDefaultValueSql("nextval(('\"size_size_id_seq\"'::text)::regclass)")
                .HasColumnName("size_id");
            entity.Property(e => e.SizeName)
                .HasMaxLength(50)
                .HasColumnName("size_name");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.ToTable("User");

            entity.Property(e => e.UserId)
                .HasDefaultValueSql("nextval(('\"user_user_id_seq\"'::text)::regclass)")
                .HasColumnName("user_id");
            entity.Property(e => e.UserEmail)
                .HasMaxLength(50)
                .HasColumnName("user_email");
            entity.Property(e => e.UserFirstname)
                .HasMaxLength(50)
                .HasColumnName("user_firstname");
            entity.Property(e => e.UserLastname)
                .HasMaxLength(50)
                .HasColumnName("user_lastname");
            entity.Property(e => e.UserPassword)
                .HasMaxLength(50)
                .HasColumnName("user_password");
            entity.Property(e => e.UserPhoneNumber)
                .HasMaxLength(50)
                .HasColumnName("user_phone_number");
            entity.Property(e => e.UserType).HasColumnName("user_type");
        });
        modelBuilder.HasSequence("adress_address_id_seq");
        modelBuilder.HasSequence("brand_brand_id_seq");
        modelBuilder.HasSequence("cart_cart_user_id_seq");
        modelBuilder.HasSequence("category_category_id_seq");
        modelBuilder.HasSequence("color_color_id_seq");
        modelBuilder.HasSequence("m2m_product_size_color_m2m_psc_id_seq");
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
