using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerce_Api.DTOs.BasketDTOs
{
    public class AddToBasketDto
    {
        public int Id { get; set; }
        public int CustomerId { get; set; } = 0;
        public int Count { get; set; } = 1;
    }
}
