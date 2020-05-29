using ECommerce_Entity.Concrete.POCO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerce_DAL.Mapping
{
    public class TicketResponseMap : IEntityTypeConfiguration<TicketResponse>
    {
        public void Configure(EntityTypeBuilder<TicketResponse> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).UseIdentityColumn();

            builder.Property(x => x.Content).IsRequired();
            builder.Property(x => x.Created).HasColumnType("datetime2").IsRequired();

            //builder.HasOne(x => x.Owner)
            //    .WithMany(x => x.TicketResponses)
            //    .HasForeignKey(x => x.OwnerId);
        }
    }
}
