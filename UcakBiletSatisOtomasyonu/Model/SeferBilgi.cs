using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UcakBiletSatisOtomasyonu
{
    public class SeferBilgi
    {
        [Key]
        public int SeferID { get; set; }
        [MaxLength(20)]
        public string Nereden { get; set; }
        [MaxLength(20)]
        public string Nereye { get; set; }
        [Column(TypeName = "money")]
        public decimal Ucret { get; set; }
        [Required]
        public bool UcusTuru { get; set; }//yurtiçi-yurtdışı

        public int SaatFarkiID { get; set; }

        public virtual SaatFarki SaatFarki { get; set; }

        public virtual List<UcusBilgi> UcusBilgileri { get; set; }
    }
}
