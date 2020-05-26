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
        [Required(ErrorMessage ="Value Boş Geçilemez")]
        public string Value { get; set; }
        [Required(ErrorMessage ="Oluşturulacak özelliğin hangi gruba ait olduğunu belirmelisiniz!!!")]
        public int GroupId { get; set; }
    }
}
