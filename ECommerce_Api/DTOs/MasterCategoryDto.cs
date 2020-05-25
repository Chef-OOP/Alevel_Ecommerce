﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce_Api.DTOs
{
    public class MasterCategoryDto
    {
        public int Id { get; set; }
        public bool IsDeleted { get; set; }
        public bool IsActive { get; set; }
        public DateTime Created { get; set; }
        public DateTime Updated { get; set; }

        [Required(ErrorMessage ="Üst kategori İsim alanı zorunludur!!!")]
        [Display(Name="Üst kategori adı: ")]
        public string Name { get; set; }
        public string Description { get; set; }
        public string ImagePath { get; set; }
        public string Logo { get; set; }
    }
}
