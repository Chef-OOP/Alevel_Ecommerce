using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerce_Entity.Concrete.POCO
{
    public class TicketResponse
    {
        public int Id { get; set; }
        public DateTime Created { get; set; }
        public string Content { get; set; }
        public int OwnerId { get; set; }
        public ApplicationUser ApplicationUser { get; set; }
        public int TicketId { get; set; }
        public Ticket Ticket { get; set; }
    }
}
