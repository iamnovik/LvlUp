using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using online_s.ScaffDir;

namespace online_s.Configurations;

public class ReviewConfiguration : IEntityTypeConfiguration<Review>
{
    public void Configure(EntityTypeBuilder<Review> entity)
    {
        entity.ToTable("Review");

        entity.HasIndex(e => e.ReviewProductId, "IXFK_Review_Product");

        entity.HasIndex(e => e.ReviewUserId, "IXFK_Review_User");

        entity.Property(e => e.ReviewId)
            .HasDefaultValueSql("nextval(('\"review_review_id_seq\"'::text)::regclass)")
            .HasColumnName("review_id");
        entity.Property(e => e.ReviewComment)
            .HasMaxLength(200)
            .HasColumnName("review_comment");
        entity.Property(e => e.ReviewProductId).HasColumnName("review_product_id");
        entity.Property(e => e.ReviewRating).HasColumnName("review_rating");
        entity.Property(e => e.ReviewUserId).HasColumnName("review_user_id");

        entity.HasOne(d => d.ReviewProduct).WithMany(p => p.Reviews)
            .HasForeignKey(d => d.ReviewProductId)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("FK_Review_Product");

        entity.HasOne(d => d.ReviewUser).WithMany(p => p.Reviews)
            .HasForeignKey(d => d.ReviewUserId)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("FK_Review_User");
    }
}