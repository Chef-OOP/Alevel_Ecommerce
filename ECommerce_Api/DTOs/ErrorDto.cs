using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce_Api.DTOs
{
    public class ErrorDto
    {

        public List<String> Errors { get; set; } = new List<string>();
        public int  Status { get; set; }
    }
}
