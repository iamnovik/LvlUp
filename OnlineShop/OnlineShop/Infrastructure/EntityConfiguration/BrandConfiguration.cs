using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnlineShop.Domain.Entity;

namespace OnlineShop.Infrastructure.EntityConfiguration;

public class BrandConfiguration : IEntityTypeConfiguration<Brand>
{
    public void Configure(EntityTypeBuilder<Brand> entity)
    {
        entity.Property(e => e.BrandId)
            .UseIdentityColumn()
            .IsRequired();
        entity.Property(e => e.BrandName)
            .HasMaxLength(50).IsRequired();
        entity.HasIndex(e => e.BrandName)
            .IsUnique();

    }
}