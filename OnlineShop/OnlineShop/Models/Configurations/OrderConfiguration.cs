using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnlineShop.Models.ScaffDir;

namespace online_s.Configurations;

public class OrderConfiguration : IEntityTypeConfiguration<Order>
{
    public void Configure(EntityTypeBuilder<Order> entity)
    {
        entity.HasIndex(e => e.OrderAddressId);
        
        entity.HasIndex(e => e.OrderUserId);
        
        entity.Property(e => e.OrderId)
            .UseIdentityColumn()
            .IsRequired();
        
        entity.Property(e => e.OrderAddressId);
        
        entity.Property(e => e.OrderPrice)
            .HasColumnType("money");
        
        entity.Property(e => e.OrderStatus);
        entity.Property(e => e.OrderTimeCreate)
            .HasColumnType("timestamp(6) without time zone");
        entity.Property(e => e.OrderUserId);
        
        entity.HasOne(d => d.OrderAddress).WithMany(p => p.Orders)
            .HasForeignKey(d => d.OrderAddressId)
            .OnDelete(DeleteBehavior.ClientSetNull);
        
        entity.HasOne(d => d.OrderUser).WithMany(p => p.Orders)
            .HasForeignKey(d => d.OrderUserId)
            .OnDelete(DeleteBehavior.ClientSetNull);
    }
}