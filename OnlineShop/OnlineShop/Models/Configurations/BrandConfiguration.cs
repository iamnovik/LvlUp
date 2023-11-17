using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using online_s.ScaffDir;

namespace online_s.Configurations;

public class BrandConfiguration : IEntityTypeConfiguration<Brand>
{
    public void Configure(EntityTypeBuilder<Brand> entity)
    {
        entity.ToTable("Brand");

        entity.Property(e => e.BrandId)
            .HasDefaultValueSql("nextval(('\"brand_brand_id_seq\"'::text)::regclass)")
            .HasColumnName("brand_id");
        entity.Property(e => e.BrandName)
            .HasMaxLength(50)
            .HasColumnName("brand_name");
    }
}