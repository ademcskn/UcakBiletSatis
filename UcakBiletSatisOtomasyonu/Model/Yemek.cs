using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UcakBiletSatisOtomasyonu
{
    public class Yemek
    {
        [Key]
        public int YemekID { get; set; }
        [MaxLength(50)]
        public string YemekAdi { get; set; }
        public virtual List<UcusBilgi> UcusBilgileri { get; set; }
    }
}
