using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using online_s.ScaffDir;

namespace online_s.Configurations;

public class CartConfiguration : IEntityTypeConfiguration<Cart>
{
    public void Configure(EntityTypeBuilder<Cart> entity)
    {
        entity.HasKey(e => new { e.CartUserId, e.CartProductId }).HasName("PK_Cart_User_Product");
        
        entity.ToTable("Cart");
        
        entity.HasIndex(e => e.CartProductId, "IXFK_Cart_M2M_Product_Size_Color");
        
        entity.HasIndex(e => e.CartUserId, "IXFK_Cart_User");
        
        entity.Property(e => e.CartUserId)
            .HasDefaultValueSql("nextval(('\"cart_cart_user_id_seq\"'::text)::regclass)")
            .HasColumnName("cart_user_id");
        entity.Property(e => e.CartProductId).HasColumnName("cart_product_id");
        entity.Property(e => e.CartQuantity).HasColumnName("cart_quantity");
        
        entity.HasOne(d => d.CartProduct).WithMany(p => p.Carts)
            .HasForeignKey(d => d.CartProductId)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("FK_Cart_ProductVariant");
        
        entity.HasOne(d => d.CartUser).WithMany(p => p.Carts)
            .HasForeignKey(d => d.CartUserId)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("FK_Cart_User");
    }
}