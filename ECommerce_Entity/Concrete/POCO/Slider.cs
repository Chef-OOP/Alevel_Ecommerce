using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerce_Entity.Concrete.POCO
{
    public class Slider : BaseEntity
    {
        public string Name { get; set; }
        public List<SliderImage> Images { get; set; }
    }
}
