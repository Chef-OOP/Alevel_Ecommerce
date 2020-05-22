using ECommerce_Entity.Concrete;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerce_DAL.Concrete.Context
{
    public class ECommerceContext : IdentityDbContext<ApplicationUser,ApplicationRole,int>
    {

    }
}
