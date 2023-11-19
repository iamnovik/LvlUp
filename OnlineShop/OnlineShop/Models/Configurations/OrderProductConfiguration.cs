using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnlineShop.Models.ScaffDir;

namespace online_s.Configurations;

public class OrderProductConfiguration : IEntityTypeConfiguration<OrderProduct>
{
    public void Configure(EntityTypeBuilder<OrderProduct> entity)
    {
        entity.HasIndex(e => e.OrderProductProductId);
        
        entity.HasIndex(e => e.OrderProductOrderId);
        
        entity.Property(e => e.OrderProductOrderId);
        entity.Property(e => e.OrderProductProductId);
        entity.Property(e => e.OrderProductQuantity)
            .HasMaxLength(50);
        
        entity.HasOne(d => d.OrderProductOrder).WithMany()
            .HasForeignKey(d => d.OrderProductOrderId)
            .OnDelete(DeleteBehavior.ClientSetNull);
        
        entity.HasOne(d => d.ProductVariants).WithMany()
            .HasForeignKey(d => d.OrderProductProductId)
            .OnDelete(DeleteBehavior.ClientSetNull);
    }
}