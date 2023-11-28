using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnlineShop.Models.ScaffDir;

namespace OnlineShop.Models.Configurations;

public class SizeConfiguration : IEntityTypeConfiguration<Size>
{
    public void Configure(EntityTypeBuilder<Size> entity)
    {
        entity.Property(e => e.SizeId)
            .UseIdentityColumn()
            .IsRequired();
        entity.Property(e => e.SizeName)
            .HasMaxLength(50).IsRequired();
        entity.HasIndex(e => e.SizeName)
            .IsUnique();
    }
}