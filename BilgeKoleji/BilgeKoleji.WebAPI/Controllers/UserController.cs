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
    public class UserController : ControllerBase
    {
        private readonly IUserService userService;
        public UserController(IUserService _userService)
        {
            userService = _userService;

        }
        [HttpGet]
        public List<UserDTO> Get()
        {
            return userService.getAll();
        }
        [HttpGet("{id}")]
        public UserDTO Get(int id)
        {
            return userService.getUser(id);
        }
        [HttpPost]
        public UserDTO Post(UserDTO dto)
        {
            return userService.newUser(dto);
        }
        [HttpPut]
        public UserDTO Put(UserDTO dto)
        {
            return userService.updateUser(dto);
        }
        [HttpDelete("{id}")]
        public bool delete(int id)
        {
            return userService.deleteUser(id);
        }
    }
}
