using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerce_Api.DTOs
{
    public class CategoryDto
    {
        public int Id { get; set; }
        public bool IsDeleted { get; set; }
        public bool IsActive { get; set; }
        public DateTime Created { get; set; }
        public DateTime Updated { get; set; }

        [Display(Name="Üst kategori: ")]
        public string Name { get; set; }
        public string Description { get; set; }
        [Display(Name = "Kapak görseli: ")]
        public string ImagePath { get; set; }
        public int MasterCategoryId { get; set; }
    }
}
