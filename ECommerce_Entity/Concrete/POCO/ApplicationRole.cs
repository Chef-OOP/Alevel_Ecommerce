using ECommerce_Entity.Abstract;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerce_Entity.Concrete.POCO
{
    public class ApplicationRole : IdentityRole<int>,IBaseEntity
    {
    }
}
