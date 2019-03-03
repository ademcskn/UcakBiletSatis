using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UcakBiletSatisOtomasyonu.Mapping
{
    public class KartBilgileriMapping: EntityTypeConfiguration<KartBilgileri>
    {
        public KartBilgileriMapping()
        {
            HasKey(x => x.KartID);
        }
    }
}
