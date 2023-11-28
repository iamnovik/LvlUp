using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnlineShop.Domain.Entity;

namespace OnlineShop.Infrastructure.EntityConfiguration;

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