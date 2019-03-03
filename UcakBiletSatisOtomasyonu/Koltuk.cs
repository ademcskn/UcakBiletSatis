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
    public partial class Koltuk : Form
    {
        MusteriForm MusteriForm;
        public Koltuk(MusteriForm form)
        {
            MusteriForm = form;
            InitializeComponent();
        }

        PictureBox p;
        int baslangic = 2;
        public static int seciliMusteri = 0;
        public List<UcusBilgi> ucusBilgileri;
        public static List<Musteri> Musteriler;
        bool cinsiyet;
        Context db;
        public static int kisiSayisi;
        int sayi;

        private void Koltuk_Load(object sender, EventArgs e)
        {

            db = new Context();
            Musteriler = MusteriForm.musteriler;
            ucusBilgileri = MusteriForm.ucusBilgileri;

            seciliMusteri = MusteriForm.sayacYetiskin + MusteriForm.sayacCocuk;

            grpMusteri.Enabled = grpOdeme.Enabled = grpSeyahat.Enabled = false;
            ControlBox = false;
            int Count = 40;
            KoltukPanel.Width = 6 * 69;
            KoltukPanel.Height = (40 / 4) * 53;
            cinsiyet = Musteriler[0].Cinsiyet;

            kisiSayisi = MusteriForm.sayacYetiskin + MusteriForm.sayacCocuk;
            sayi = kisiSayisi;
            LabelUret(MusteriForm.sayacYetiskin, MusteriForm.sayacCocuk);

            for (int i = 1; i <= Count; i++)
            {
                p = new PictureBox();
                p.Width = 69;
                p.Height = 53;
                if (i <= Count / 2)
                    p.Name = "BusinessKoltuk " + i;
                else
                    p.Name = "EconomyKoltuk " + i;
                p.Image = Image.FromFile("../../Images/Bos.png");
                p.Image.Tag = "bos";
                p.Click += Koltuk_Click;
                if (i == baslangic)
                {
                    p.Margin = new Padding(0, 3, 40, 0);
                    baslangic += 5;
                }
                KoltukPanel.Controls.Add(p);
            }
        }
        int cinsiyetSayac = 0;
        private void LabelUret(int yetiskinSayisi, int cocukSayisi)
        {
            int locationy = panelKisiler.Location.Y + 10;
            for (int i = 1; i <= yetiskinSayisi + cocukSayisi; i++)
            {
                Label lbl = new Label();
                lbl.Location = new Point(panelKisiler.Location.X + 5, locationy);
                if (i == 1)
                    lbl.Enabled = true;
                else
                    lbl.Enabled = false;

                lbl.Text = Musteriler[i - 1].Ad + " " + Musteriler[i - 1].Soyad;
                lbl.Name = "lbl" + i;
                lbl.Width = 175;

                locationy += 30;
                lbl.Tag = MusteriForm.musteriler[cinsiyetSayac].Cinsiyet;
                panelKisiler.Controls.Add(lbl);
                cinsiyetSayac++;
            }
        }

        //int tiklananIndex,sonrakiTiklanan;
        int labelSayac = 1;
        
        private void Koltuk_Click(object sender, EventArgs e)
        {
            PictureBox tiklanan = sender as PictureBox;
            //tiklanın indexini alacağımız kod
            //tiklananIndex = KoltukPanel.Controls.GetChildIndex(tiklanan);

            if (tiklanan.Image.Tag.ToString() == "bos")
            {
                if (cinsiyet)
                {
                    if (seciliMusteri == 0)
                        return;
                    else
                    {
                        if (ucusBilgileri[0].SinifID == 1 && tiklanan.Name.Contains("Economy"))
                        {
                            tiklanan.Image = Image.FromFile("../../Images/Bay.png");
                            tiklanan.Image.Tag = "dolu";
                            tiklanan.Tag = "Erkek";
                            tiklanan.Name.Last();
                            seciliMusteri--;
                            labelSayac++;
                        }
                        else if (!tiklanan.Name.Contains("Business"))
                            MessageBox.Show("Lütfen Business alanından koltuk seçiniz");


                        if (ucusBilgileri[0].SinifID == 2 && tiklanan.Name.Contains("Business"))
                        {
                            tiklanan.Image = Image.FromFile("../../Images/Bay.png");
                            tiklanan.Image.Tag = "dolu";
                            tiklanan.Tag = "Erkek";
                            seciliMusteri--;
                            labelSayac++;
                        }
                        else if (!tiklanan.Name.Contains("Economy"))
                            MessageBox.Show("Lütfen Economy alanından koltuk seçiniz");
                    }

                    foreach (Musteri item in Musteriler)
                    {
                        UcusBilgi ucusBilgi = db.UcusBilgileri.FirstOrDefault(x=>x.MusteriID == item.MusteriID);
                        string[] No = tiklanan.Name.Split(' ');
                        ucusBilgi.KoltukNo = Convert.ToInt16(No[1]);
                        foreach(UcusBilgi bilgi in db.UcusBilgileri.ToList())
                        {
                            bilgi.KoltukNo = ucusBilgi.KoltukNo;
                            db.SaveChanges();
                        }
                    }
                }
                else
                {
                    if (seciliMusteri == 0)
                        return;
                    else
                    {
                        if (ucusBilgileri[0].SinifID == 1 && tiklanan.Name.Contains("Economy"))
                        {
                            tiklanan.Image = Image.FromFile("../../Images/Bayan.png");
                            tiklanan.Image.Tag = "dolu";
                            tiklanan.Tag = "Kadin";
                            seciliMusteri--;
                            labelSayac++;
                        }
                        else if (!tiklanan.Name.Contains("Business"))
                            MessageBox.Show("Lütfen Business alanından koltuk seçiniz");


                        if (ucusBilgileri[0].SinifID == 2 && tiklanan.Name.Contains("Business"))
                        {
                            tiklanan.Image = Image.FromFile("../../Images/Bayan.png");
                            tiklanan.Image.Tag = "dolu";
                            tiklanan.Tag = "Kadin";
                            seciliMusteri--;
                            labelSayac++;
                        }
                        else if (!tiklanan.Name.Contains("Economy"))
                            MessageBox.Show("Lütfen Economy alanından koltuk seçiniz");
                    }
                    foreach (Musteri item in Musteriler)
                    {
                        UcusBilgi ucusBilgi = db.UcusBilgileri.FirstOrDefault(x => x.MusteriID == item.MusteriID);
                        string[] No = tiklanan.Name.Split(' ');
                        ucusBilgi.KoltukNo = Convert.ToInt16(No[1]);
                        foreach (UcusBilgi bilgi in db.UcusBilgileri.ToList())
                        {
                            bilgi.KoltukNo = ucusBilgi.KoltukNo;
                            db.SaveChanges();
                        }
                    }
                }

            }
            else if (tiklanan.Image.Tag.ToString() == "dolu")
            {
                if (tiklanan.Tag.ToString() == "Erkek")
                {
                    seciliMusteri++;
                    tiklanan.Image = Image.FromFile("../../Images/Bos.png");
                    tiklanan.Image.Tag = "bos";
                }
                else if (tiklanan.Tag.ToString() == "Kadin")
                {
                    seciliMusteri++;
                    tiklanan.Image = Image.FromFile("../../Images/Bos.png");
                    tiklanan.Image.Tag = "bos";
                }
                labelSayac--;
            }

            foreach (Label item in panelKisiler.Controls)
            {
                if (item.Name == ("lbl" + labelSayac))
                {
                    item.Enabled = true;
                    cinsiyet = (bool)item.Tag;
                }
                else if (item.Name == ("lbl" + (labelSayac + 1)))
                    item.Enabled = false;

                if (item.Name == ("lbl" + (labelSayac - 1)))
                {
                    item.Enabled = false;
                    cinsiyet = (bool)item.Tag;
                }

            }
        }

        private void btnOdemeYap_Click(object sender, EventArgs e)
        {
            Odeme odeme = new Odeme(this);
            this.Hide();
            odeme.Show();
        }


    }
}
