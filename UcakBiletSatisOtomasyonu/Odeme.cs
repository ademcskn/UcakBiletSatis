using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UcakBiletSatisOtomasyonu
{
    public partial class Odeme : Form
    {
        Koltuk koltuk;
        public Odeme(Koltuk koltuk)
        {
            this.koltuk = koltuk;
            InitializeComponent();
        }

        Context db;
        KartBilgileri KartBilgileri;

        OdemeBilgi OdemeBilgi;
        UcusBilgi ucusBilgi;
        int kisiSayisi;
        public static decimal toplamUcret;
        public static decimal bagaj = 30;

        private void Odeme_Load(object sender, EventArgs e)
        {
            grpMusteri.Enabled = grpKoltuk.Enabled = grpSeyahat.Enabled = false;
            ControlBox = false;
            cmbOdeme.Items.Add("kart");
            db = new Context();
            KartBilgileri = new KartBilgileri();

            OdemeBilgi = new OdemeBilgi();
            ucusBilgi = new UcusBilgi();

            kisiSayisi = Koltuk.kisiSayisi;
            if (Form2.DonusVarMı)
                toplamUcret = kisiSayisi * Form1.para * 2;
            else
                toplamUcret = kisiSayisi * Form1.para;


            cmbYemek.ValueMember = "YemekID";
            cmbYemek.DisplayMember = "YemekAdi";
            cmbYemek.DataSource = db.Yemekler.ToList();
            cmbYemek.SelectedIndex = -1;
            cmbAy.Items.Add("1");
            cmbYil.Items.Add("1");
        }
        private decimal OdemeMetod()
        {
            toplamUcret += (4 * (nmrBagaj.Value));
            bagaj += nmrBagaj.Value;
            switch (cmbYemek.SelectedIndex)
            {
                case 0:
                    toplamUcret += 20;

                    break;
                case 1:
                    toplamUcret += 30;
                    break;
                case 2:
                    toplamUcret += 50;
                    break;
                default:
                    break;
            }
            return toplamUcret;

        }
        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (cmbOdeme.SelectedIndex == 0)
            {
                grpKart.Visible = true;

                lblTutar.Text = OdemeMetod().ToString();

            }
            
        }

        private void btnOdeme_Click(object sender, EventArgs e)
        {
            if (Metotlar.BosAlanVarMi(grpKart))
            {
                MessageBox.Show("Eksik Bilgi Girişi Yaptınız Lütfen Zorunlu Tüm Alanı Doldurun");
            }
            else
            {
                OdemeBilgi.OdemeZamani = DateTime.Now;
                KartBilgileri.KartIsim = txtAd.Text;
                KartBilgileri.KartSoyisim = txtSoyad.Text;
                KartBilgileri.Email = txtEposta.Text;
                KartBilgileri.KartNumarasi = Convert.ToInt64(mtbKart.Text);

                OdemeBilgi.OdemeTuru = "Kart";
                OdemeBilgi.Tutar = OdemeMetod();
                db.KartBilgileri.Add(KartBilgileri);
                db.OdemeBilgileri.Add(OdemeBilgi);
                db.SaveChanges();

                int OdemeID = db.OdemeBilgileri.OrderByDescending(x => x.OdemeBilgiID).Take(1).FirstOrDefault().OdemeBilgiID;

                foreach (UcusBilgi item in db.UcusBilgileri.OrderByDescending(x => x.UcusBilgiID).Take(kisiSayisi).ToList())
                {
                    ucusBilgi = item;
                    ucusBilgi.YemekID = (int)cmbYemek.SelectedValue;
                    ucusBilgi.OdemeID = OdemeID;
                    var ucusBilgisi = db.UcusBilgileri.Where(x => x.UcusBilgiID == item.UcusBilgiID).ToList();

                    foreach (var i in ucusBilgisi)
                    {
                        i.YemekID = ucusBilgi.YemekID;
                        i.OdemeID = ucusBilgi.OdemeID;
                    }
                    db.SaveChanges();
                }
            }
            grpKart.Visible = false;
            Bilet bilet = new Bilet();
            this.Hide();
            bilet.Show();
        }

        
    }
}
