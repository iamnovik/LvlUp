using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnlineShop.Models.ScaffDir;

namespace OnlineShop.Models.Configurations;

public class ColorConfiguration : IEntityTypeConfiguration<Color>
{
    public void Configure(EntityTypeBuilder<Color> entity)
    {
        entity.Property(e => e.ColorId)
            .UseIdentityColumn()
            .IsRequired();
        
        entity.Property(e => e.ColorName)
            .HasMaxLength(50).IsRequired();
        entity.HasIndex(e => e.ColorName)
            .IsUnique();
    }
}