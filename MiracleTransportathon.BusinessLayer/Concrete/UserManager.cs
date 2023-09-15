using MiracleTransportathon.BusinessLayer.Abstract;
using MiracleTransportathon.DataAccesLayer.Abstract;
using MiracleTransportathon.EntityLayer.Concrete;

namespace MiracleTransportathon.BusinessLayer.Concrete
{
    public class UserManager : IUserService
    {
        private readonly IUserDal _userDal;

        public UserManager(IUserDal userDal)
        {
            _userDal = userDal;
        }

        public void DeleteUser(int id)
        {
           _userDal.DeleteUser(id);
        }

        public void RegisterUser(User user)
        {
           _userDal.RegisterUser(user);
        }

        public void TAdd(User entity)
        {
            _userDal.Add(entity);
        }

        public void TDelete(User entity)
        {
            _userDal.Delete(entity);
        }

        public List<User> TGetAll()
        {
            return _userDal.GetAll();
        }

        public User TGetById(int id)
        {
            return _userDal.GetById(id);
        }

        public void TUpdate(User entity)
        {
            _userDal.Update(entity);
        }

        public void TUpdateUser(User user)
        {
            _userDal.UpdateUser(user);
        }
    }
}
