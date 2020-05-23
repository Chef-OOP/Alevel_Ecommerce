using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce_Entity.Concrete.POCO
{
    public class ProductPropertyProduct
    {
        public int ProductId { get; set; }
        public Product Product { get; set; }

        public int ProductPropertyId { get; set; }
        public ProductProperty ProductProperty { get; set; }
    }
}
