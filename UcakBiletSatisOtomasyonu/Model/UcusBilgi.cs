using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UcakBiletSatisOtomasyonu
{
    public class UcusBilgi
    {
        public int UcusBilgiID { get; set; }
        [Index(IsUnique = true)]
        [MaxLength(6)]
        public string RezervasyonKodu { get; set; }
        [Column(TypeName ="datetime2"),Required]
        public DateTime GidisTarihi { get; set; }
        [Column(TypeName = "datetime2")]
        public DateTime? DonusTarihi { get; set; }

        public bool Sigorta { get; set; }
        public bool Aktarma { get; set; }
        [Column(TypeName ="smallint")]
        public short? Indirim { get; set; }
        [Column(TypeName = "smallint")]
        public short? KoltukNo { get; set; }
        public int MusteriID { get; set; }
        
        public int SeferID { get; set; }
        public int SaatID { get; set; }
    //    [ForeignKey("Yemek")]
        public int? YemekID { get; set; }
     //   [ForeignKey("OdemeBilgi")]
        public int ? OdemeID { get; set; }
      //  [ForeignKey("Ucak")]
        public int UcakID { get; set; }
      //  [ForeignKey("Sinif")]
        public int SinifID { get; set; }

        public virtual Musteri Musteri { get; set; }
        public virtual SeferBilgi SeferBilgi { get; set; }
        public virtual SeferSaatleri SeferSaat { get; set; }
        public virtual Yemek Yemekler { get; set; }
        public virtual Ucak Ucaklar { get; set; }
        public virtual OdemeBilgi OdemeBilgileri { get; set; }
        public virtual Sinif Siniflar { get; set; }

        public override string ToString()
        {
            return $"{UcusBilgiID} - {GidisTarihi.ToShortDateString()} - {DonusTarihi.Value.ToShortDateString()} - {Sigorta} - {Aktarma} - {Indirim} - {YemekID} - {OdemeID} - {UcakID} - {SinifID}";
        }
    }
}
