using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Authentication;
using System.Text;
using System.Threading.Tasks;
using TradingCompany.DAL;

namespace BLL
{
    public class UserBLL
    {
        private UserDAL _userDAL;

        public UserBLL()
        {
            _userDAL = new UserDAL();
        }

        public UserDTO GetUserSignIn(string email, string password)
        {
            UserDTO user = null;

            try
            {
                user = _userDAL.GetByEmail(email);
            }
            catch (NullReferenceException)
            {
                throw new NullReferenceException();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            if (user.Password != password)
            {
                throw new AuthenticationException();
            }

            return user;
        }
    }
}