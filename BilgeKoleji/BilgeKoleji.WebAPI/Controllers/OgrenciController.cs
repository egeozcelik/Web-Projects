using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BilgeKoleji.BLL.Abstract;
using BilgeKoleji.DTO;
using BilgeKoleji.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BilgeKoleji.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OgrenciController : ControllerBase
    {
        private readonly IOgrenciService ogrenciService;
        public OgrenciController(IOgrenciService _ogrenciService)
        {
            ogrenciService = _ogrenciService;
        }
        [HttpGet]
        public List<OgrenciDTO> Get()
        {
            return ogrenciService.getAll();
        }
        [HttpGet("{id}")]
        public OgrenciDTO Get(int id)
        {
            return ogrenciService.getOgrenci(id);
        }
        [HttpPost]
        public OgrenciDTO Post(OgrenciDTO dto)
        {
            return ogrenciService.newOgrenci(dto);
        }
        [HttpPut]
        public OgrenciDTO Put(OgrenciDTO dto)
        {
            return ogrenciService.updateOgrenci(dto);
        }
        [HttpDelete("{id}")]
        public bool delete(int id)
        {
            return ogrenciService.deleteOgrenci(id);
        }
    }
}
