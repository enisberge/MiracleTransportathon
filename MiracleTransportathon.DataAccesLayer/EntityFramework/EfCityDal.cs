using MiracleTransportathon.DataAccesLayer.Abstract;
using MiracleTransportathon.DataAccesLayer.Concrete;
using MiracleTransportathon.DataAccesLayer.Repositories;
using MiracleTransportathon.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiracleTransportathon.DataAccesLayer.EntityFramework
{
    public class EfCityDal : GenericRepository<City>, ICityDal//
    {
        public EfCityDal(Context context) : base(context)
        {
        }
    }
}
