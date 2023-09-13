using MiracleTransportathon.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiracleTransportathon.DataAccesLayer.Abstract
{
    public interface ICompanyDal : IGenericDal<Company>
    {
        void DeleteCompany(int id);
        void UpdateCompany(Company company);
    }
}
