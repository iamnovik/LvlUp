using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnlineShop.Models.ScaffDir;

namespace online_s.Configurations;

public class CategoryConfiguration : IEntityTypeConfiguration<Category>
{
    public void Configure(EntityTypeBuilder<Category> entity)
    {
        entity.HasIndex(e => e.CategorySubcategoryId);

        entity.Property(e => e.CategoryId)
            .UseIdentityColumn()
            .IsRequired();
        
        entity.Property(e => e.CategoryName)
            .HasMaxLength(50);
        entity.Property(e => e.CategorySubcategoryId);

        entity.HasOne(d => d.CategorySubcategory).WithMany(p => p.InverseCategorySubcategory)
            .HasForeignKey(d => d.CategorySubcategoryId);
        
        entity.HasMany(c => c.Sections)
            .WithMany(s => s.Categories)
            .UsingEntity(j => j.ToTable("M2M_Sections_Categories"));
    }
}