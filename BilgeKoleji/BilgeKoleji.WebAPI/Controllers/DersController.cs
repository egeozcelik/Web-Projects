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
    public class DersController : ControllerBase
    {
        private readonly IDersService _dersService;
        public DersController(IDersService dersService)
        {
            _dersService = dersService;
        }
        [HttpGet]
        public List<DersDTO> Get()
        {
            return _dersService.getAll();
        }

        [HttpGet("{id}")]
        public DersDTO Get(int id)
        {
            return _dersService.getDers(id);
        }
        [HttpPost]
        public DersDTO Post(DersDTO dto)
        {
            return _dersService.newDers(dto);
        }
        [HttpPut]
        public DersDTO Put(DersDTO dto)
        {
            return _dersService.updateDers(dto);
        }
        [HttpDelete("{id}")]
        public bool Delete(int id)
        {
            return _dersService.deleteDers(id);
        }
    }


}
