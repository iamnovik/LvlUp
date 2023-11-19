using System.Collections.Specialized;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnlineShop.Models.ScaffDir;

namespace online_s.Configurations;

public class SectionConfiguration : IEntityTypeConfiguration<Section>
{
    public void Configure(EntityTypeBuilder<Section> entity)
    {
        entity.Property(e => e.SectionId)
            .UseIdentityColumn()
            .IsRequired();
        entity.Property(e => e.SectionName)
            .HasMaxLength(50);
    }
}