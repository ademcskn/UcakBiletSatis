using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UcakBiletSatisOtomasyonu
{
    public class SeferSaatleri
    {   
        [Key]
        public int SaatID { get; set; }
        [Required]
        //[Column(TypeName = "datetime2")]
        [DataType(DataType.Time)]
        public DateTime KalkisSaati { get; set; }
        //[DataType(DataType.Time)]
        //public DateTime DonusSaati { get; set; }
        //[Column(TypeName = "datetime2")]

        public virtual List<UcusBilgi> UcusBilgileri{ get; set; }
    }
}
