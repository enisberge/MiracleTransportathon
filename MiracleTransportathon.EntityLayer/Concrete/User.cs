using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiracleTransportathon.EntityLayer.Concrete
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string PhoneNumber { get; set; }
        public string? Address { get; set; }
        public int Status { get; set; }
        public int Role { get; set; } 
        public DateTime CreatedDate { get; set; }

        // İlişki tanımlamaları
        public List<Request> Requests { get; set; }
        public List<Message> SentMessages { get; set; }
        public List<Message> ReceivedMessages { get; set; }

        public List<Review> Reviews { get; set; }
        public List<Reservation> Reservations { get; set; }
        public Company Company { get; set; }
    }
}
