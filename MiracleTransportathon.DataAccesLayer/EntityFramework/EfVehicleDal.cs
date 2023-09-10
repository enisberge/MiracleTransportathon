using MiracleTransportathon.DataAccesLayer.Abstract;
using MiracleTransportathon.DataAccesLayer.Concrete;
using MiracleTransportathon.DataAccesLayer.Repositories;
using MiracleTransportathon.EntityLayer.Concrete;

namespace EnisBlog.DataAccessLayer.EntityFramework
{
    public class EfVehicleDal : GenericRepository<Vehicle>, IVehicleDal
    {
        public EfVehicleDal(Context context) : base(context)
        {
        }
    }
}
