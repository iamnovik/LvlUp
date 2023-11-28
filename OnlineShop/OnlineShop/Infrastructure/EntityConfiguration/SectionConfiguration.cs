using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnlineShop.Domain.Entity;

namespace OnlineShop.Infrastructure.EntityConfiguration;

public class SectionConfiguration : IEntityTypeConfiguration<Section>
{
    public void Configure(EntityTypeBuilder<Section> entity)
    {
        entity.Property(e => e.SectionId)
            .UseIdentityColumn()
            .IsRequired();
        entity.Property(e => e.SectionName)
            .HasMaxLength(50).IsRequired();
        entity.HasIndex(e => e.SectionName)
            .IsUnique();
    }
}