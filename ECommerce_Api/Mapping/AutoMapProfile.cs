using AutoMapper;
using ECommerce_Api.DTOs;
using ECommerce_Api.DTOs.AccountDTOs;
using ECommerce_Api.DTOs.BasketDTOs;
using ECommerce_Api.DTOs.CategoryDTOs;
using ECommerce_Api.DTOs.MasterCategoryDTOs;
using ECommerce_Entity.Concrete.POCO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce_Api.Mapping
{
    public class AutoMapProfile
        : Profile
    {
        public AutoMapProfile()
        {
            // Master Category
            CreateMap<MasterCategory, MasterCategoryDto>();
            CreateMap<MasterCategoryDto, MasterCategory>();
            CreateMap<MasterCategory, MasterCategoryMenuDto>();
            CreateMap<MasterCategoryMenuDto, MasterCategory>();

            CreateMap<Category, CategoryDto>();
            CreateMap<CategoryDto, Category>();
            CreateMap<Category, CategoryMenuDto>();
            CreateMap<CategoryMenuDto, Category>();

            CreateMap<Brand, BrandDto>();
            CreateMap<BrandDto, Brand>();

            CreateMap<ProductPropertyDto, ProductProperty>();
            CreateMap<ProductProperty, ProductPropertyDto>();

            CreateMap<ProductPropertyGroupDto, ProductPropertyGroup>();
            CreateMap<ProductPropertyGroup, ProductPropertyGroupDto>(); 
            CreateMap<ProductPropertyGroupNameDto, ProductPropertyGroup>();
            CreateMap<ProductPropertyGroup, ProductPropertyGroupNameDto>();

            CreateMap<Product, ProductDto>();
            CreateMap<ProductDto, Product>();

            CreateMap<OrderItem, BasketItemDto>().ForMember(x=>x.SubTotal,y=>y.MapFrom(z=>z.Quantity*z.Product.DiscountedPrice));
            CreateMap<BasketItemDto, OrderItem>();

            //CreateMap<ApplicationUser, RegisterDto>();
            //CreateMap<RegisterDto, ApplicationUser>();


            CreateMap<Address, AddressDto>();
            CreateMap<AddressDto, Address>();

            CreateMap<Customer, CustomerDto>();
            CreateMap<CustomerDto, Customer>();
        }
    }
}
