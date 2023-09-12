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

        public void DeleteVehicle(int id)
        {
            var context = new Context();
            var vehicle = context.Vehicles.FirstOrDefault(u => u.Id == id);

            if (vehicle != null)
            {
                context.Vehicles.Remove(vehicle);
                context.SaveChanges();
            }
        }

        public void UpdateVehicle(Vehicle vehicle)
        {
            var context = new Context();
            var existingVehicle = context.Vehicles.Find(vehicle.Id);

            if (existingVehicle != null)
            {
                // Değiştirilmesini istediğiniz sütunları atan
                existingVehicle.Type = vehicle.Type;
                existingVehicle.Brand = vehicle.Brand;
                existingVehicle.Model = vehicle.Model;
                existingVehicle.Plate = vehicle.Plate;
                existingVehicle.DriverName = vehicle.DriverName;
                existingVehicle.DriverPhoneNumber = vehicle.DriverPhoneNumber;
                existingVehicle.Year = vehicle.Year;
                existingVehicle.CompanyId = vehicle.CompanyId;

                context.SaveChanges();
            }
        }
    }
}
