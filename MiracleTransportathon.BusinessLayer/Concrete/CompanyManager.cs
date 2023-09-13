using MiracleTransportathon.BusinessLayer.Abstract;
using MiracleTransportathon.DataAccesLayer.Abstract;
using MiracleTransportathon.EntityLayer.Concrete;

namespace MiracleTransportathon.BusinessLayer.Concrete
{
    public class CompanyManager : ICompanyService
    {
        private readonly ICompanyDal _companyDal;

        public CompanyManager(ICompanyDal companyDal)
        {
            _companyDal = companyDal;
        }

        public void DeleteCompany(int id)
        {
            _companyDal.DeleteCompany(id);
        }

        public void TAdd(Company entity)
        {
            _companyDal.Add(entity);
        }

        public void TDelete(Company entity)
        {
            _companyDal.Delete(entity);
        }

        public List<Company> TGetAll()
        {
            return _companyDal.GetAll();
        }

        public Company TGetById(int id)
        {
            return _companyDal.GetById(id);
        }

        public void TUpdate(Company entity)
        {
            _companyDal.Update(entity);
        }

        public void TUpdateCompany(Company company)
        {
            _companyDal.UpdateCompany(company);
        }
    }
}
