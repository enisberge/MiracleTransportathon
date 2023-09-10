using MiracleTransportathon.DataAccesLayer.Abstract;
using MiracleTransportathon.DataAccesLayer.Concrete;
using MiracleTransportathon.DataAccesLayer.Repositories;
using MiracleTransportathon.EntityLayer.Concrete;

namespace EnisBlog.DataAccessLayer.EntityFramework
{
    public class EfOfferDal : GenericRepository<Offer>, IOfferDal
    {
        public EfOfferDal(Context context) : base(context)
        {
        }
    }
}
