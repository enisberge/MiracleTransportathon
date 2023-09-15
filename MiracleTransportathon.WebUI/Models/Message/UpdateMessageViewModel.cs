namespace MiracleTransportathon.WebUI.Models.Message
{
    public class UpdateMessageViewModel
    {
        public int Id { get; set; }
        public string MessageDetails { get; set; }
        public int IsRead { get; set; }
        public int IsDeleted { get; set; }

        // İlişki tanımlamaları
        public int SenderId { get; set; }//mesajı gönderen kişi
        public int ReceiverId { get; set; }
    }
}
