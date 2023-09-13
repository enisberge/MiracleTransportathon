using MiracleTransportathon.DataAccesLayer.Abstract;
using MiracleTransportathon.DataAccesLayer.Concrete;
using MiracleTransportathon.DataAccesLayer.Repositories;
using MiracleTransportathon.EntityLayer.Concrete;

namespace EnisBlog.DataAccessLayer.EntityFramework
{
    public class EfCompanyDal : GenericRepository<Company>, ICompanyDal
    {
        public EfCompanyDal(Context context) : base(context)
        {
        }

        public void DeleteCompany(int id)
        {
            var context = new Context();
            var company = context.Companies.FirstOrDefault(u => u.Id == id);

            if (company != null)
            {
                context.Companies.Remove(company);
                context.SaveChanges();
            }
        }

        public void UpdateCompany(Company company)
        {
            var context = new Context();
            var existingCompany = context.Companies.Find(company.Id);

            if (existingCompany != null)
            {
                // Değiştirilmesini istediğiniz sütunları atan
                existingCompany.Name = company.Name;
                //existingCompany.Type = company.Type;
                existingCompany.Address = company.Address;
                existingCompany.WebSite = company.WebSite;
                existingCompany.UserId = company.UserId;                

                context.SaveChanges();
            }
        }
    }
}
