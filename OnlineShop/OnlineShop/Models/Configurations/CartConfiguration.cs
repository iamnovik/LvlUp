using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnlineShop.Models.ScaffDir;

namespace online_s.Configurations;

public class CartConfiguration : IEntityTypeConfiguration<Cart>
{
 
    public void Configure(EntityTypeBuilder<Cart> entity)
    {
        entity.HasKey(e => new { e.CartUserId, e.CartProductId });
        
        entity.HasIndex(e => e.CartProductId);
        
        entity.HasIndex(e => e.CartUserId);
        
        
        entity.Property(e => e.CartProductId);
        entity.Property(e => e.CartQuantity);
        
        entity.HasOne(d => d.CartProduct).WithMany(p => p.Carts)
            .HasForeignKey(d => d.CartProductId)
            .OnDelete(DeleteBehavior.ClientSetNull);
        
        entity.HasOne(d => d.CartUser).WithMany(p => p.Carts)
            .HasForeignKey(d => d.CartUserId)
            .OnDelete(DeleteBehavior.ClientSetNull);
    }
}