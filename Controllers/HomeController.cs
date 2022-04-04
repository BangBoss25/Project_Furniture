using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Project_Furniture.Helper;
using Project_Furniture.Models;
using Project_Furniture.Services.BarangService;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Project_Furniture.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IBarangService _serv;

        public HomeController(ILogger<HomeController> logger, IBarangService serv)
        {
            _logger = logger;
            _serv = serv;
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


        public IActionResult UserFurn()
        {
            var data = _serv.AmbilSemuaBarang();
            return View(data);
        }

        public IActionResult DetailBarang(int Id)
        {
            Barang search = _serv.AmbilBarangById(Id);

            if (search != null)
            {
                return View(search);
            }

            return NotFound();
        }
    }
}
