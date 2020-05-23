using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce_Entity.Concrete.POCO
{
    public class ProductPropertyGroupCategory
    {
        public int CategoryId { get; set; }
        public Category Category { get; set; }

        public int ProductPropertyGroupId { get; set; }
        public ProductPropertyGroup ProductPropertyGroup { get; set; }
    }
}
