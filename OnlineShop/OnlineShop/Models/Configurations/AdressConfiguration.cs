using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnlineShop.Models.ScaffDir;

namespace OnlineShop.Models.Configurations;

public class AdressConfiguration : IEntityTypeConfiguration<Adress>
{

    public void Configure(EntityTypeBuilder<Adress> entity)
    {
        entity.HasKey(e => e.AddressId);
        
        entity.HasIndex(e => e.AddressUserId);
        
        entity.Property(e => e.AddressId)
            .UseIdentityColumn()
            .IsRequired();
        
        entity.Property(e => e.AddressAddress)
            .HasMaxLength(50);
        entity.Property(e => e.AddressUserId)
            .IsRequired();

        entity.HasOne(d => d.AddressUser).WithMany(p => p.Adresses)
            .HasForeignKey(d => d.AddressUserId)
            .OnDelete(DeleteBehavior.Cascade);
        
    }
}