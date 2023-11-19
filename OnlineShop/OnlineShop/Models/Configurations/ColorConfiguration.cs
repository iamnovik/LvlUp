using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnlineShop.Models.ScaffDir;

namespace online_s.Configurations;

public class ColorConfiguration : IEntityTypeConfiguration<Color>
{
    public void Configure(EntityTypeBuilder<Color> entity)
    {
        entity.Property(e => e.ColorId)
            .UseIdentityColumn()
            .IsRequired();
        
        entity.Property(e => e.ColorName)
            .HasMaxLength(50);
    }
}