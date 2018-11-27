using DTO;
using System.Collections.Generic;

namespace BLL.Interfaces
{
    public interface IUserBL
    {
        IResponseData<UserDTO> GetUserSignIn(string email, string password);
        IResponseData<List<UserDTO>> GetAllUsers();
    }
}
