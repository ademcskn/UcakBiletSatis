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
    public partial class Form2 : Form
    {
        Form1 form1;
        public Form2(Form1 frm)
        {
            form1 = frm;
            InitializeComponent();
        }

        string dun, bugun, yarin, minTarih, minTarihDonus, dunDonus, bugunDonus, yarinDonus;
        int Count = 3, ilkYukseklik = 120;
        public List<UcusBilgi> ucusBilgileri;
        public int sayacYetiskin, sayacCocuk;
        Context db;
        public static bool DonusVarMı = false;
        
        

        private void Form2_Load(object sender, EventArgs e)
        {
            db = new Context();
            ucusBilgileri = new List<UcusBilgi>();
            ucusBilgileri = form1.ucusBilgileri;
            grpDun.Enabled = grpYarin.Enabled = grpDunDonus.Enabled = grpYarinDonus.Enabled = false;

            lblDun.Text = dun = ucusBilgileri[0].GidisTarihi.AddDays(-1).ToShortDateString();
            minTarih = ucusBilgileri[0].GidisTarihi.AddDays(-1).ToShortDateString();
            lblGun.Text = bugun = ucusBilgileri[0].GidisTarihi.ToShortDateString();
            lblYarin.Text = yarin = ucusBilgileri[0].GidisTarihi.AddDays(+1).ToShortDateString();

            lblDunDonus.Text = dunDonus = ucusBilgileri[0].DonusTarihi.Value.AddDays(-1).ToShortDateString();
            //minTarihDonus = bugun;
            lblGunDonus.Text = bugunDonus = ucusBilgileri[0].DonusTarihi.Value.ToShortDateString();
            lblYarinDonus.Text = yarinDonus = ucusBilgileri[0].DonusTarihi.Value.AddDays(+1).ToShortDateString();

            MainPanel.HorizontalScroll.Maximum = 0;

            grpDonus.Visible = false;

            //btn.Visible = true;
            PanelUret(Count, ilkYukseklik, grpGidis, null);

            sayacYetiskin = form1.sayacYetiskin;
            sayacCocuk = form1.sayacCocuk;
        }

        private void btnOnceki_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();
            this.Hide();
            form1.Show();
        }

        private void btnSonraki_Click(object sender, EventArgs e)
        {
            
            ucusBilgileri[0].Sigorta = false;
            ucusBilgileri[0].Aktarma = false;
            ucusBilgileri[0].SaatID = SID;
            ucusBilgileri[0].UcakID = UID;
            Form3 form3 = new Form3(this);
            this.Hide();
            form3.Show();
        }
        int SID, UID;
        private void PanelUret(int Count, int ilkYukseklik, GroupBox grp, Panel tiklananPanel)
        {
            int locationy = 130;
            int h = (ilkYukseklik * Count) + 95;
            grp.Size = new Size(780, h);


            for (int i = 0; i < Count; i++)
            {

                Panel panel = tiklananPanel ?? new Panel();

                Label lblNereden = new Label();
                Label lblNereye = new Label();
                Label lblNeredenSaat = new Label();
                Label lblNereyeSaat = new Label();
                Label lblFiyat = new Label();

                panel.Location = new Point(6, locationy);
                panel.Size = new Size(748, 100);
                panel.BorderStyle = BorderStyle.FixedSingle;
                if (tiklananPanel == null && grp.Name == "grpGidis")
                {
                    panel.Name = "panelGidis" + (i + 1);
                }
                else if (tiklananPanel == null && grp.Name == "grpDonus")
                    panel.Name = "panelDonus" + (i + 1);


                int ID = ucusBilgileri[0].SeferID;
                int Fark = db.SeferBilgileri.FirstOrDefault(x => x.SeferID == ID).SaatFarki.Fark;

                lblNereden.Location = new Point(15, 15);
                lblNereden.Text = db.SeferBilgileri.FirstOrDefault(x => x.SeferID == ID).Nereden;
                lblNereden.Width = 150;

                //int Sid = 1;
                if (panel.Name == "panelGidis1")
                {

                    //if (tiklananPanel != null)
                    //    Sid = Convert.ToInt32(tiklananPanel.Name.Last());
                    //MessageBox.Show(Sid.ToString());
                    lblNeredenSaat.Location = new Point(15, 55);
                    lblNeredenSaat.Text = db.SeferSaatleri.FirstOrDefault(x => x.SaatID == 1).KalkisSaati.ToShortTimeString();
                    lblNeredenSaat.Width = 150;

                    lblNereyeSaat.Location = new Point(300, 55);
                    lblNereyeSaat.Text = db.SeferSaatleri.FirstOrDefault(x => x.SaatID == 1).KalkisSaati.AddHours(Fark).ToShortTimeString();
                    lblNereyeSaat.Width = 150;

                    SID = UID = 1;

                }
                else if (panel.Name == "panelGidis2")
                {
                    lblNeredenSaat.Location = new Point(15, 55);
                    lblNeredenSaat.Text = db.SeferSaatleri.FirstOrDefault(x => x.SaatID == 2).KalkisSaati.ToShortTimeString();
                    lblNeredenSaat.Width = 150;

                    lblNereyeSaat.Location = new Point(300, 55);
                    lblNereyeSaat.Text = db.SeferSaatleri.FirstOrDefault(x => x.SaatID == 2).KalkisSaati.AddHours(Fark).ToShortTimeString();
                    lblNereyeSaat.Width = 150;

                    SID = UID = 2;

                }
                else if (panel.Name == "panelGidis3")
                {
                    lblNeredenSaat.Location = new Point(15, 55);
                    lblNeredenSaat.Text = db.SeferSaatleri.FirstOrDefault(x => x.SaatID == 3).KalkisSaati.ToShortTimeString();
                    lblNeredenSaat.Width = 150;

                    lblNereyeSaat.Location = new Point(300, 55);
                    lblNereyeSaat.Text = db.SeferSaatleri.FirstOrDefault(x => x.SaatID == 3).KalkisSaati.AddHours(Fark).ToShortTimeString();
                    lblNereyeSaat.Width = 150;

                    SID = UID = 3;
                }

                if (panel.Name == "panelDonus1")
                {
                    lblNeredenSaat.Location = new Point(15, 55);
                    lblNeredenSaat.Text = db.SeferSaatleri.FirstOrDefault(x => x.SaatID == 1).KalkisSaati.ToShortTimeString();
                    lblNeredenSaat.Width = 150;

                    lblNereyeSaat.Location = new Point(300, 55);
                    lblNereyeSaat.Text = db.SeferSaatleri.FirstOrDefault(x => x.SaatID == 1).KalkisSaati.AddHours(Fark).ToShortTimeString();
                    lblNereyeSaat.Width = 150;
                }
                else if (panel.Name == "panelDonus2")
                {
                    lblNeredenSaat.Location = new Point(15, 55);
                    lblNeredenSaat.Text = db.SeferSaatleri.FirstOrDefault(x => x.SaatID == 2).KalkisSaati.ToShortTimeString();
                    lblNeredenSaat.Width = 150;

                    lblNereyeSaat.Location = new Point(300, 55);
                    lblNereyeSaat.Text = db.SeferSaatleri.FirstOrDefault(x => x.SaatID == 2).KalkisSaati.AddHours(Fark).ToShortTimeString();
                    lblNereyeSaat.Width = 150;
                }
                else if (panel.Name == "panelDonus3")
                {
                    lblNeredenSaat.Location = new Point(15, 55);
                    lblNeredenSaat.Text = db.SeferSaatleri.FirstOrDefault(x => x.SaatID == 3).KalkisSaati.ToShortTimeString();
                    lblNeredenSaat.Width = 150;

                    lblNereyeSaat.Location = new Point(300, 55);
                    lblNereyeSaat.Text = db.SeferSaatleri.FirstOrDefault(x => x.SaatID == 3).KalkisSaati.AddHours(Fark).ToShortTimeString();
                    lblNereyeSaat.Width = 150;
                }


                lblNereye.Location = new Point(300, 15);
                lblNereye.Text = db.SeferBilgileri.FirstOrDefault(x => x.SeferID == ID).Nereye;
                lblNereye.Width = 150;



                lblFiyat.Location = new Point(600, 15);
                lblFiyat.Text = db.SeferBilgileri.FirstOrDefault(x => x.SeferID == ID).Ucret.ToString();
                lblFiyat.Width = 150;


                panel.Controls.Add(lblNereden);
                panel.Controls.Add(lblNeredenSaat);
                panel.Controls.Add(lblNereye);
                panel.Controls.Add(lblNereyeSaat);
                panel.Controls.Add(lblFiyat);



                grp.Controls.Add(panel);

                panel.Click += Panel_Click;
                locationy += 110;
            }
        }

        //private void PanelTemizle(GroupBox grp)
        //{
        //    foreach (Control item in grp.Controls)
        //    {

        //    }
        //}


        private void PanelTemizle(GroupBox grp)
        {
            foreach (Control item in grp.Controls)
            {
                if (item is Panel)
                {
                    Panel p = item as Panel;
                    grp.Controls.Remove(p);
                }
            }
        }

        private void Panel_Click(object sender, EventArgs e)
        {
            Panel tiklanan = sender as Panel;
            if (tiklanan.Name.Contains("panelGidis"))
            {

                PanelTemizle(grpGidis);
                PanelUret(1, 140, grpGidis, tiklanan);
                ucusBilgileri[0].GidisTarihi = Convert.ToDateTime(lblGun.Text);


                if (!form1.TekYonMu)
                {
                    grpDonus.Visible = true;
                    DonusVarMı = true;
                    PanelUret(Count, ilkYukseklik, grpDonus, null);
                    btnOnceki.Location = new Point(38, grpDonus.Location.Y + grpDonus.Height + 20);
                    btnSonraki.Location = new Point(658, grpDonus.Location.Y + grpDonus.Height + 20);
                    //btn.Location = new Point(MainPanel.Width / 2, grpDonus.Location.Y + grpDonus.Height);

                }
                else
                {
                    btnOnceki.Location = new Point(38, grpGidis.Location.Y + grpGidis.Height + 20);
                    btnSonraki.Location = new Point(658, grpGidis.Location.Y + grpGidis.Height + 20);
                }



            }
            else if (tiklanan.Name.Contains("panelDonus"))
            {
                PanelTemizle(grpDonus);
                PanelUret(1, 140, grpDonus, tiklanan);
                ucusBilgileri[0].DonusTarihi = Convert.ToDateTime(lblGunDonus.Text);

                btnOnceki.Location = new Point(38, grpDonus.Location.Y + grpDonus.Height + 20);
                btnSonraki.Location = new Point(658, grpDonus.Location.Y + grpDonus.Height + 20);
            }
        }

        private void lblIleri_Click(object sender, EventArgs e)
        {
            lblDun.Text = dun = Convert.ToDateTime(dun).AddDays(+1).ToShortDateString();
            minTarihDonus = lblGun.Text = bugun = Convert.ToDateTime(bugun).AddDays(+1).ToShortDateString();
            lblYarin.Text = yarin = Convert.ToDateTime(yarin).AddDays(+1).ToShortDateString();

            if (Convert.ToDateTime(bugun) == Convert.ToDateTime(lblGunDonus.Text))
            {
                lblDunDonus.Text = dunDonus = Convert.ToDateTime(dun).AddDays(+1).ToShortDateString();
                lblGunDonus.Text = bugunDonus = Convert.ToDateTime(bugun).AddDays(+1).ToShortDateString();
                lblYarinDonus.Text = yarinDonus = Convert.ToDateTime(yarin).AddDays(+1).ToShortDateString();
            }

            //PanelUret(Count, ilkYukseklik, grpGidis);
        }

        private void lblGeri_Click(object sender, EventArgs e)
        {
            if (minTarih == dun)
                return;
            lblDun.Text = dun = Convert.ToDateTime(dun).AddDays(-1).ToShortDateString();
            lblGun.Text = bugun = Convert.ToDateTime(bugun).AddDays(-1).ToShortDateString();
            lblYarin.Text = yarin = Convert.ToDateTime(yarin).AddDays(-1).ToShortDateString();

            //PanelUret(Count, ilkYukseklik, grpGidis);
        }

        private void lblDonusIleri_Click(object sender, EventArgs e)
        {
            lblDunDonus.Text = dunDonus = Convert.ToDateTime(dunDonus).AddDays(+1).ToShortDateString();
            lblGunDonus.Text = bugunDonus = Convert.ToDateTime(bugunDonus).AddDays(+1).ToShortDateString();
            lblYarinDonus.Text = yarinDonus = Convert.ToDateTime(yarinDonus).AddDays(+1).ToShortDateString();
            //PanelUret(Count, ilkYukseklik, grpGidis);
        }

        private void lblDonusGeri_Click(object sender, EventArgs e)
        {
            if (Convert.ToDateTime(lblDunDonus.Text) == Convert.ToDateTime(lblGun.Text))
                return;
            lblDunDonus.Text = dunDonus = Convert.ToDateTime(dunDonus).AddDays(-1).ToShortDateString();
            lblGunDonus.Text = bugunDonus = Convert.ToDateTime(bugunDonus).AddDays(-1).ToShortDateString();
            lblYarinDonus.Text = yarinDonus = Convert.ToDateTime(yarinDonus).AddDays(-1).ToShortDateString();
            //PanelUret(Count, ilkYukseklik, grpGidis);
        }
    }
}
