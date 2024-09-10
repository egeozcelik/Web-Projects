using BilgeKoleji.BLL.Abstract;
using BilgeKoleji.Core.Data.UnitOfWork;
using BilgeKoleji.DTO;
using BilgeKoleji.Mapping.ConfigProfile;
using BilgeKoleji.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BilgeKoleji.BLL.Service
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork uow;
        public UserService(IUnitOfWork _uow)
        {
            uow = _uow;
        }
        public bool deleteUser(int UserId)
        {
            try
            {
                var User = uow.GetRepository<User>().Get(z => z.Id == UserId);
                uow.GetRepository<User>().Delete(User);
                uow.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public List<UserDTO> getAll()
        {
            var userList = uow.GetRepository<User>().GetAll();
            return MapperFactory.CurrentMapper.Map<List<UserDTO>>(userList);

        }

        public UserDTO getUser(int userId)
        {
            var user = uow.GetRepository<User>().Get(z => z.Id == userId);
            return MapperFactory.CurrentMapper.Map<UserDTO>(user);

        }

        public List<UserDTO> getUserName(string userName)
        {
            var userList = uow.GetRepository<User>().Get(z => z.UserName.Contains(userName), null).ToList();
            return MapperFactory.CurrentMapper.Map<List<UserDTO>>(userList);
        }

        public UserDTO newUser(UserDTO user)
        {

            if (!uow.GetRepository<User>().GetAll().Any(z => z.UserName == user.UserName))
            {
                var eklenen = MapperFactory.CurrentMapper.Map<User>(user);
                uow.GetRepository<User>().Add(eklenen);
                uow.SaveChanges();
                return MapperFactory.CurrentMapper.Map<UserDTO>(eklenen);
            }
            else
                return null;
        }

        public UserDTO updateUser(UserDTO user)
        {

            var güncel = uow.GetRepository<User>().Get(z => z.Id == user.Id);
            güncel = MapperFactory.CurrentMapper.Map<User>(user);
            uow.GetRepository<User>().Update(güncel);
            uow.SaveChanges();
            return MapperFactory.CurrentMapper.Map<UserDTO>(güncel);
        }
        public UserDTO FindwithUsernameandMail(string mailorUserName, string password)
        {
            var getUser = uow.GetRepository<User>().Get(z =>
                 ( z.UserName == mailorUserName) && z.Password == password);
            return MapperFactory.CurrentMapper.Map<UserDTO>(getUser);
        }

        public List<UserDTO> getAllUserinRole(int RoleID)
        {
            throw new NotImplementedException();
        }
    }
}
