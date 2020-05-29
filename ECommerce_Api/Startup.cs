using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using AutoMapper;
using ECommerce_Business.Abstarct;
using ECommerce_Business.Concrete;
using ECommerce_DAL.Abstarct;
using ECommerce_DAL.Concrete;
using ECommerce_DAL.Concrete.Context;
using ECommerce_Entity.Concrete.POCO;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace ECommerce_Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;

        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            //services.AddCors(options =>
            //{
            //    options.AddPolicy("CorsPolicy", builder => builder
            //     .AllowAnyOrigin()
            //     .AllowAnyMethod()
            //     .AllowAnyHeader()
            //     .AllowCredentials()
            //     .Build());
            //});
            services.Configure<FormOptions>(options =>
            {
                options.MultipartBodyLengthLimit = long.MaxValue;
                options.BufferBody = true;
            });
            services.AddDbContext<ECommerceContext>();
            services.AddAutoMapper(typeof(Startup));

            services.AddIdentity<ApplicationUser, ApplicationRole>(opt=>
            {
                opt.Password.RequiredLength = 6;
                opt.Password.RequireLowercase = false;
                opt.Password.RequireUppercase = false;
                
            }).AddEntityFrameworkStores<ECommerceContext>()
              .AddDefaultTokenProviders();

            
            services.Configure<ApiBehaviorOptions>(opt =>
            {
                opt.SuppressModelStateInvalidFilter = true;

            });

            services.AddControllers(opt =>
            {
                opt.RespectBrowserAcceptHeader = true;
            });


            #region IoC
            services.AddScoped<ICustomerService, CustomerManager>();
            services.AddScoped<ICustomerDal, EfCustomerDal>();

            services.AddScoped<IBrandService, BrandManager>();
            services.AddScoped<IBrandDal, EfBrandDal>();

            services.AddScoped<ICategoryService, CategoryManager>();
            services.AddScoped<ICategoryDal, EfCategoryDal>();

            services.AddScoped<IMasterCategoryService, MasterCategoryManager>();
            services.AddScoped<IMasterCategoryDal, EfMasterCategoryDal>();

            services.AddScoped<IOrderItemService, OrderItemManager>();
            services.AddScoped<IOrderItemDal, EfOrderItemDal>();

            services.AddScoped<IProductImageService, ProductImageManager>();
            services.AddScoped<IProductImageDal, EfProductImageDal>();

            services.AddScoped<IProductPropertyGroupService, ProductPropertyGroupManager>();
            services.AddScoped<IProductPropertyGroupDal, EfProductPropertyGroupDal>();

            services.AddScoped<IProductPropertyService, ProductPropertyManager>();
            services.AddScoped<IProductPropertyDal, EfProductPropertyDal>();

            services.AddScoped<IProductService, ProductManager>();
            services.AddScoped<IProductDal, EfProductDal>();

            services.AddScoped<ISliderImageService, SliderImageManager>();
            services.AddScoped<ISliderImageDal, EfSliderImageDal>();

            services.AddScoped<ISliderService, SliderManager>();
            services.AddScoped<ISliderDal, EfSliderDal>();

            services.AddScoped<IProductPropertyProductsService, ProductPropertyProductsManager>();
            services.AddScoped<IProductPropertyProductsDal, EfProductPropertyProductsDal>();
            
            
            services.AddScoped<IAddressService, AddressManager>();
            services.AddScoped<IAddressDal, EfAddressDal>();
            
            
            services.AddScoped<IInvoiceService, InvoiceManager>();
            services.AddScoped<IInvoiceDal, EfInvoiceDal>();


            #endregion
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseStaticFiles();
            app.UseHttpsRedirection();

            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
