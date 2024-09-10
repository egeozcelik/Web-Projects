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
    public class RoleService : IRoleService
    {
        private readonly IUnitOfWork uow;
        public RoleService(IUnitOfWork _uow)
        {
            uow = _uow;
        }

        public bool deleteRole(int RoleId)
        {
            try
            {
                var role = uow.GetRepository<Role>().Get(z => z.Id == RoleId);
                uow.GetRepository<Role>().Delete(role);
                uow.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public List<RoleDTO> getAll()
        {
            var roleList = uow.GetRepository<Role>().GetAll();
            return MapperFactory.CurrentMapper.Map<List<RoleDTO>>(roleList);
        }

        public RoleDTO getRole(int roleId)
        {
            var role = uow.GetRepository<Role>().Get(z => z.Id == roleId);
            return MapperFactory.CurrentMapper.Map<RoleDTO>(role);

        }

        public List<RoleDTO> getRoleName(string roleName)
        {
            var roleList = uow.GetRepository<Role>().Get(z => z.Name.Contains(roleName), null).ToList();
            return MapperFactory.CurrentMapper.Map<List<RoleDTO>>(roleList);
        }

        public RoleDTO newRole(RoleDTO role)
        {

            if (!uow.GetRepository<Role>().GetAll().Any(z => z.Name == role.Name))
            {
                var eklenen = MapperFactory.CurrentMapper.Map<Role>(role);
                uow.GetRepository<Role>().Add(eklenen);
                uow.SaveChanges();
                return MapperFactory.CurrentMapper.Map<RoleDTO>(eklenen);
            }
            else
                return null;
        }

        public RoleDTO updateRole(RoleDTO role)
        {
            var güncel = uow.GetRepository<Role>().Get(z => z.Id == role.Id);
            güncel = MapperFactory.CurrentMapper.Map<Role>(role);
            uow.GetRepository<Role>().Update(güncel);
            uow.SaveChanges();
            return MapperFactory.CurrentMapper.Map<RoleDTO>(güncel);
        }
    }
}
