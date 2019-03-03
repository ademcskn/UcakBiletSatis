using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UcakBiletSatisOtomasyonu
{
    public class OdemeBilgi
    {
        public int OdemeBilgiID { get; set; }
        [Required]
        [MaxLength(15)]
        public string OdemeTuru { get; set; }
        [Required,Column(TypeName = "datetime2")]
        public DateTime OdemeZamani { get; set; }
        [Column(TypeName = "money")]
        public decimal Tutar { get; set; }

        public virtual List<UcusBilgi> UcusBilgileri { get; set; }
        public virtual KartBilgileri  KartBilgi { get; set; }
    }
}
