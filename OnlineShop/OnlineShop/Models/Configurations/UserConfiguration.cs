﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnlineShop.Models.ScaffDir;

namespace online_s.Configurations;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> entity)
    {
        entity.Property(e => e.UserId)
            .UseIdentityColumn()
            .IsRequired();
        
        entity.Property(e => e.UserEmail)
            .HasMaxLength(50);
        entity.Property(e => e.UserFirstname)
            .HasMaxLength(50);
        entity.Property(e => e.UserLastname)
            .HasMaxLength(50);
        entity.Property(e => e.UserPassword)
            .HasMaxLength(50);
        entity.Property(e => e.UserPhoneNumber)
            .HasMaxLength(50);
        entity.Property(e => e.UserType);
    }
}