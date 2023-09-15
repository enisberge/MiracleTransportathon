using MiracleTransportathon.DtoLayer.Dtos.RequestDto;
using MiracleTransportathon.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiracleTransportathon.BusinessLayer.Abstract
{
    public interface IRequestService: IGenericService<Request>
    {
        List<RequestListDto> GetAllRequest();

        RequestListDto GetRequestById(int id);

    }
}
