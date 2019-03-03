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
    public partial class MusteriForm : Form
    {
        Form3 form3;
        public MusteriForm(Form3 form)
        {
            form3 = form;
            InitializeComponent();
        }
        Context db;
        public List<UcusBilgi> ucusBilgileri;

        public int sayacYetiskin, sayacCocuk;
        Random random;
        public static List<Musteri> musteriler;

        private void Musteri_Load(object sender, EventArgs e)
        {
            chkErkek.Checked = true;
            chkHayir.Checked = true;
            chkTc.Checked = true;
            db = new Context();
            musteriler = new List<Musteri>();

            ucusBilgileri = form3.ucusBilgileri;
            grpKoltuk.Enabled = grpOdeme.Enabled = grpSeyahat.Enabled = false;
            ControlBox = false;
            cmbTelefon.DataSource = db.Ulkeler.ToList();
            cmbTelefon.DisplayMember = "UlkeAlanKodu";
            cmbTelefon.ValueMember = "UlkeID";
            sayacYetiskin = form3.sayacYetiskin;
            sayacCocuk = form3.sayacCocuk;
            LabelUret(sayacYetiskin, sayacCocuk);
        }

        public string KodUret()
        {
            random = new Random();
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, 6)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }

        private void LabelUret(int yetiskinSayisi, int cocukSayisi)
        {
            int locationy = panelKisiler.Location.Y - 50;
            for (int i = 1; i <= yetiskinSayisi + cocukSayisi; i++)
            {
                Label lbl = new Label();
                lbl.Location = new Point(panelKisiler.Location.X + 5, locationy);
                if (i == 1)
                    lbl.Enabled = true;
                else
                    lbl.Enabled = false;

                if (i <= yetiskinSayisi)
                {
                    lbl.Text = i + ". Yetişkin";
                    lbl.Name = "lbl" + i;
                }
                else
                {
                    lbl.Text = (i - yetiskinSayisi) + ". Çocuk";
                    lbl.Name = "lbl" + i;
                }
                locationy += 30;

                panelKisiler.Controls.Add(lbl);
            }
        }

        int labelSayac = 1;
        private void btnEkle_Click(object sender, EventArgs e)
        {
            if (Metotlar.BosAlanVarMi(grpMusteriBilgileri))
            {
                MessageBox.Show("Eksik Bilgi Girişi Yaptınız Lütfen Zorunlu Tüm Alanı Doldurun");
            }
            else
            {
                Musteri musteri = new Musteri();
                UcusBilgi ucusBilgi = new UcusBilgi();
                musteri.Ad = txtAdi.Text;
                musteri.Soyad = txtSoyadi.Text;
                musteri.TCKN = mskTc.Text;
                musteri.Ogrenci = chkEvet.Checked;
                musteri.Cinsiyet = chkErkek.Checked;
                musteri.Telefon = cmbTelefon.Text + mskTelefon.Text;
                musteri.Mail = txtEposta.Text;
                musteri.UlkeID = (int)cmbTelefon.SelectedValue;
                db.Musteriler.Add(musteri);
                musteriler.Add(musteri);
                db.SaveChanges();

                ucusBilgileri[0].MusteriID = db.Musteriler.OrderByDescending(x => x.MusteriID).Select(x => x.MusteriID).FirstOrDefault();
                ucusBilgileri[0].RezervasyonKodu = KodUret();
                ucusBilgi = ucusBilgileri[0];
        
                db.UcusBilgileri.Add(ucusBilgi);
                db.SaveChanges();

                foreach (Label item in panelKisiler.Controls)
                {
                    if (item.Name == ("lbl" + labelSayac))
                        item.Enabled = false;
                    else if (item.Name == ("lbl" + (labelSayac + 1)))
                        item.Enabled = true;
                }
                labelSayac++;
                if (labelSayac == (sayacYetiskin + sayacCocuk) + 1)
                {
                    Koltuk koltuk = new Koltuk(this);
                    form3.FormAc(koltuk);
                    //form3.lblGeri.Enabled = true;
                }

                Metotlar.Temizle(grpMusteriBilgileri);
                chkTc.Checked = true;



            }
            cmbTelefon.SelectedIndex = 0;

        }


        private void chkTc_CheckedChanged(object sender, EventArgs e)
        {
            chkDiger.Checked = !chkTc.Checked;
            lblTc.Enabled = true;
            mskTc.Enabled = true;
            if (!chkTc.Checked)
            {
                lblTc.Enabled = false;
                mskTc.Enabled = false;
            }
        }

        private void chkDiger_CheckedChanged(object sender, EventArgs e)
        {
            chkTc.Checked = !chkDiger.Checked;
            lblTc.Enabled = false;
            mskTc.Enabled = false;
            mskTc.Text = "";
            if (!chkDiger.Checked)
            {
                mskTc.Enabled = true;
                lblTc.Enabled = true;
            }
        }

        private void chkErkek_CheckedChanged(object sender, EventArgs e)
        {
            chkKadin.Checked = !chkErkek.Checked;
        }

        private void chkKadin_CheckedChanged(object sender, EventArgs e)
        {
            chkErkek.Checked = !chkKadin.Checked;
        }

        private void chkEvet_CheckedChanged(object sender, EventArgs e)
        {
            chkHayir.Checked = !chkEvet.Checked;
        }



        private void chkHayir_CheckedChanged(object sender, EventArgs e)
        {
            chkEvet.Checked = !chkHayir.Checked;
        }


    }
}
