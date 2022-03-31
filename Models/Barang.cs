using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Project_Furniture.Models
{
    public class Barang
    {
        public int Id { get; set; }
        [Required]
        public string NamaBarang { get; set; }
        public string Image { get; set; }
        [Required]
        public int Stok { get; set; }
        [Required]
        public int Harga { get; set; }
        public int Terjual { get; set; }
        [Required]
        public string Deskripsi { get; set; }
    }
}
