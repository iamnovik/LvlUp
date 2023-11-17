using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using online_s.ScaffDir;

namespace online_s.Configurations;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> entity)
    {
        entity.ToTable("User");

        entity.Property(e => e.UserId)
            .HasDefaultValueSql("nextval(('\"user_user_id_seq\"'::text)::regclass)")
            .HasColumnName("user_id");
        entity.Property(e => e.UserEmail)
            .HasMaxLength(50)
            .HasColumnName("user_email");
        entity.Property(e => e.UserFirstname)
            .HasMaxLength(50)
            .HasColumnName("user_firstname");
        entity.Property(e => e.UserLastname)
            .HasMaxLength(50)
            .HasColumnName("user_lastname");
        entity.Property(e => e.UserPassword)
            .HasMaxLength(50)
            .HasColumnName("user_password");
        entity.Property(e => e.UserPhoneNumber)
            .HasMaxLength(50)
            .HasColumnName("user_phone_number");
        entity.Property(e => e.UserType).HasColumnName("user_type");
    }
}