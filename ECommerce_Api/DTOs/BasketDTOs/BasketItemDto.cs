using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerce_Api.DTOs.BasketDTOs
{
    public class BasketItemDto
    {
        public int Id { get; set; }
        public ProductDto Product { get; set; }
        public int Quantity { get; set; }
        public decimal SubTotal { get; set; }
    }
}
