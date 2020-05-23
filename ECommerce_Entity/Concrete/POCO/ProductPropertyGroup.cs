using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerce_Entity.Concrete.POCO
{
    public class ProductPropertyGroup : BaseEntity
    {
        public string Name { get; set; }
        public List<ProductProperty> Properties { get; set; }
        public List<ProductPropertyGroupCategory> ProductGroupCategory { get; set; }
    }
}
