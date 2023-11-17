using System.Collections.Specialized;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using online_s.ScaffDir;

namespace online_s.Configurations;

public class SectionConfiguration : IEntityTypeConfiguration<Section>
{
    public void Configure(EntityTypeBuilder<Section> entity)
    {
        entity.ToTable("Section");

        entity.Property(e => e.SectionId)
            .HasDefaultValueSql("nextval(('\"section_section_id_seq\"'::text)::regclass)")
            .HasColumnName("section_id");
        entity.Property(e => e.SectionName)
            .HasMaxLength(50)
            .HasColumnName("section_name");
    }
}