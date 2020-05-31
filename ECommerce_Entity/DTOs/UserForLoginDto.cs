using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce_Entity.DTOs
{
    public class UserForLoginDto
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public int CustomerId { get; set; } = 0;
    }
}
