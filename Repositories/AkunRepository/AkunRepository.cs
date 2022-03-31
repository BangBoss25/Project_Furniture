using Microsoft.EntityFrameworkCore;
using Project_Furniture.Data;
using Project_Furniture.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project_Furniture.Repositories.AkunRepository
{
    public class AkunRepository : IAkunRepository
    {
        private readonly AppDbContext _context;

        public AkunRepository(AppDbContext db)
        {
            _context = db;
        }

        public async Task<bool> DaftarUserAsync(User data)
        {
            _context.Tb_User.Add(data);
            await _context.SaveChangesAsync();

            return true;
        }


        // USER
        public async Task<List<User>> AmbilSemuaUserAsync()
        {
            return await _context.Tb_User.Include(x => x.Roles).ToListAsync();
        }

        public async Task<User> AmbilUserByUsernameAsync(string username)
        {
            return await _context.Tb_User.FindAsync(username);
        }


        //ROLES
        public async Task<List<Roles>> AmbilSemuaRolesAsync()
        {
            return await _context.Tb_Roles.ToListAsync();
        }

        public async Task<Roles> AmbilRolesByIdAsync(string id)
        {
            return await _context.Tb_Roles.FindAsync(id);
        }
    }
}
