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
    public class GenelTabloController : ControllerBase
    {
        private readonly IGenelTablo _geneltabloService;
        public GenelTabloController(IGenelTablo geneltabloService)
        {
            _geneltabloService = geneltabloService;
        }

        [HttpGet]
        public List<GenelTabloDTO> Get()
        {
            return _geneltabloService.getAll();
        }

        [HttpGet("{id}")]
        public GenelTabloDTO Get(int id)
        {
            return _geneltabloService.getTablo(id);
        }
        [HttpPost]
        public GenelTabloDTO Post(GenelTabloDTO dto)
        {
            return _geneltabloService.newTablo(dto);
        }
        [HttpPut]
        public GenelTabloDTO Put(GenelTabloDTO dto)
        {
            return _geneltabloService.updateTablo(dto);
        }
        [HttpDelete("{id}")]
        public bool Delete(int id)
        {
            return _geneltabloService.deleteTablo(id);
        }
    }
}
