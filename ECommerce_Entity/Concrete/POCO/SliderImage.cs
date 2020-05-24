using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerce_Entity.Concrete.POCO
{
    public class SliderImage
    {
        public int Id { get; set; }
        public bool IsDeleted { get; set; }
        public string Path { get; set; }
        public int DisplayIndex { get; set; }
        public int SliderId { get; set; }
        public Slider Slider { get; set; }
    }
}
