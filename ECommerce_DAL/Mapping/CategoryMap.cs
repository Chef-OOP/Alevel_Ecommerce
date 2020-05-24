using ECommerce_Entity.Concrete.POCO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerce_DAL.Mapping
{
    public class CategoryMap : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).UseIdentityColumn();

            builder.Property(x => x.Name).HasMaxLength(200).IsRequired();
            builder.Property(x => x.Description).HasMaxLength(500).IsRequired();

            builder.Property(x => x.ImagePath).HasMaxLength(100).IsRequired();

            builder.HasMany(x => x.Products)
                 .WithOne(x => x.Category)
                 .HasForeignKey(x => x.CategoryId);

            builder.HasOne(x => x.MasterCategory)
                .WithMany(x => x.Categories)
                .HasForeignKey(x => x.MasterCategoryId);
        }
    }
}
