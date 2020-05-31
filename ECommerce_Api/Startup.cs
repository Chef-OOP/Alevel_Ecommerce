using AutoMapper;
using ECommerce_Business.Abstarct;
using ECommerce_Business.Concrete;
using ECommerce_DAL.Abstarct;
using ECommerce_DAL.Concrete;
using ECommerce_DAL.Concrete.Context;
using ECommerce_JWT.Security;
using ECommerce_JWT.Security.Encyrtion;
using ECommerce_JWT.Security.Jwt;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using tk=ECommerce_JWT.Security;

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

            //services.Configure<FormOptions>(options =>
            //{
            //    options.MultipartBodyLengthLimit = long.MaxValue;
            //    options.BufferBody = true;
            //});


            //services.AddIdentity<ApplicationUser, ApplicationRole>(opt =>
            //{
            //    opt.Password.RequireDigit = false;
            //    opt.Password.RequiredLength = 6;
            //    opt.Password.RequireLowercase = false;
            //    opt.Password.RequireUppercase = false;

            //}).AddEntityFrameworkStores<ECommerceContext>();


            //services.Configure<ApiBehaviorOptions>(opt =>
            //{
            //    opt.SuppressModelStateInvalidFilter = true;

            //});
            var tokenOptions = Configuration.GetSection("TokenOptions").Get<tk.TokenOptions>();

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateLifetime = true,
                        ValidIssuer = tokenOptions.Issuer,
                        ValidAudience = tokenOptions.Audience,
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = SecurityKeyHelper.CreateSecurityKey(tokenOptions.SecurityKey),
                        ClockSkew = TimeSpan.Zero
                    };
                });
            services.AddDbContext<ECommerceContext>();
            services.AddAutoMapper(typeof(Startup));
            services.AddControllers();
            //services.AddSession();
            #region IoC

            //services.AddScoped<ECommerceContext>();

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

            services.AddScoped<IAppUserService, AppUserManager>();
            services.AddScoped<IAppUserDal, EfAppUserDal>();

            services.AddScoped<IAuthService, AuthManager>();

            services.AddScoped<ITokenHelper, JwtHelper>();



            #endregion
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();
            //app.UseSession(new SessionOptions()
            //{
            //      IdleTimeout=TimeSpan.FromMinutes(10),
            //       IOTimeout=TimeSpan.FromMinutes(10)
            //});

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
