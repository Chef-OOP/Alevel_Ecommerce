using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce_Api.DTOs
{
    public class BrandDto
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="Name alanı boş geçilemez")]
        public string Name { get; set; }
    }
}
