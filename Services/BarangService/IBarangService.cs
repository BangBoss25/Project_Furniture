using Microsoft.AspNetCore.Http;
using Project_Furniture.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project_Furniture.Services.BarangService
{
    public interface IBarangService
    {
        List<Barang> AmbilSemuaBarang();
        Barang AmbilBarangById(int Id);
        bool BuatBarang(Barang data, IFormFile Image);
        bool HapusBarang(int id);
        bool UbahBarang(Barang fromView, IFormFile Image);
    }
}
