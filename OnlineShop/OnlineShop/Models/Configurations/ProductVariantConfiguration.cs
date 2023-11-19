using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnlineShop.Models.ScaffDir;

namespace online_s.Configurations;

public class ProductVariantConfiguration : IEntityTypeConfiguration<ProductVariant>
{
    public void Configure(EntityTypeBuilder<ProductVariant> entity)
    {
        entity.HasKey(e => e.pvId);

        entity.HasIndex(e => e.pvColorId);

        entity.HasIndex(e => e.pvProductId);

        entity.HasIndex(e => e.pvSizeId);

        entity.Property(e => e.pvId)
            .UseIdentityColumn()
            .IsRequired();
        
        entity.Property(e => e.pvId);
        entity.Property(e => e.pvProductId);
        entity.Property(e => e.pvQuantity);
        entity.Property(e => e.pvSizeId);

        entity.HasOne(d => d.pvColor).WithMany(p => p.ProductVariants)
            .HasForeignKey(d => d.pvColorId)
            .OnDelete(DeleteBehavior.ClientSetNull);

        entity.HasOne(d => d.pvProduct).WithMany(p => p.ProductVariants)
            .HasForeignKey(d => d.pvProductId)
            .OnDelete(DeleteBehavior.ClientSetNull);

        entity.HasOne(d => d.pvSize).WithMany(p => p.ProductVariants)
            .HasForeignKey(d => d.pvSizeId)
            .OnDelete(DeleteBehavior.ClientSetNull);
    }
}