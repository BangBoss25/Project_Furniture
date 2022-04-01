using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Project_Furniture.Models;
using Project_Furniture.Services.BarangService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project_Furniture.Areas.Admin.Controllers
{
    [Authorize (Roles = "Admin")]
    [Area ("Admin")]
    public class BarangController : Controller
    {
        private readonly IBarangService _service;

        public BarangController(IBarangService serv)
        {
            _service = serv;
        }

        public IActionResult Index()
        {
            var data = _service.AmbilSemuaBarang();

            return View(data);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Barang brg, IFormFile Image)
        {
            if (ModelState.IsValid)
            {
                _service.BuatBarang(brg, Image);

                return RedirectToAction("Index");
            }

            return View(brg);
        }

        public IActionResult Hapus(int Id)
        {
            var search = _service.AmbilBarangById(Id);
            
            if (search != null)
            {
                _service.HapusBarang(Id);

                return RedirectToAction("Index");
            }

            return NotFound();
        }
    }
}
