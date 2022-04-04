using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Project_Furniture.Models
{
    public class Keranjang
    {
        [Key]
        public int Id_Keranjang { get; set; }
        [Required]
        public int Jumlah_Pesan { get; set; }
        public double Total_pesan { get; set; }
        public Barang Barang { get; set; }
    }
}
