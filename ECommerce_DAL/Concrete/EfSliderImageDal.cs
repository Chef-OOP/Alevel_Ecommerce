using ECommerce_DAL.Abstarct;
using ECommerce_DAL.Concrete.Context;
using ECommerce_Entity.Concrete.POCO;
using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerce_DAL.Concrete
{
    public class EfSliderImageDal : EfEntityRepository<SliderImage,ECommerceContext>,ISliderImageDal
    {
        public EfSliderImageDal(ECommerceContext context) : base(context)
        {

        }
    }
}
