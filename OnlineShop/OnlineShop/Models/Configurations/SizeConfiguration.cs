using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using online_s.ScaffDir;

namespace online_s.Configurations;

public class SizeConfiguration : IEntityTypeConfiguration<Size>
{
    public void Configure(EntityTypeBuilder<Size> entity)
    {
        entity.ToTable("Size");

        entity.Property(e => e.SizeId)
            .HasDefaultValueSql("nextval(('\"size_size_id_seq\"'::text)::regclass)")
            .HasColumnName("size_id");
        entity.Property(e => e.SizeName)
            .HasMaxLength(50)
            .HasColumnName("size_name");
    }
}