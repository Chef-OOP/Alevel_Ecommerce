using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerce_Entity.Concrete.POCO
{
    public class Campaign : BaseEntity
    {
        public string Title { get; set; }
        public string Detail { get; set; }
        public string ImagePath { get; set; }
        public DateTime BeginDate { get; set; }
        public DateTime EndDate { get; set; }
        public List<ProductCampaign> ProductCampaign { get; set; }
    }
}
