﻿using ECommerce_Entity.Concrete.POCO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce_DAL.Abstarct
{
    public interface ICustomerDal
        : IRepository<Customer>
    {
        Task<Customer> Customer(string Key);
        Task<Customer> GetByUserId(int id);
    }
}
