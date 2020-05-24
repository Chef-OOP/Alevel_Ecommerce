using ECommerce_Entity.Concrete.POCO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerce_DAL.Mapping
{
    public class CampaignMap : IEntityTypeConfiguration<Campaign>
    {
        public void Configure(EntityTypeBuilder<Campaign> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).UseIdentityColumn();

            builder.Property(x => x.Title).HasMaxLength(400).IsRequired();
            builder.Property(x => x.Detail).HasColumnType("ntext").IsRequired();
            builder.Property(x => x.ImagePath).HasMaxLength(100).IsRequired();

            builder.Property(x => x.BeginDate).HasColumnType("datetime2").IsRequired();
            builder.Property(x => x.EndDate).HasColumnType("datetime2").IsRequired();
        }
    }
}
