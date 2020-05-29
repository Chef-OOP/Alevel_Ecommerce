using ECommerce_Entity.Concrete.POCO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace ECommerce_DAL.Mapping
{
    public class TicketMap : IEntityTypeConfiguration<Ticket>
    {
        public void Configure(EntityTypeBuilder<Ticket> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).UseIdentityColumn();

            builder.Property(x => x.Title).HasMaxLength(200).IsRequired();
            builder.Property(x => x.Content).IsRequired();

            builder.HasMany(x => x.Responses)
                .WithOne(x => x.Ticket)
                .HasForeignKey(x => x.TicketId);

            //builder.HasOne(x => x.Owner)
            //    .WithMany(x => x.Tickets)
            //    .HasForeignKey(x => x.OwnerId);
                
        }
    }
}
