using ECommerce_Entity.Concrete.POCO;
using System;

namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {
            ProductPropertyGroup group = new ProductPropertyGroup
            {
                Name = "Aroma"
            };
            ProductProperty pp = new ProductProperty
            {
                Value = "Tavuklu",
               Group = group
            };

            Category c = new Category
            {
                Name = "Kedi maması"
            };

            c.PropertyGroups.Add(group);

            Product p = new Product
            {
                Name = "En iyi kedi maması",
                Category = c
            };

            p.Properties.Add(pp);
        }
    }
}
