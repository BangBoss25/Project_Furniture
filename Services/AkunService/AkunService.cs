using Project_Furniture.Models;
using Project_Furniture.Repositories.AkunRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project_Furniture.Services.AkunService
{
    public class AkunService : IAkunService
    {
        private readonly IAkunRepository _ar;
        public AkunService(IAkunRepository ar)
        {
            _ar = ar;
        }

        public bool DaftarUser(User data)
        {
            data.Roles = _ar.AmbilRolesByIdAsync("2").Result;
            return _ar.DaftarUserAsync(data).Result;
        }


        // User
        public List<User> AmbilSemuaUser()
        {
            return _ar.AmbilSemuaUserAsync().Result;
        }

        public User AmbilUserByUsername(string username)
        {
            return _ar.AmbilUserByUsernameAsync(username).Result;
        }

        // Roles
        public List<Roles> AmbilSemuaRoles()
        {
            return _ar.AmbilSemuaRolesAsync().Result;
        }

        public Roles AmbilRolesById(string id)
        {
            return _ar.AmbilRolesByIdAsync(id).Result;
        }
    }
}
