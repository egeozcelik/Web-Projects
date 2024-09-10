using BilgeKoleji.Core.Services;
using BilgeKoleji.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace BilgeKoleji.BLL.Abstract
{
   public interface IUserService : IServiceBase
    {
        List<UserDTO> getAll();
        UserDTO getUser(int userId);
        List<UserDTO> getUserName(string userName);
        UserDTO newUser(UserDTO user);
        UserDTO updateUser(UserDTO user);
        bool deleteUser(int UserId);
        UserDTO FindwithUsernameandMail(string mailorUserName, string password);
        List<UserDTO> getAllUserinRole(int RoleID);
    }
}
