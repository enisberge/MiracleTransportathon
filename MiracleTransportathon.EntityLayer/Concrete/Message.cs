using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiracleTransportathon.EntityLayer.Concrete
{
    public class Message
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public DateTime CreatedDate { get; set; }
        public int IsRead { get; set; }
        public int IsDeleted { get; set; }

        // İlişki tanımlamaları
        public int SenderId { get; set; }//mesajı gönderen kişi
        public User Sender { get; set; }
        public int ReceiverId { get; set; } //mesajı alan kişi
        public User Receiver { get; set; }

    }
}
