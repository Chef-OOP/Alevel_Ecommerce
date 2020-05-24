using AutoMapper;
using ECommerce_Api.DTOs;
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
            CreateMap<MasterCategory, MasterCategoryDto>();
            CreateMap<MasterCategoryDto, MasterCategory>();

            CreateMap<Category, CategoryDto>();
            CreateMap<CategoryDto, Category>();
        }
    }
}
