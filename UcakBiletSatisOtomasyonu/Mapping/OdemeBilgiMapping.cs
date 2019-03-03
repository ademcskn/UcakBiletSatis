using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UcakBiletSatisOtomasyonu.Mapping
{
    public class OdemeBilgiMapping:EntityTypeConfiguration<OdemeBilgi>
    {
        public OdemeBilgiMapping()
        {
            HasKey(x => x.OdemeBilgiID);
            HasRequired(x => x.KartBilgi).WithRequiredPrincipal(x => x.OdemeBilgi);
        }
    }
}
