using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiracleTransportathon.EntityLayer.Concrete
{
    public class Review
    {
        public int Id { get; set; }

        public int Rating { get; set; }
        public string Comment { get; set; }
        public DateTime CreatedDate { get; set; }
        public int UserId { get; set; }//değerlendirmeyi yapan kullanıcı

        public User User { get; set; }

        public int CompanyId { get; set; }

        public Company Company { get; set; }
    }
}
