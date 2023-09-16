using MiracleTransportathon.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiracleTransportathon.DtoLayer.Dtos.MessageDto
{
    public class CreateMessageDto
    {
        public string MessageDetails { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public int IsRead { get; set; } = 1;
        public int IsDeleted { get; set; } = 0;

        // İlişki tanımlamaları
        public int SenderId { get; set; } = 1;//mesajı gönderen kişi
        public int ReceiverId { get; set; } = 2;
    }
}
