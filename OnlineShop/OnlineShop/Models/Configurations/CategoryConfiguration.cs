using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using online_s.ScaffDir;

namespace online_s.Configurations;

public class CategoryConfiguration : IEntityTypeConfiguration<Category>
{
    public void Configure(EntityTypeBuilder<Category> entity)
    {
        entity.ToTable("Category");

        entity.HasIndex(e => e.CategorySubcategoryId, "IXFK_Category_Category");

        entity.Property(e => e.CategoryId)
            .HasDefaultValueSql("nextval(('\"category_category_id_seq\"'::text)::regclass)")
            .HasColumnName("category_id");
        entity.Property(e => e.CategoryName)
            .HasMaxLength(50)
            .HasColumnName("category_name");
        entity.Property(e => e.CategorySubcategoryId).HasColumnName("category_subcategory_id");

        entity.HasOne(d => d.CategorySubcategory).WithMany(p => p.InverseCategorySubcategory)
            .HasForeignKey(d => d.CategorySubcategoryId)
            .HasConstraintName("FK_Category_Category");
        
        entity.HasMany(c => c.Sections)
            .WithMany(s => s.Categories)
            .UsingEntity(j => j.ToTable("M2M_Sections_Categories"));
    }
}