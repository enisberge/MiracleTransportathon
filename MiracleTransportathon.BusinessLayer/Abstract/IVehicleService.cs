using MiracleTransportathon.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiracleTransportathon.BusinessLayer.Abstract
{
    public interface IVehicleService : IGenericService<Vehicle>
    {
        void DeleteVehicle(int id);
        void TUpdateVehicle(Vehicle vehicle);
    }
}
