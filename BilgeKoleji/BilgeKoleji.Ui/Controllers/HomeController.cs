using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using BilgeKoleji.Ui.Models;
using BilgeKoleji.BLL.Abstract;
using BilgeKoleji.BLL;
using Microsoft.AspNetCore.Authorization;

namespace BilgeKoleji.Ui.Controllers
{

    

    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IUserService userService;

        private readonly IOgrenciService ogrenciService;
        private readonly IOgretmenService ogretmenService;
        private readonly IDersService dersService;
        private readonly ISinifService sinifService;
        public HomeController(ILogger<HomeController> logger, 
            IOgrenciService _ogrenciService, IOgretmenService _ogretmenService ,IDersService _dersService,ISinifService _sinifService)
        {
            _logger = logger;
          
            ogrenciService = _ogrenciService;
            ogretmenService = _ogretmenService;
            sinifService = _sinifService;
            dersService = _dersService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        public IActionResult OgretmenListele()
        {
            OgretmenListModel model = new OgretmenListModel();
            model.Ogretmen = ogretmenService.getAll();
            model.DersDTOs = dersService.getAll();
            return View(model);
        }
        public IActionResult SinifListele()
        {

            return View(sinifService.getAll());
        }
        public IActionResult DersListele()
        {
            DersModel model = new DersModel();
            model.DersDTOs = dersService.getAll();
            model.SinifDTOs = sinifService.getAll();
            return View(model);
        }
        public IActionResult OgrenciListele()
        {
            OgrenciListModel model = new OgrenciListModel();
            model.sinifDTOs = sinifService.getAll();
            model.ogrenciDTOs = ogrenciService.getAll();

            return View(model);
        }
    }
}
