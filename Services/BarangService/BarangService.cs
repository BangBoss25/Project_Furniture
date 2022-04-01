﻿using Microsoft.AspNetCore.Http;
using Project_Furniture.Models;
using Project_Furniture.Repositories.BarangRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project_Furniture.Services.BarangService
{
    public class BarangService : IBarangService
    {
        private readonly IBarangRepository _repo;
        private readonly FileService _file;

        public BarangService(IBarangRepository r, FileService f)
        {
            _repo = r;
            _file = f;
        }

        public Barang AmbilBarangById(int Id)
        {
            return _repo.AmbilBarangByIdAsync(Id).Result;
        }

        public List<Barang> AmbilSemuaBarang()
        {
            return _repo.AmbilSemuaBarang().Result;
        }

        public bool BuatBarang(Barang data, IFormFile Image)
        {
            data.Image = _file.SaveFile(Image).Result;
            data.Terjual = 0;

            return _repo.BuatBarangAsync(data).Result;
        }

        public bool HapusBarang(int id)
        {
            var brg = _repo.CariBarangAsync(id).Result;

            return _repo.HapusBarangAsync(brg).Result;
        }
    }
}
