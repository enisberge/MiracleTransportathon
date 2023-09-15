using MiracleTransportathon.DtoLayer.Dtos.RequestDto;
using MiracleTransportathon.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiracleTransportathon.DataAccesLayer.Abstract
{
    public interface IRequestDal : IGenericDal<Request>
    {
        List<RequestListDto> GetAllRequest();
        RequestListDto GetRequestById(int id);
    }
}
