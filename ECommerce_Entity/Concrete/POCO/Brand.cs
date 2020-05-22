using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerce_Entity.Concrete.POCO
{
    public class Brand : BaseEntity
    {
        public string Name { get; set; }
        public List<Product> Products { get; set; }
    }
}
