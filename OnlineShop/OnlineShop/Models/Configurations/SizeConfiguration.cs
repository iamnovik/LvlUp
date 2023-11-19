using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnlineShop.Models.ScaffDir;

namespace online_s.Configurations;

public class SizeConfiguration : IEntityTypeConfiguration<Size>
{
    public void Configure(EntityTypeBuilder<Size> entity)
    {
        entity.Property(e => e.SizeId)
            .UseIdentityColumn()
            .IsRequired();
        entity.Property(e => e.SizeName)
            .HasMaxLength(50);
    }
}