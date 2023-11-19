using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnlineShop.Models.ScaffDir;

namespace online_s.Configurations;

public class ReviewConfiguration : IEntityTypeConfiguration<Review>
{
    public void Configure(EntityTypeBuilder<Review> entity)
    {
        entity.HasIndex(e => e.ReviewProductId);

        entity.HasIndex(e => e.ReviewUserId);

        entity.Property(e => e.ReviewId)
            .UseIdentityColumn()
            .IsRequired();
        
        entity.Property(e => e.ReviewComment)
            .HasMaxLength(200);
        entity.Property(e => e.ReviewProductId);
        entity.Property(e => e.ReviewRating);
        entity.Property(e => e.ReviewUserId);

        entity.HasOne(d => d.ReviewProduct).WithMany(p => p.Reviews)
            .HasForeignKey(d => d.ReviewProductId)
            .OnDelete(DeleteBehavior.ClientSetNull);

        entity.HasOne(d => d.ReviewUser).WithMany(p => p.Reviews)
            .HasForeignKey(d => d.ReviewUserId)
            .OnDelete(DeleteBehavior.ClientSetNull);
    }
}