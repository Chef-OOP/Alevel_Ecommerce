using ECommerce_Entity.Concrete.Constants;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce_Entity.DTOs
{
    public class UserForRegisterDto
    {
        [Required(ErrorMessage = "Email Zorounlu Alan")]
        [EmailAddress]
        public string Email { get; set; }
        [Required(ErrorMessage = "Password Alanı zorunludur")]
        public string Password { get; set; }
        [Required(ErrorMessage = "ConfirmPassword alanı zorunludur")]
        [Compare("Password", ErrorMessage = "Şifrede Uyuşmazlık muvcut")]
        public string ConfirmPassword { get; set; }
        [Required(ErrorMessage = "İsim Alanı Zorounlu")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Soyisim  Alanı Zorounlu")]
        public string LastName { get; set; }
        public string Profession { get; set; }
        public Gender Gender { get; set; } = Gender.Other;
        [Required(ErrorMessage = "TCKN  Alanı Zorounlu")]
        public string TCKN { get; set; }
        public bool AllowEmail { get; set; } = false;
        public bool AllowSms { get; set; } = false;
        [Required(ErrorMessage ="Telefon Alanı Zorunldur")]
        //[Phone]
        public string CellPhone { get; set; }
        public int CustomerId { get; set; } = 0;
    }
}
