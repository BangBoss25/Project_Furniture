using Microsoft.EntityFrameworkCore;
using Project_Furniture.Data;
using Project_Furniture.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project_Furniture.Repositories.BarangRepository
{
    public class BarangRepository : IBarangRepository
    {
        private readonly AppDbContext _context;

        public BarangRepository(AppDbContext db)
        {
            _context = db;
        }

        public async Task<Barang> AmbilBarangByIdAsync(int Id)
        {
            return await _context.Tb_Barang.FirstOrDefaultAsync(x => x.Id == Id);
        }

        public async Task<List<Barang>> AmbilSemuaBarang()
        {
            return await _context.Tb_Barang.ToListAsync();
        }

        public async Task<bool> BuatBarangAsync(Barang data)
        {
            _context.Add(data);
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<Barang> CariBarangAsync(int Id)
        {
            return await _context.Tb_Barang.FirstOrDefaultAsync(x => x.Id == Id);
        }

        public async Task<bool> HapusBarangAsync(Barang data)
        {
            _context.Remove(data);
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<bool> UbahBarangAsync(Barang data)
        {
            _context.Update(data);
            await _context.SaveChangesAsync();

            return true;
        }
    }
}
