using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiracleTransportathon.EntityLayer.Concrete
{
    public class Chat 
    {
        //kullanıcılarla mesajlaştığımız her oturum bir sohbet oluyor. eğer bir kullanıcı kendi tarafından sohbeti silmek isterse karşı taraftan silinmesin diye bunu yaptık. Bu sohbet numarasını 
        public int Id { get; set; }
        public string Subject { get; set; }//sohbetin konusu burada olsun
        public DateTime CreatedDate { get; set; }
    }
}
