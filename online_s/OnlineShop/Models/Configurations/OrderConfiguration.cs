using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using online_s.ScaffDir;

namespace online_s.Configurations;

public class OrderConfiguration : IEntityTypeConfiguration<Order>
{
    public void Configure(EntityTypeBuilder<Order> entity)
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
    }
}