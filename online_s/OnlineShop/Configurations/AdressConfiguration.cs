using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using online_s.ScaffDir;

namespace online_s.Configurations;

public class AdressConfiguration : IEntityTypeConfiguration<Adress>
{

    public void Configure(EntityTypeBuilder<Adress> entity)
    {
        entity.HasKey(e => e.AddressId);

        entity.ToTable("Adress");

        entity.HasIndex(e => e.AddressUserId, "IXFK_Adress_User");

        entity.Property(e => e.AddressId)
            .HasDefaultValueSql("nextval(('\"adress_address_id_seq\"'::text)::regclass)")
            .HasColumnName("address_id");
        entity.Property(e => e.AddressAddress)
            .HasMaxLength(50)
            .HasColumnName("address_address");
        entity.Property(e => e.AddressUserId).HasColumnName("address_user_id");

        entity.HasOne(d => d.AddressUser).WithMany(p => p.Adresses)
            .HasForeignKey(d => d.AddressUserId)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("FK_Adress_User");
        
    }
}