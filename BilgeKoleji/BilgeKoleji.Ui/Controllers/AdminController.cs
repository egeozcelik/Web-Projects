using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BilgeKoleji.BLL;
using BilgeKoleji.BLL.Abstract;
using BilgeKoleji.BLL.Service;
using BilgeKoleji.DTO;
using BilgeKoleji.Model;
using BilgeKoleji.Ui.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BilgeKoleji.Ui.Controllers
{


  //  [Authorize(Roles = "Ogretmen,Müdür,Ogrenci")]

    public class AdminController : BaseController
    {
        private readonly IUserService userService;

        private readonly IOgrenciService ogrenciService;
        private readonly IOgretmenService ogretmenService;
        private readonly IDersService dersService;
        private readonly ISinifService sinifService;
        public AdminController(IUserService _userService,IOgrenciService _ogrenciService, IOgretmenService _ogretmenService, IDersService _dersService,ISinifService _sinifService) 
        {
            userService = _userService;
            ogrenciService = _ogrenciService;
            ogretmenService = _ogretmenService;
            sinifService = _sinifService;
            dersService = _dersService;
        }

        [Authorize(Roles = "Ogretmen,Müdür,Ogrenci")]
        public IActionResult Index()
        {
            return View();
        }

        [Authorize(Roles = "Ogretmen,Müdür")]
        public IActionResult OgrenciEkle()
        {
        

        OgrenciModel model = new OgrenciModel();
            model.SinifDTOs = sinifService.getAll();
            @ViewBag.SinifDTOs = new List<SelectListItem>();
            foreach (var item in model.SinifDTOs)
            {
                SelectListItem sinifs = new SelectListItem { Text = item.Adi, Value = item.Id.ToString() };
                @ViewBag.SinifDTOs.Add(sinifs);
            }

            return View(model);
        }

      
       
        [Authorize(Roles = "Ogretmen,Müdür,Ogrenci")]

        public IActionResult OgrenciListele()
        {
            OgrenciListModel model = new OgrenciListModel();
            model.sinifDTOs = sinifService.getAll();
            model.ogrenciDTOs = ogrenciService.getAll();
            
            return View(model);
        }
        [Authorize(Roles = "Ogretmen,Müdür")]

        public IActionResult OgrenciSil(int id)
        {
            ogrenciService.deleteOgrenci(id);
            return RedirectToAction("Ogrencilistele");

        }

         [Authorize(Roles = "Müdür")]
        public IActionResult OgretmenEkle()
        {
            OgretmenModel model = new OgretmenModel();
            model.DersDTOs = dersService.getAll();
            @ViewBag.DersDTOs = new List<SelectListItem>();
            foreach (var item in model.DersDTOs)
            {
                SelectListItem sinifs = new SelectListItem { Text = item.Adi, Value = item.Id.ToString() };
                @ViewBag.DersDTOs.Add(sinifs);
            }

            return View(model);
        }
        [Authorize(Roles = "Müdür")]

        [HttpPost]
        public IActionResult OgretmenEkle(OgretmenModel model,int asd)
        {
            model.Ogretmen.Ders = dersService.getDers(asd);
            OgretmenDTO dto = model.Ogretmen;
            ogretmenService.newOgretmen(dto);
            return RedirectToAction("Ogretmenlistele");

        }
        [Authorize(Roles = "Ogretmen,Müdür")]

        public IActionResult OgrenciDuzenle(int id)
        {
            OgrenciModel model = new OgrenciModel();
            model.OgrenciDTO = ogrenciService.getOgrenci(id);
            model.SinifDTOs = sinifService.getAll();
            @ViewBag.SinifDTOs = new List<SelectListItem>();
            foreach (var item in model.SinifDTOs)
            {
                SelectListItem sinifs = new SelectListItem { Text = item.Adi, Value = item.Id.ToString() };
                @ViewBag.SinifDTOs.Add(sinifs);
            }


            return View(model);
        }
     //   [Authorize(Roles = "Ogretmen,Müdür")]

        public IActionResult DersDuzenle(int id)
        {
            DersModel model = new DersModel();
            model.DersDTO = dersService.getDers(id);
            model.SinifDTOs = sinifService.getAll();
            @ViewBag.SinifDTOs = new List<SelectListItem>();
            foreach (var item in model.SinifDTOs)
            {
                SelectListItem sinifs = new SelectListItem { Text = item.Adi, Value = item.Id.ToString() };
                @ViewBag.SinifDTOs.Add(sinifs);
            }
            return View(model);
        }
     //   [Authorize(Roles = "Ogretmen,Müdür")]

        [HttpPost]
        public IActionResult DersDuzenle(DersModel model)
        {
            DersDTO dto = model.DersDTO;
            dersService.updateDers(dto);
            return RedirectToAction("DersListele");

        }
        [Authorize(Roles = "Müdür")]

        public IActionResult OgretmenDuzenle(int id)
        {
            OgretmenModel model = new OgretmenModel();
            model.Ogretmen = ogretmenService.getOgretmen(id);
            model.DersDTOs = dersService.getAll();
            @ViewBag.DersDTOs = new List<SelectListItem>();
            foreach (var item in model.DersDTOs)
            {
                SelectListItem sinifs = new SelectListItem { Text = item.Adi, Value = item.Id.ToString() };
                @ViewBag.DersDTOs.Add(sinifs);
            }

            return View(model);
        }
        [Authorize(Roles = "Ogretmen,Müdür")]
        [HttpPost]

        public IActionResult OgrenciDuzenle(OgrenciModel model)
        {
            OgrenciDTO dto = model.OgrenciDTO;
            ogrenciService.updateOgrenci(dto);
            return RedirectToAction("Ogrencilistele");

        }
        [HttpPost]
        public IActionResult OgretmenDuzenle(OgretmenModel model)
        {
            OgretmenDTO dto = model.Ogretmen;
            ogretmenService.updateOgretmen(dto);
            return RedirectToAction("Ogretmenlistele");

        }
        public IActionResult OgretmenListele()
        {
            OgretmenListModel model = new OgretmenListModel();
            model.Ogretmen = ogretmenService.getAll();
            model.DersDTOs = dersService.getAll();
            return View(model);
        }

        [Authorize(Roles = "Müdür")]
        public IActionResult OgretmenSil(int id)
        {
            ogretmenService.deleteOgretmen(id);
            return RedirectToAction("Ogretmenlistele");

        }
        [Authorize(Roles = "Ogretmen,Müdür")]

        public IActionResult SinifEkle()
        {
            SinifDTO sinif = new SinifDTO();
            return View(sinif);
        }
        [Authorize(Roles = "Ogretmen,Müdür")]

        [HttpPost]
        public IActionResult SinifEkle(SinifDTO sinif)
        {
            sinifService.newSinif(sinif);
            return RedirectToAction("SinifListele");
        }
        [Authorize(Roles = "Ogretmen,Müdür")]

        public IActionResult SinifDuzenle(int id)
        {
            SinifDTO sinif = new SinifDTO();
            sinif = sinifService.getSinif(id);

            return View(sinif);
        }
        [Authorize(Roles = "Ogretmen,Müdür")]

        [HttpPost]
        public IActionResult SinifDuzenle(SinifDTO sinif)
        {
            SinifDTO updated = sinif;
            sinifService.updateSinif(updated);
            return RedirectToAction("SinifListele");
        }
        public IActionResult SinifListele()
        {

            return View(sinifService.getAll());
        }
        [Authorize(Roles = "Ogretmen,Müdür")]

        public IActionResult SinifSil(int id)
        {
            sinifService.deleteSinif(id);
            return RedirectToAction("SinifListele");

        }
        [Authorize(Roles = "Ogretmen,Müdür")]

        public IActionResult DersEkle()
        {
            DersModel model = new DersModel();
            model.SinifDTOs = sinifService.getAll();
            @ViewBag.SinifDTOs = new List<SelectListItem>();
            foreach (var item in model.SinifDTOs)
            {
                SelectListItem sinifs = new SelectListItem { Text = item.Adi, Value = item.Id.ToString() };
                @ViewBag.SinifDTOs.Add(sinifs);
            }
            return View(model);
        }
        [Authorize(Roles = "Ogretmen,Müdür")]

        [HttpPost]
        public IActionResult OgrenciEkle(OgrenciModel model, int asd)
        {

            model.OgrenciDTO.Sinif = sinifService.getSinif(asd);
            OgrenciDTO ogrenci = model.OgrenciDTO;

            ogrenciService.newOgrenci(ogrenci);
            return RedirectToAction("Ogrencilistele");
        }
        [Authorize(Roles = "Ogretmen,Müdür")]

        [HttpPost]
        public IActionResult DersEkle(DersModel model,int asd)
        {
            model.DersDTO.Sinif = sinifService.getSinif(asd);
            DersDTO dto = model.DersDTO;
            dersService.newDers(dto);
            return RedirectToAction("DersListele");

        }
        public IActionResult DersListele()
        {
            DersModel model = new DersModel();
            model.DersDTOs = dersService.getAll();
            model.SinifDTOs = sinifService.getAll();
            return View(model);
        }

        [Authorize(Roles = "Ogretmen,Müdür")]
        public IActionResult DersSil(int id)
        {
            dersService.deleteDers(id);
            return RedirectToAction("DersListele");

        }







        [Authorize(Roles = "Ogretmen,Müdür")]
        public IActionResult UserAdd()
        {
            return View();
        }
        [Authorize(Roles = "Ogretmen,Müdür")]

        [HttpPost]
        public IActionResult UserAdd(UserDTO dto)
        {
            userService.newUser(dto);
            return RedirectToAction("UserList");
        }
       
        public IActionResult AddRole()
        {
            return View();
        }
    }
}
