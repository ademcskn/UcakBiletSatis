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
    public partial class Form1 : Form
    {
        public int sayacCocuk = 0;
        public int sayacYetiskin = 1;
        public bool TekYonMu;
        string temp;
        public List<UcusBilgi> ucusBilgileri;
        Context db;
        int SinifID;
        public static decimal para;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            db = new Context();
            lblYetiskinEksi.Enabled = lblCocukEksi.Enabled = false;
            dtpDonusTarihi.MinDate = dtpGidisTarihi.MinDate = DateTime.Now;
            rdoEconomy.Checked = true;

            cmbNereden.DataSource = db.SeferBilgileri.Select(x => x.Nereden).Distinct().ToList();

            cmbNereden.DisplayMember = "Nereden";
            cmbNereden.SelectedIndex = 5;
            ucusBilgileri = new List<UcusBilgi>();

        }

        private void rdoGidisDonus_CheckedChanged(object sender, EventArgs e)
        {
            lblDonus.Visible = dtpDonusTarihi.Visible = true;
        }

        private void rdoTekYon_CheckedChanged(object sender, EventArgs e)
        {
            lblDonus.Visible = dtpDonusTarihi.Visible = false;
            TekYonMu = rdoTekYon.Checked;
        }


        private void btnUcusAra_Click(object sender, EventArgs e)
        {

            UcusBilgi ucusBilgi = new UcusBilgi();
            ucusBilgi.GidisTarihi = dtpGidisTarihi.Value;
            ucusBilgi.DonusTarihi = dtpDonusTarihi.Value;
            ucusBilgi.SeferID = db.SeferBilgileri.FirstOrDefault(x => x.Nereden == cmbNereden.Text && x.Nereye == cmbNereye.Text).SeferID;

            if (rdoBusiness.Checked == true)
                SinifID = db.Siniflar.FirstOrDefault(x => x.SinifTuru == rdoBusiness.Text).SinifID;
            else
                SinifID = db.Siniflar.FirstOrDefault(x => x.SinifTuru == rdoEconomy.Text).SinifID;

            ucusBilgi.SinifID = SinifID;
            ucusBilgileri.Add(ucusBilgi);

            para = db.SeferBilgileri.FirstOrDefault(x => x.Nereden == cmbNereden.Text && x.Nereye == cmbNereye.Text).Ucret;

            Form2 frm = new Form2(this);
            this.Hide();
            frm.Show();
        }

        private void cmbNereden_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmbNereye.SelectedIndex = -1;
            cmbNereye.DataSource = db.SeferBilgileri.Where(x => x.Nereden == cmbNereden.Text).Select(x => x.Nereye).Distinct().ToList();
            cmbNereye.DisplayMember = "Nereye";
        }



        private void lblYetiskinArtı_Click(object sender, EventArgs e)
        {
            if (sayacYetiskin >= 0)
                lblYetiskinEksi.Enabled = true;
            sayacYetiskin++;
            lblYetiskinSayac.Text = sayacYetiskin.ToString();
        }

        private void lblYetiskinEksi_Click(object sender, EventArgs e)
        {
            if (sayacYetiskin <= 2)
            {
                lblYetiskinEksi.Enabled = false;
            }
            sayacYetiskin--;
            lblYetiskinSayac.Text = sayacYetiskin.ToString();
        }

        private void lblCocukArtı_Click(object sender, EventArgs e)
        {
            if (sayacCocuk >= 0)
                lblCocukEksi.Enabled = true;
            sayacCocuk++;
            lblCocukSayac.Text = sayacCocuk.ToString();
        }

        private void lblCocukEksi_Click(object sender, EventArgs e)
        {
            if (sayacCocuk <= 1)
            {
                lblCocukEksi.Enabled = false;
            }
            sayacCocuk--;
            lblCocukSayac.Text = sayacCocuk.ToString();
        }

        private void lblDegistir_Click(object sender, EventArgs e)
        {
            if (cmbNereden.SelectedIndex > -1)
            {
                temp = cmbNereden.SelectedItem.ToString();
                cmbNereden.Text = cmbNereye.SelectedItem.ToString();
                cmbNereye.Text = temp;
            }
        }

        private void dtpGidisTarihi_ValueChanged(object sender, EventArgs e)
        {
            dtpDonusTarihi.MinDate = dtpGidisTarihi.Value.AddDays(1);
        }
    }
}

