using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce_Entity.Concrete.POCO
{
    public class Customer
    {
        public int Id { get; set; }
        public string Key { get; set; }//Tek Zorunlu Alana Burası
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string CellPhone { get; set; }
        public string Email { get; set; }
        public int? AppUserId { get; set; }
        public AppUser AppUser { get; set; }
        public virtual ICollection<Invoice> Invoices { get; set; }
        public virtual ICollection<Address> Address { get; set; }
        public virtual ICollection<OrderItem> OrderItems { get; set; }
    }
}
