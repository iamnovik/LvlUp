using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using online_s.ScaffDir;

namespace online_s.Configurations;

public class ProductConfiguration : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> entity)
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
    }
}