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
    public class OgretmenController : ControllerBase
    {
        private readonly IOgretmenService _ogretmenService;
        public OgretmenController(IOgretmenService ogretmenService)
        {
            _ogretmenService = ogretmenService;
        }
        [HttpGet]
        public List<OgretmenDTO> Get()
        {
            return _ogretmenService.getAll();
        }

        [HttpGet("{id}")]
        public OgretmenDTO Get(int id)
        {
            return _ogretmenService.getOgretmen(id);
        }
        [HttpPost]
        public OgretmenDTO Post(OgretmenDTO dto)
        {
            return _ogretmenService.newOgretmen(dto);
        }
        [HttpPut]
        public OgretmenDTO Put(OgretmenDTO dto)
        {
            return _ogretmenService.updateOgretmen(dto);
        }
        [HttpDelete("{id}")]
        public bool Delete(int id)
        {
            return _ogretmenService.deleteOgretmen(id);
        }
    }
}
