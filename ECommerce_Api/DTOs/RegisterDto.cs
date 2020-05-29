using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce_Api.DTOs
{
    public class RegisterDto
    {
        [Required(ErrorMessage = "UserName Alanı Zorunlu")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Name Alanı Zorunlu")]
        [MaxLength(50,ErrorMessage ="Name max 50 karakter")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Surname Alanı Zorunlu")]
        [MaxLength(50, ErrorMessage = "Surname max 50 karakter")]
        public string Surname { get; set; }
        [Required(ErrorMessage = "TCKN Alanı Zorunlu")]
        [MaxLength(11, ErrorMessage = "TCKN max 11 karakter")]
        public string TCKN { get; set; }
        [Required(ErrorMessage ="Email Alanı Zorunludur")]
        [EmailAddress]
        public string Email { get; set; }
        public bool AllowEmail { get; set; }
        public bool AllowSms { get; set; }
        [Required(ErrorMessage ="Şifre Alanı Gereklidir")]
        [PasswordPropertyText]
        public string  Password  { get; set; }
        [Required(ErrorMessage = "Şifre Tekrar Alanı Gereklidir")]
        [PasswordPropertyText]
        [Compare("Password",ErrorMessage ="Şifre Uyuşumsuz")]
        public string  ConfirmPassword  { get; set; }

        
    }
}
