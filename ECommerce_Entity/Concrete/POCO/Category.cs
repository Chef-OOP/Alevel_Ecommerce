using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerce_Entity.Concrete.POCO
{
    public class Category : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string ImagePath { get; set; }
        public int MasterCategoryId { get; set; }
        public MasterCategory MasterCategory { get; set; }
        public List<Product> Products { get; set; }
        public List<ProductPropertyGroup> PropertyGroups { get; set; }
    }
}
