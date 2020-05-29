using ECommerce_Entity.Concrete.POCO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce_DAL.Mapping
{
    public class InvoiceMap
        : IEntityTypeConfiguration<Invoice>
    {
        public void Configure(EntityTypeBuilder<Invoice> builder)
        {
            builder.HasOne(x => x.Address)
                .WithMany(x => x.Invoices)
                .HasForeignKey(x => x.AddressId);

            builder.HasOne(x => x.Customer)
                .WithMany(x => x.Invoices)
                .HasForeignKey(x => x.CustomerId);

            builder.HasOne(x => x.Order)
                .WithMany(x => x.Invoices)
                .HasForeignKey(x => x.OrderId);
        }
    }
}
