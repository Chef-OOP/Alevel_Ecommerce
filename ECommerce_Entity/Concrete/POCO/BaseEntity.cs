﻿using ECommerce_Entity.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerce_Entity.Concrete.POCO
{
    public class BaseEntity : IBaseEntity
    {
        public BaseEntity()
        {
            Created = DateTime.Now;
            Updated = DateTime.Now;
            IsActive = true;
            IsDeleted = false;
        }
        public int Id { get; set; }
        public bool IsDeleted { get; set; }
        public bool IsActive { get; set; }
        public DateTime Created { get; set; }
        public DateTime Updated { get; set; }
    }
}
