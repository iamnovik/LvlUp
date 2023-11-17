using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using online_s.ScaffDir;

namespace online_s.Configurations;

public class OrderProductConfiguration : IEntityTypeConfiguration<OrderProduct>
{
    public void Configure(EntityTypeBuilder<OrderProduct> entity)
    {
        entity
            .HasNoKey()
            .ToTable("order_product");
        
        entity.HasIndex(e => e.OrderProductProductId, "IXFK_order_product_ProductVariant");
        
        entity.HasIndex(e => e.OrderProductOrderId, "IXFK_order_product_Order");
        
        entity.Property(e => e.OrderProductOrderId).HasColumnName("order_product_order_id");
        entity.Property(e => e.OrderProductProductId).HasColumnName("order_product_product_id");
        entity.Property(e => e.OrderProductQuantity)
            .HasMaxLength(50)
            .HasColumnName("order_product_quantity");
        
        entity.HasOne(d => d.OrderProductOrder).WithMany()
            .HasForeignKey(d => d.OrderProductOrderId)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("FK_order_product_Order");
        
        entity.HasOne(d => d.ProductVariants).WithMany()
            .HasForeignKey(d => d.OrderProductProductId)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("FK_order_product_ProductVariant");
    }
}