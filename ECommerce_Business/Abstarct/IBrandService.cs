using ECommerce_Entity.Concrete.POCO;
using ECommerce_Entity.Constant;
using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerce_Business.Abstarct
{
    public interface IBrandService : IGenericService<Brand>
    {
        EntityResult<List<Brand>> Brands(List<Product> products);
    }
}
