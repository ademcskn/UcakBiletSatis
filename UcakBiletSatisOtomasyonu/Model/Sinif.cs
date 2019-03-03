using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UcakBiletSatisOtomasyonu
{
    public class Sinif
    {
        [Key]
        public int SinifID { get; set; }
        [Required]
        public string SinifTuru { get; set; }//economi-business
        public virtual List<UcusBilgi> UcusBilgileri { get; set; }
    }
}
