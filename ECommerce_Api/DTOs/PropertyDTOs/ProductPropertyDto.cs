using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce_Api.DTOs
{
    public class ProductPropertyDto
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="Value Boş Geçilemez")]
        public string Value { get; set; }
        [Required(ErrorMessage ="Oluşturulacak özelliğin hangi gruba ait olduğunu belirmelisiniz!!!")]
        public ProductPropertyGroupNameDto Group { get; set; }
        public int GroupId { get; set; }
    }
}
