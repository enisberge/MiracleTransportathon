using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiracleTransportathon.EntityLayer.Concrete
{
    public class Reservation
    {
        public int Id { get; set; }


        public string Description { get; set; }

        public int UserId { get; set; }//rezervasyonu yapan kullanıcı

        public User User { get; set; }
        public int RequestId { get; set; } // Kullanıcı hangi talebine rezervasyon yapıyor

        public Request Request { get; set; }

        public int OfferId { get; set; } //hangi teklifi beğenip rezervasyon yapıyor
        public Offer Offer { get; set; }
    }
}
