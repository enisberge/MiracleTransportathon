using MiracleTransportathon.BusinessLayer.Abstract;
using MiracleTransportathon.DataAccesLayer.Abstract;
using MiracleTransportathon.DtoLayer.Dtos.RequestDto;
using MiracleTransportathon.EntityLayer.Concrete;

namespace MiracleTransportathon.BusinessLayer.Concrete
{
    public class RequestManager : IRequestService
    {
        private readonly IRequestDal _requestDal;

        public RequestManager(IRequestDal requestDal)
        {
            _requestDal = requestDal;
        }

        public List<RequestListDto> GetAllRequest()
        {
          return _requestDal.GetAllRequest();
        }

        public RequestListDto GetRequestById(int id)
        {
           return _requestDal.GetRequestById(id);
        }

        public void TAdd(Request entity)
        {
            _requestDal.Add(entity);
        }

        public void TDelete(Request entity)
        {
            _requestDal.Delete(entity);
        }

        public List<Request> TGetAll()
        {
            return _requestDal.GetAll();
        }

        public Request TGetById(int id)
        {
            return _requestDal.GetById(id);
        }

        public void TUpdate(Request entity)
        {
            _requestDal.Update(entity);
        }
    }
}
