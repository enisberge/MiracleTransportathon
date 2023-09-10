using MiracleTransportathon.DataAccesLayer.Abstract;
using MiracleTransportathon.DataAccesLayer.Concrete;
using MiracleTransportathon.DataAccesLayer.Repositories;
using MiracleTransportathon.EntityLayer.Concrete;

namespace EnisBlog.DataAccessLayer.EntityFramework
{
    public class EfChatDal : GenericRepository<Chat>, IChatDal//
    {
        public EfChatDal(Context context) : base(context)
        {
        }
    }
}
