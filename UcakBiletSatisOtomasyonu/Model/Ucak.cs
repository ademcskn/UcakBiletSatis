using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UcakBiletSatisOtomasyonu
{
    public class Ucak
    {
        [Key]
        public int UcakID { get; set; }
        [Required,Column(TypeName ="smallint")]
        public short Kapasite { get; set; }
        public virtual List<UcusBilgi> UcusBilgileri { get; set; }
    }
}
