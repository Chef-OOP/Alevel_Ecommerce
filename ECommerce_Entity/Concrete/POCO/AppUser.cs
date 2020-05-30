using ECommerce_Entity.Concrete.Constants;
using System;
using System.Collections.Generic;

namespace ECommerce_Entity.Concrete.POCO
{
    /// <summary>
    /// JWT altyapısı için Core katmanında Oluşturulan Kullanıcı Tablosu
    /// </summary>
    public class AppUser : BaseEntity
    {
        //TODO : Genişetilecek
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public bool Status { get; set; }
        public byte[] PasswordSalt { get; set; }
        public byte[] PasswordHash { get; set; }
        public Gender Gender { get; set; }
        public string TCKN { get; set; }
        public bool AllowEmail { get; set; }
        public bool AllowSms { get; set; }

        public string RefreshToken { get; set; }
        public DateTime? RefreshTokenEndDate { get; set; }

        public virtual ICollection<Address> Address { get; set; }
        public virtual ICollection<Customer> Customers { get; set; }
        public virtual ICollection<UserOperationClaims> UserOperationClaims { get; set; }
    }
}
