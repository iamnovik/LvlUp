using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using online_s.ScaffDir;

namespace online_s.Configurations;

public class ColorConfiguration : IEntityTypeConfiguration<Color>
{
    public void Configure(EntityTypeBuilder<Color> entity)
    {
        entity.ToTable("Color");

        entity.Property(e => e.ColorId)
            .HasDefaultValueSql("nextval(('\"color_color_id_seq\"'::text)::regclass)")
            .HasColumnName("color_id");
        entity.Property(e => e.ColorName)
            .HasMaxLength(50)
            .HasColumnName("color_name");
    }
}