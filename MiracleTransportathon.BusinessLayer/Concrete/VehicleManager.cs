using MiracleTransportathon.BusinessLayer.Abstract;
using MiracleTransportathon.DataAccesLayer.Abstract;
using MiracleTransportathon.EntityLayer.Concrete;

namespace MiracleTransportathon.BusinessLayer.Concrete
{
    public class VehicleManager : IVehicleService
    {
        private readonly IVehicleDal _vehicleDal;

        public VehicleManager(IVehicleDal vehicleDal)
        {
            _vehicleDal = vehicleDal;
        }

        public void TAdd(Vehicle entity)
        {
            _vehicleDal.Add(entity);
        }

        public void TDelete(Vehicle entity)
        {
            _vehicleDal.Delete(entity);
        }

        public List<Vehicle> TGetAll()
        {
            return _vehicleDal.GetAll();
        }

        public Vehicle TGetById(int id)
        {
            return _vehicleDal.GetById(id);
        }

        public void TUpdate(Vehicle entity)
        {
            _vehicleDal.Update(entity);
        }
    }
}
