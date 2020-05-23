using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerce_Entity.Concrete.POCO
{
    public class Product : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal RealPrice { get; set; }
        public decimal DiscountedPrice { get; set; }
        public decimal? Discount { get; set; }
        public decimal? Tax { get; set; }
        public int Stock { get; set; }
        public List<ProductImage> Images { get; set; }
        public List<ProductCampaign> ProductCampaign { get; set; }
        public List<ProductPropertyProduct> ProductPropertyProducts { get; set; }
        public int BrandId { get; set; }
        public Brand Brand { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
    }
}
