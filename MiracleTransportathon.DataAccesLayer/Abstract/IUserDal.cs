using MiracleTransportathon.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiracleTransportathon.DataAccesLayer.Abstract
{
    public interface IUserDal : IGenericDal<User>
    {
        void DeleteUser(int id);
        void UpdateUser(User user);
        
    }
}
