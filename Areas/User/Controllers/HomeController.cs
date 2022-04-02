using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Project_Furniture.Services.BarangService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project_Furniture.Areas.User.Controllers
{
    [Authorize(Roles = "User")]
    [Area("User")]
    public class HomeController : Controller
    {
        private readonly IBarangService _service;

        public HomeController(IBarangService serv)
        {
            _service = serv;
        }

        public IActionResult Index()
        {
            var brg = _service.AmbilSemuaBarang();
            return View(brg);
        }
    }
}
