using Microsoft.EntityFrameworkCore;
using MiracleTransportathon.DataAccesLayer.Abstract;
using MiracleTransportathon.DataAccesLayer.Concrete;
using MiracleTransportathon.DataAccesLayer.Repositories;
using MiracleTransportathon.EntityLayer.Concrete;

namespace EnisBlog.DataAccessLayer.EntityFramework
{
    public class EfUserDal : GenericRepository<User>, IUserDal
    {
        public EfUserDal(Context context) : base(context)
        {
        }

        public void DeleteUser(int id)
        {
            var context = new Context();
            var user = context.Users.FirstOrDefault(u => u.Id == id);

            if (user != null)
            {
                context.Users.Remove(user);
                context.SaveChanges();
            }
        }

        public void UpdateUser(User user)
        {
            var context = new Context();
            var existingUser = context.Users.Find(user.Id);

            if (existingUser != null)
            {
                // Değiştirilmesini istediğiniz sütunları atan
                existingUser.Name = user.Name;
                existingUser.Surname= user.Surname;
                existingUser.Email = user.Email;
                existingUser.Username= user.Username;
                existingUser.Password= user.Password;
                existingUser.Address= user.Address;
                existingUser.Status= user.Status;
                existingUser.PhoneNumber= user.PhoneNumber;
                existingUser.Role= user.Role;

                context.SaveChanges();
            }
        }
    }
}
