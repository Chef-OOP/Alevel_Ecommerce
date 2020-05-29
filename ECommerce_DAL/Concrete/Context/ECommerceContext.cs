using ECommerce_DAL.Mapping;
using ECommerce_Entity.Concrete;
using ECommerce_Entity.Concrete.POCO;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace ECommerce_DAL.Concrete.Context
{
    public class ECommerceContext
        : IdentityDbContext<ApplicationUser, ApplicationRole, int>
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=.;database=AlevelECommerceDb;Integrated Security=true");
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new AddressMap());
            builder.ApplyConfiguration(new ApplicationUserMap());
            builder.ApplyConfiguration(new BrandMap());
            builder.ApplyConfiguration(new CampaignMap());
            builder.ApplyConfiguration(new CategoryMap());
            builder.ApplyConfiguration(new MasterCategoryMap());
            builder.ApplyConfiguration(new OrderItemMap());
            builder.ApplyConfiguration(new OrderMap());
            builder.ApplyConfiguration(new ProductImageMap());
            builder.ApplyConfiguration(new ProductMap());
            builder.ApplyConfiguration(new ProductPropertyGroupMap());
            builder.ApplyConfiguration(new ProductPropertyMap());
            builder.ApplyConfiguration(new SliderImageMap());
            builder.ApplyConfiguration(new SliderMap());

            foreach (var foreignKey in builder.Model
                .GetEntityTypes()
                .SelectMany(x=>x.GetForeignKeys()))
            {
                foreignKey.DeleteBehavior = DeleteBehavior.Restrict;
            }

            //builder.ApplyConfiguration(new TicketMap());
            //builder.ApplyConfiguration(new TicketResponseMap());


            builder.ApplyConfiguration(new ProductCampaignMap());
            builder.ApplyConfiguration(new ProductGroupCategoryMap());
            builder.ApplyConfiguration(new ProductPropertyProductMap());
            base.OnModelCreating(builder);
        }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Campaign> Campaigns { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<MasterCategory> MasterCategories { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductImage> ProductImages { get; set; }
        public DbSet<ProductProperty> ProductProperties { get; set; }
        public DbSet<ProductPropertyGroup> ProductPropertyGroups { get; set; }
        public DbSet<Slider> Sliders { get; set; }
        public DbSet<SliderImage> SliderImages { get; set; }
        public DbSet<Invoice> Invoices { get; set; }
        //public DbSet<Ticket> Tickets { get; set; }
        //public DbSet<TicketResponse> TicketResponses { get; set; }


        public DbSet<ProductCampaign> ProductCampaigns { get; set; }
        public DbSet<ProductPropertyGroupCategory> ProductGroupCategories { get; set; }
        public DbSet<ProductPropertyProduct> ProductPropertyProducts { get; set; }

    }
    public class ProductPropertyProductMap
        : IEntityTypeConfiguration<ProductPropertyProduct>
    {
        public void Configure(EntityTypeBuilder<ProductPropertyProduct> builder)
        {
            builder
                .HasKey(x => new { x.ProductId, x.ProductPropertyId });

            builder
                .HasOne(x => x.Product)
                .WithMany(x => x.ProductPropertyProducts)
                .HasForeignKey(x => x.ProductId);

            builder
                .HasOne(x => x.ProductProperty)
                .WithMany(x => x.ProductPropertyProducts)
                .HasForeignKey(x => x.ProductPropertyId);
        }
    }
    public class ProductGroupCategoryMap
        : IEntityTypeConfiguration<ProductPropertyGroupCategory>
    {
        public void Configure(EntityTypeBuilder<ProductPropertyGroupCategory> builder)
        {
            builder
                .HasKey(x => new { x.ProductPropertyGroupId, x.CategoryId });

            builder
                .HasOne(x => x.Category)
                .WithMany(x => x.ProductGroupCategory)
                .HasForeignKey(x => x.CategoryId);

            builder
                .HasOne(x => x.ProductPropertyGroup)
                .WithMany(x => x.ProductGroupCategory)
                .HasForeignKey(x => x.ProductPropertyGroupId);
        }
    }
    public class ProductCampaignMap
        : IEntityTypeConfiguration<ProductCampaign>
    {
        public void Configure(EntityTypeBuilder<ProductCampaign> builder)
        {
            builder
                .HasKey(x => new { x.CampaignId, x.ProductId });

            builder
                .HasOne(x => x.Campaign)
                .WithMany(x => x.ProductCampaign)
                .HasForeignKey(x => x.CampaignId);

            builder
                .HasOne(x => x.Product)
                .WithMany(x => x.ProductCampaign)
                .HasForeignKey(x => x.ProductId);
        }
    }
}
