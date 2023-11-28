using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnlineShop.Domain.Entity;

namespace OnlineShop.Infrastructure.EntityConfiguration;

public class CategoryConfiguration : IEntityTypeConfiguration<Category>
{
    public void Configure(EntityTypeBuilder<Category> entity)
    {
        entity.HasIndex(e => e.CategorySubcategoryId);

        entity.Property(e => e.CategoryId)
            .UseIdentityColumn()
            .IsRequired();
        
        entity.Property(e => e.CategoryName)
            .HasMaxLength(50).IsRequired();
        entity.HasIndex(e => e.CategoryName)
            .IsUnique();
        
        entity.Property(e => e.CategorySubcategoryId);

        entity.HasOne(d => d.CategorySubcategory).WithMany(p => p.InverseCategorySubcategory)
            .HasForeignKey(d => d.CategorySubcategoryId);

        entity.HasMany(c => c.Sections)
            .WithMany(s => s.Categories);

    }
}