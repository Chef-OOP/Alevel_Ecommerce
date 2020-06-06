using ECommerce_Api.DTOs.CategoryDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerce_Api.DTOs.MasterCategoryDTOs
{
    public class MasterCategoryMenuDto
    {
        public int Id { get; set; }
        public string Logo { get; set; }
        public string Name { get; set; }
        public List<CategoryMenuDto> Categories { get; set; }
    }
}
