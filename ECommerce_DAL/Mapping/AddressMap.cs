using ECommerce_Entity.Concrete.POCO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerce_DAL.Mapping
{
    public class AddressMap : IEntityTypeConfiguration<Address>
    {
        public void Configure(EntityTypeBuilder<Address> builder)
        {

            //builder.HasKey(x => x.Id);
            //builder.Property(x => x.Id).UseIdentityColumn();
            //builder.Property(x => x.Title).HasMaxLength(50).IsRequired();
            //builder.Property(x => x.Province).HasMaxLength(20).IsRequired();
            //builder.Property(x => x.District).HasMaxLength(30).IsRequired();
            //builder.Property(x => x.Detail).HasMaxLength(200).IsRequired();

            builder.HasOne(x => x.Customer)
                .WithMany(x => x.Address)
                .HasForeignKey(x => x.CustomerId);

            builder.HasOne(x => x.AppUser)
                .WithMany(x => x.Address)
                .HasForeignKey(x => x.AppUserId);

            builder.HasMany(x => x.Orders)
                .WithOne(x => x.Address)
                .HasForeignKey(x => x.AddressId);
        }
    }
}
