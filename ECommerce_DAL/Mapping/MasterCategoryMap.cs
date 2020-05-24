using ECommerce_Entity.Concrete.POCO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerce_DAL.Mapping
{
    public class MasterCategoryMap : IEntityTypeConfiguration<MasterCategory>
    {
        public void Configure(EntityTypeBuilder<MasterCategory> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).UseIdentityColumn();

            builder.Property(x => x.Name).HasMaxLength(200).IsRequired();
            builder.Property(x => x.Description).HasMaxLength(500).IsRequired();

            builder.Property(x => x.ImagePath).HasMaxLength(100).IsRequired();
            builder.Property(x => x.Logo).HasMaxLength(100).IsRequired();
        }
    }
}
