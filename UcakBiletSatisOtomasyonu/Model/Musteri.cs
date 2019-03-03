using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UcakBiletSatisOtomasyonu
{
    public class Musteri
    {
        public int MusteriID { get; set; }
        [Required,MaxLength(30)]
        public string Ad { get; set; }
        [Required,MaxLength(50)]
        public string Soyad { get; set; }
        public string TCKN { get; set; }
        public bool Ogrenci { get; set; }
        [Required]
        public bool Cinsiyet { get; set; }
        [Required,MaxLength(13)]
        public string Telefon { get; set; }
        [Required]
        public string Mail { get; set; }
        //  [ForeignKey("Ulke")]
        public int UlkeID { get; set; }

        [NotMapped]
        public string FullName
        {
            get
            {
                return Ad + " " + Soyad;
            }
        }


        public virtual List<UcusBilgi> UcusBilgileri { get; set; }

        public virtual Ulke Ulke { get; set; }











    }
}
