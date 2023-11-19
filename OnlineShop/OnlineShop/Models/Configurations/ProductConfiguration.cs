using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnlineShop.Models.ScaffDir;

namespace online_s.Configurations;

public class ProductConfiguration : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> entity)
    {
        entity.HasIndex(e => e.ProductBrandId);
        
        entity.HasIndex(e => e.ProductCategoryId);
        
        entity.Property(e => e.ProductId)
            .UseIdentityColumn()
            .IsRequired();
        
        entity.Property(e => e.ProductBrandId);
        entity.Property(e => e.ProductCategoryId);
        entity.Property(e => e.ProductName)
            .HasMaxLength(50);
        entity.Property(e => e.ProductPrice)
            .HasColumnType("money");
        
        entity.HasOne(d => d.ProductBrand).WithMany(p => p.Products)
            .HasForeignKey(d => d.ProductBrandId)
            .OnDelete(DeleteBehavior.ClientSetNull);
        
        entity.HasOne(d => d.ProductCategory).WithMany(p => p.Products)
            .HasForeignKey(d => d.ProductCategoryId)
            .OnDelete(DeleteBehavior.ClientSetNull);
    }
}