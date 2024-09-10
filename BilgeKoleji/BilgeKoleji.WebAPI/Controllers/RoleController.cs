using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BilgeKoleji.BLL.Abstract;
using BilgeKoleji.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BilgeKoleji.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoleController : ControllerBase
    {
        private readonly IRoleService roleService;
        public RoleController(IRoleService _roleService)
        {
            roleService = _roleService;
        }
        [HttpGet]
        public List<RoleDTO> Get()
        {
            return roleService.getAll();
        }
        [HttpGet("{id}")]
        public RoleDTO Get(int id)
        {
            return roleService.getRole(id);
        }
        [HttpPost]
        public RoleDTO Post(RoleDTO dto)
        {
            return roleService.newRole(dto);
        }
        [HttpPut]
        public RoleDTO Put(RoleDTO dto)
        {
            return roleService.updateRole(dto);
        }
        [HttpDelete("{id}")]
        public bool delete(int id)
        {
            return roleService.deleteRole(id);
        }
    }
}
