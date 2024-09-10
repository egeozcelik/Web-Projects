using BilgeKoleji.Core.Services;
using BilgeKoleji.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace BilgeKoleji.BLL.Abstract
{
   public interface IRoleService: IServiceBase
    {
        List<RoleDTO> getAll();
        RoleDTO getRole(int roleId);
        List<RoleDTO> getRoleName(string roleName);
        RoleDTO newRole(RoleDTO role);
        RoleDTO updateRole(RoleDTO role);
        bool deleteRole(int RoleId);
    }
}
