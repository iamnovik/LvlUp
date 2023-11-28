using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnlineShop.Domain.Entity;

namespace OnlineShop.Infrastructure.EntityConfiguration;

public class CartConfiguration : IEntityTypeConfiguration<Cart>
{
 
    public void Configure(EntityTypeBuilder<Cart> entity)
    {
        entity.HasKey(e => new { e.CartUserId, e.CartProductId });
        
        entity.HasIndex(e => e.CartProductId);
        
        entity.HasIndex(e => e.CartUserId);
        
        
        entity.Property(e => e.CartProductId)
            .IsRequired();
        entity.Property(e => e.CartQuantity)
            .IsRequired();
        
        entity.HasOne(d => d.CartProduct).WithMany(p => p.Carts)
            .HasForeignKey(d => d.CartProductId)
            .OnDelete(DeleteBehavior.Cascade);
        
        entity.HasOne(d => d.CartUser).WithMany(p => p.Carts)
            .HasForeignKey(d => d.CartUserId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}