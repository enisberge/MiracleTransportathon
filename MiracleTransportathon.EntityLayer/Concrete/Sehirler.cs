using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiracleTransportathon.EntityLayer.Concrete
{
    public class Sehirler
    {
        public int SehirId { get; set; }
        public string SehirAdi { get; set; }
        public byte PlakaNo { get; set; }
        public int TelefonKodu { get; set; }
        public int RowNumber { get; set; }
    }
}
