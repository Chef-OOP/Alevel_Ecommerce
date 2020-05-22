﻿using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerce_Entity.Concrete.POCO
{
    public class ProductProperty : BaseEntity
    {
        public string Value { get; set; }
        public ProductPropertyGroup Group { get; set; }
        public List<Product> Products { get; set; }
    }
}