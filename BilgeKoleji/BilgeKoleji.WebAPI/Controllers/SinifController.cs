using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BilgeKoleji.BLL;
using BilgeKoleji.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BilgeKoleji.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SinifController : ControllerBase
    {
        private readonly ISinifService _sinifService;
        public SinifController(ISinifService sinifService)
        {
            _sinifService = sinifService;
        }
        [HttpGet]
        public List<SinifDTO> Get()
        {
            return _sinifService.getAll();
        }

        [HttpGet("{id}")]
        public SinifDTO Get(int id)
        {
            return _sinifService.getSinif(id);
        }
        [HttpPost]
        public SinifDTO Post(SinifDTO dto)
        {
            return _sinifService.newSinif(dto);
        }
        [HttpPut]
        public SinifDTO Put(SinifDTO dto)
        {
            return _sinifService.updateSinif(dto);
        }
        [HttpDelete("{id}")]
        public bool Delete(int id)
        {
            return _sinifService.deleteSinif(id);
        }
    }
}
