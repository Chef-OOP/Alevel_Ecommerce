using ECommerce_Entity.Concrete.POCO;
using ECommerce_Entity.Constant;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce_Business.Abstarct
{
    public interface IAddressService
        : IGenericService<Address>
    {
        Task<EntityResult<Address>> Address(Guid guid);
    }
}
