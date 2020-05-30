using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce_Api.DTOs
{
    public class AddressDto
    {
        public Guid AddressKey { get; set; }


        [Required(ErrorMessage = "Title Zorounlu Alan")]
        [MaxLength(50,ErrorMessage ="Title Max 50 Karakter")]
        public string Title { get; set; }


        [Required(ErrorMessage = "Province Zorounlu Alan")]
        [MaxLength(20, ErrorMessage = "Province Max 20 Karakter")]
        public string Province { get; set; }


        [Required(ErrorMessage = "District Zorounlu Alan")]
        [MaxLength(30, ErrorMessage = "District Max 30 Karakter")]
        public string District { get; set; }


        [Required(ErrorMessage = "Detail Zorounlu Alan")]
        [MaxLength(200, ErrorMessage = "Detail Max 200 Karakter")]
        public string Detail { get; set; }


        [Required(ErrorMessage = "PostalCode Zorounlu Alan")]
        public string PostalCode { get; set; }

        public bool SameInvoice { get; set; }
        public int CustomerId { get; set; }
        public int AppUserId { get; set; }
    }
}
