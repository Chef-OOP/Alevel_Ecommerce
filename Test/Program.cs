using ECommerce_Entity.Concrete.POCO;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {


            #region PredicateBuldierTest

            List<Person> people = new List<Person>()
            {
                new Person(){ Id=1, Name="Ali"},
                new Person(){ Id=2, Name="Veli"},
                new Person(){ Id=3, Name="bak"},
            };

            var predicate = PredicateBuilder.False<Product>();
            string[] keywords = new string[]
            {
                "ali","ata","bak"
            };
            foreach (string keyword in keywords)
            {
                string temp = keyword;
                predicate = predicate.Or(p => p.Description.Contains(temp));
            }
            //var a =people.AsQueryable().Where(predicate);
            #endregion




            //ProductPropertyGroup group = new ProductPropertyGroup
            //{
            //    Name = "Aroma"
            //};
            //ProductProperty pp = new ProductProperty
            //{
            //    Value = "Tavuklu",
            //   Group = group
            //};

            //Category c = new Category
            //{
            //    Name = "Kedi maması"
            //};

            ////c.PropertyGroups.Add(group);

            //Product p = new Product
            //{
            //    Name = "En iyi kedi maması",
            //    Category = c
            //};

            //p.Properties.Add(pp);
        }
    }
    class Person
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
