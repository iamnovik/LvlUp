using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using online_s.ScaffDir;

namespace online_s.Configurations;

public class ProductVariantConfiguration : IEntityTypeConfiguration<ProductVariant>
{
    public void Configure(EntityTypeBuilder<ProductVariant> entity)
    {
        entity.HasKey(e => e.pvId);

        entity.ToTable("ProductVariant");

        entity.HasIndex(e => e.pvColorId, "IXFK_ProductVariant_Color");

        entity.HasIndex(e => e.pvProductId, "IXFK_ProductVariant_Product");

        entity.HasIndex(e => e.pvSizeId, "IXFK_ProductVariant_Size");

        entity.Property(e => e.pvId)
            .HasDefaultValueSql("nextval(('\"productvariant_pv_id_seq\"'::text)::regclass)")
            .HasColumnName("pv_sec_id");
        entity.Property(e => e.pvId).HasColumnName("pv_id");
        entity.Property(e => e.pvProductId).HasColumnName("pv_product_id");
        entity.Property(e => e.pvQuantity).HasColumnName("pv_quantity");
        entity.Property(e => e.pvSizeId).HasColumnName("pv_size_id");

        entity.HasOne(d => d.pvColor).WithMany(p => p.ProductVariants)
            .HasForeignKey(d => d.pvColorId)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("FK_ProductVariant_Color");

        entity.HasOne(d => d.pvProduct).WithMany(p => p.ProductVariants)
            .HasForeignKey(d => d.pvProductId)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("FK_ProductVariant_Product");

        entity.HasOne(d => d.pvSize).WithMany(p => p.ProductVariants)
            .HasForeignKey(d => d.pvSizeId)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("FK_ProductVariant_Size");
    }
}