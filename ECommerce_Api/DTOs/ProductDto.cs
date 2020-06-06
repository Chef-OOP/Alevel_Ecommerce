using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce_Api.DTOs
{
    public class ProductDto
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Name Alanı Zorunlu")]
        [MaxLength(200, ErrorMessage = "Ürün Adı Max 200 karakter olmalıdır")]
        public string Name { get; set; }
        public string Description { get; set; }
        [Required(ErrorMessage = "RealPrice Alanı Zorunlu")]
        public decimal RealPrice { get; set; }
        public string MainImage { get; set; }
        public decimal DiscountedPrice { get; set; }
        public decimal? Discount { get; set; }
        public decimal? Tax { get; set; }
        public int Selling { get; set; }
        public bool IsAdviced { get; set; }
        public int Stock { get; set; }
        [Required(ErrorMessage = "")]
        public int BrandId { get; set; }
        public int CategoryId { get; set; }
    }
}
