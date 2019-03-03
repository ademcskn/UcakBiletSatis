using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UcakBiletSatisOtomasyonu
{
    public class SaatFarki
    {   
        [Key]
        public int SaatFarkiID { get; set; }
        [Column(TypeName = "smallint")]
        public short Fark { get; set; }

        public virtual List<SeferBilgi> SeferBilgileri { get; set; }
    }
}
