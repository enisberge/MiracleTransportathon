using MiracleTransportathon.BusinessLayer.Abstract;
using MiracleTransportathon.DataAccesLayer.Abstract;
using MiracleTransportathon.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiracleTransportathon.BusinessLayer.Concrete
{
    public class CityManager : ICityService
    {
        private readonly ICityDal _cityDal;

        public CityManager(ICityDal cityDal)
        {
            _cityDal = cityDal;
        }

        public void TAdd(City entity)
        {
           _cityDal.Add(entity);
        }

        public void TDelete(City entity)
        {
            _cityDal.Delete(entity);
        }

        public List<City> TGetAll()
        {
            return _cityDal.GetAll();
        }

        public City TGetById(int id)
        {
            return _cityDal.GetById(id);
        }

        public void TUpdate(City entity)
        {
            _cityDal.Update(entity);
        }
    }
}
