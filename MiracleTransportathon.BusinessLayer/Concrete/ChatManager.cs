using MiracleTransportathon.BusinessLayer.Abstract;
using MiracleTransportathon.DataAccesLayer.Abstract;
using MiracleTransportathon.EntityLayer.Concrete;

namespace MiracleTransportathon.BusinessLayer.Concrete
{
    public class ChatManager : IChatService
    {
        private readonly IChatDal _chatDal;

        public ChatManager(IChatDal chatDal)
        {
            _chatDal = chatDal;
        }

        public void TAdd(Chat entity)
        {
            _chatDal.Add(entity);
        }

        public void TDelete(Chat entity)
        {
            _chatDal.Delete(entity);
        }

        public List<Chat> TGetAll()
        {
           return _chatDal.GetAll();
        }

        public Chat TGetById(int id)
        {
            return _chatDal.GetById(id);
        }

        public void TUpdate(Chat entity)
        {
            _chatDal.Update(entity);
        }
    }
}
