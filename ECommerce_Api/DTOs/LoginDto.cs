using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce_Api.DTOs
{
    public class LoginDto
    {
        [Required(ErrorMessage = "Email Alanı zorunlu")]
        public string Email { get; set; }


        [Required(ErrorMessage = "Password Alanı zorunlu")]
        public string Password { get; set; }
    }
}
