﻿using ECommerce_Entity.Abstract;
using ECommerce_Entity.Concrete.Constants;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerce_Entity.Concrete.POCO
{
    public class ApplicationUser : IdentityUser<int>, IBaseEntity
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public Gender Gender { get; set; }
        public List<Address> Addresses { get; set; }
    }
}
