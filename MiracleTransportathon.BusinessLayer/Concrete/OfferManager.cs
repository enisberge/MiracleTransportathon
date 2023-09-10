using MiracleTransportathon.BusinessLayer.Abstract;
using MiracleTransportathon.DataAccesLayer.Abstract;
using MiracleTransportathon.EntityLayer.Concrete;

namespace MiracleTransportathon.BusinessLayer.Concrete
{
    public class OfferManager : IOfferService
    {
        private readonly IOfferDal _offerDal;

        public OfferManager(IOfferDal offerDal)
        {
            _offerDal = offerDal;
        }

        public void TAdd(Offer entity)
        {
            _offerDal.Add(entity);
        }

        public void TDelete(Offer entity)
        {
            _offerDal.Delete(entity);
        }

        public List<Offer> TGetAll()
        {
            return _offerDal.GetAll();
        }

        public Offer TGetById(int id)
        {
            return _offerDal.GetById(id);
        }

        public void TUpdate(Offer entity)
        {
            _offerDal.Update(entity);
        }
    }
}
