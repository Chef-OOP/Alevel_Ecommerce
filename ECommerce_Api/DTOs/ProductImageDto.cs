using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce_Api.DTOs
{
    public class ProductImageDto
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="Zorounlu Alan")]
        public string Path { get; set; }
        [Required(ErrorMessage = "Zorounlu Alan")]
        public int ProductId { get; set; }
    }
}
