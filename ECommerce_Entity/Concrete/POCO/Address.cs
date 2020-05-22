using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerce_Entity.Concrete.POCO
{
    public class Address : BaseEntity
    {
        public string Title { get; set; }
        public string Province { get; set; }
        public string District { get; set; }
        public string Detail { get; set; }
        public string PostalCode { get; set; }
        public int UserId { get; set; }
        public ApplicationUser User { get; set; }
    }
}
