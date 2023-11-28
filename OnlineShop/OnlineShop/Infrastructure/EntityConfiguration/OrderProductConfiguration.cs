using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnlineShop.Domain.Entity;

namespace OnlineShop.Infrastructure.EntityConfiguration;

public class OrderProductConfiguration : IEntityTypeConfiguration<OrderProduct>
{
    public void Configure(EntityTypeBuilder<OrderProduct> entity)
    {
        entity.HasIndex(e => e.OrderProductProductId);
        
        entity.HasIndex(e => e.OrderProductOrderId);
        
        entity.Property(e => e.OrderProductOrderId)
            .IsRequired();
        entity.Property(e => e.OrderProductProductId)
            .IsRequired();
        entity.Property(e => e.OrderProductQuantity)
            .IsRequired();

        entity.HasOne(d => d.OrderProductOrder).WithMany()
            .HasForeignKey(d => d.OrderProductOrderId)
            .OnDelete(DeleteBehavior.Cascade);
        
        entity.HasOne(d => d.ProductVariants).WithMany()
            .HasForeignKey(d => d.OrderProductProductId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}