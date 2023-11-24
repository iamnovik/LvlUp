using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnlineShop.Models.ScaffDir;

namespace OnlineShop.Models.Configurations;

public class ProductConfiguration : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> entity)
    {
        entity.HasIndex(e => e.ProductBrandId);
        
        entity.HasIndex(e => e.ProductCategoryId);
        
        entity.Property(e => e.ProductId)
            .UseIdentityColumn()
            .IsRequired();
        
        entity.Property(e => e.ProductBrandId)
            .IsRequired();
        entity.Property(e => e.ProductCategoryId)
            .IsRequired();
        entity.Property(e => e.ProductName)
            .HasMaxLength(50).IsRequired();
        entity.Property(e => e.ProductPrice)
            .HasColumnType("money").IsRequired();

        entity.HasIndex(e => e.ProductName);
        entity.HasOne(d => d.ProductBrand).WithMany(p => p.Products)
            .HasForeignKey(d => d.ProductBrandId)
            .OnDelete(DeleteBehavior.Cascade);
        
        entity.HasOne(d => d.ProductCategory).WithMany(p => p.Products)
            .HasForeignKey(d => d.ProductCategoryId)
            .OnDelete(DeleteBehavior.ClientSetNull);
    }
}