using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UcakBiletSatisOtomasyonu
{
    public class KartBilgileri
    {   

        public int KartID { get; set; }
        [MaxLength(50),Required]
        public string KartIsim { get; set; }
        [MaxLength(50), Required]
        public string KartSoyisim { get; set; }
        [MaxLength(50), Required]
        public string Email { get; set; }
        [Column(TypeName = "bigint")]
        public long KartNumarasi { get; set; }

        public virtual OdemeBilgi OdemeBilgi { get; set; }
    }
}
