using MiracleTransportathon.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiracleTransportathon.BusinessLayer.Abstract
{
    public interface IUserService: IGenericService<User>
    {
        void DeleteUser(int id);
        void TUpdateUser(User user);
        void RegisterUser(User user);
    }
}
