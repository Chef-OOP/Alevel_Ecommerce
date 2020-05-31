using ECommerce_Entity.Concrete.POCO;
using ECommerce_Entity.Constant;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce_Business.Abstarct
{
    public interface ICustomerService
        : IGenericService<Customer>
    {
        Task<EntityResult<Customer>> Customer(string Key);
        Task<EntityResult<Customer>> GetByUserId(int id);
    }
}
