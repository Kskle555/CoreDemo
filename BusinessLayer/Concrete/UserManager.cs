using BusinessLayer.Abstract;
using DataAccesLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class UserManager : IUserService
    {
        IUserdal _userDal;

        public UserManager(IUserdal userDal)
        {
            _userDal = userDal;
        }

        public List<AppUser> GetList()
        {
            throw new NotImplementedException();
        }

        public void TAdd(AppUser t)
        {
            throw new NotImplementedException();
        }

        public void TDelete(AppUser t)
        {
            throw new NotImplementedException();
        }

        public AppUser TGetById(int id)
        {
            return _userDal.GetByID(id);
        }

        public void TUpdate(AppUser t)
        {
             _userDal.Update(t);
        }
    }
}
