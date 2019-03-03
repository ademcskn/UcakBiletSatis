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
    public partial class Bilet : Form
    {
        public Bilet()
        {
            InitializeComponent();
        }
        Context db;
        private void Bilet_Load(object sender, EventArgs e)
        {
            db = new Context();
            grpMusteri.Enabled = grpKoltuk.Enabled = grpOdeme.Enabled = false;
            ControlBox = false;
            cmbMusteriler.SelectedIndex = -1;
            cmbMusteriler.DataSource = MusteriForm.musteriler;
            cmbMusteriler.ValueMember = "MusteriID";
            cmbMusteriler.DisplayMember = "FullName";

        }
        int ID;
        private void cmbMusteriler_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnGöster_Click(object sender, EventArgs e)
        {
            ID = (int)cmbMusteriler.SelectedValue;
            UcusBilgi ucusBilgi = db.UcusBilgileri.FirstOrDefault(x => x.MusteriID == ID);
            Musteri musteri = db.Musteriler.FirstOrDefault(x => x.MusteriID == ID);
            if (musteri.TCKN == "")
                lblTCNo.Text = "Diğer Ülke Vatandaşı";
            else
                lblTCNo.Text = musteri.TCKN;
            lblAd.Text = musteri.Ad;
            lblSoyadi.Text = musteri.Soyad;
            lblRezervasyonKodu.Text = ucusBilgi.RezervasyonKodu;
            lblSinif.Text = ucusBilgi.Siniflar.SinifTuru;
            lblKalkısSaati.Text = ucusBilgi.SeferSaat.KalkisSaati.ToShortTimeString();
            //lblVarisSaati.Text = ucusBilgi.SeferSaat.KalkisSaati.AddHours(ucusBilgi.SeferBilgi.SaatFarki).ToShortTimeString();
            lblYemek.Text = ucusBilgi.Yemekler.YemekAdi;
            lblCinsiyet.Text = musteri.Cinsiyet ? "Bay" : "Bayan";
            lblEposta.Text = musteri.Mail;
            lblNereden.Text = ucusBilgi.SeferBilgi.Nereden;
            lblNereye.Text = ucusBilgi.SeferBilgi.Nereye;
            lblTelefon.Text = musteri.Telefon;
            lblBagaj.Text = Odeme.bagaj + " kg";
            lblKoltuk.Text = ucusBilgi.KoltukNo.ToString();
            lblUcret.Text = (Odeme.toplamUcret / Koltuk.kisiSayisi).ToString();
                
        }
    }
}
