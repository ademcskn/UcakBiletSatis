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
    public partial class Form3 : Form
    {
        Form2 form2;
        public Form3(Form2 form)
        {
            form2 = form;
            InitializeComponent();
        }
        int sayac = 0;
        public List<UcusBilgi> ucusBilgileri;
        public int sayacYetiskin, sayacCocuk;

        private void Form3_Load(object sender, EventArgs e)
        {
            ucusBilgileri = form2.ucusBilgileri;
            sayacYetiskin = form2.sayacYetiskin;
            sayacCocuk = form2.sayacCocuk;
            MusteriForm musteri = new MusteriForm(this);
            FormAc(musteri);
            //lblGeri.Enabled = false;

        }

        public void FormAc(Form frm)
        {
            bool durum = false;
            foreach (Form childiren in this.MdiChildren)
            {

                if (durum) return;

                if (childiren.Text == frm.Text)
                {
                    durum = true;
                    childiren.WindowState = FormWindowState.Maximized;
                    childiren.Activate();
                }
            }
            if (durum == false)
            {

                frm.MdiParent = this;
                frm.WindowState = FormWindowState.Maximized;
                frm.Show();

            }
        }

        //private void lblIleri_Click(object sender, EventArgs e)
        //{
        //    lblGeri.Enabled = true;
        //    sayac++;
        //    switch (sayac)
        //    {

        //        case 1:

        //            //Koltuk koltuk = new Koltuk();
        //            //FormAc(koltuk);
        //            break;
        //        case 2:

        //            Odeme odeme = new Odeme();
        //            FormAc(odeme);
        //            break;
        //        case 3:

        //            Bilet seyahat = new Bilet();
        //            FormAc(seyahat);
        //            lblIleri.Enabled = false;
        //            break;
        //        default:
                    
        //            break;

        //    }
        //}

        //private void lblGeri_Click(object sender, EventArgs e)
        //{
        //    lblIleri.Enabled = true;
        //    sayac--;
        //    switch (sayac)
        //    {
        //        case 0:
        //            MusteriForm musteri = new MusteriForm(this);
        //            FormAc(musteri);
        //            lblGeri.Enabled = false;
        //            break;
        //        case 1:

        //            Koltuk koltuk = new Koltuk();
        //            FormAc(koltuk);
        //            break;
        //        case 2:                    
        //            Odeme odeme = new Odeme();
        //            FormAc(odeme);
                    
        //            break;
        //    }
        //}
    }
}
