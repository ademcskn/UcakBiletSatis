using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UcakBiletSatisOtomasyonu
{
    public class Ulke
    {
        [Key]
        public int UlkeID { get; set; }
        [Required]
        [MaxLength(50)]
        public string UlkeAdi { get; set; }
        [Required]
        [MaxLength(5)]
        public string UlkeAlanKodu { get; set; }
        //[ForeignKey("Musteri")]
        //public int MusteriID { get; set; }
        public virtual List<Musteri> Musteri { get; set; }
    }
}
