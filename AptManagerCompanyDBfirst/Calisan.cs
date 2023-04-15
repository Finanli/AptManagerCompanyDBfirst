using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AptManagerCompanyDBfirst
{
    public partial class Calisan : Form
    {
        public Calisan()
        {
            InitializeComponent();
        }

        private void exitb_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        AptManagerCompanyEntities baglan = new AptManagerCompanyEntities();

        public void Listele()
        {
            dataGridView1.DataSource = baglan.Calisanlars.ToList();
        }
        private void listb_Click(object sender, EventArgs e)
        {
            Listele();
        }

        private void updateb_Click(object sender, EventArgs e)
        {
            string had = hizmetcbx.Text;
            var hizm = baglan.Hizmetlers.Where(x => x.hizmetAdi == had).Select(x => x.hizmetNo).FirstOrDefault();
            int cno = Convert.ToInt32(cadtxt.Tag);
            var yenile = baglan.Calisanlars.Where(x=> x.calisanNo == cno).FirstOrDefault();

            yenile.calisanAd = cadtxt.Text;
            yenile.verdigiHizmet = hizm;
            yenile.calismaTipi = ctipcbx.Text;

            baglan.SaveChanges();
            Listele();

        }

        private void addb_Click(object sender, EventArgs e)
        {
            Calisanlar save = new Calisanlar();
            

            string had = hizmetcbx.Text;
            var hizm = baglan.Hizmetlers.Where(x => x.hizmetAdi == had).Select(x => x.hizmetNo).FirstOrDefault();
            
            save.calisanAd = cadtxt.Text;
            save.verdigiHizmet = hizm;
            save.calismaTipi = ctipcbx.Text;

            baglan.Calisanlars.Add(save);
            baglan.SaveChanges();
            Listele();
        }

        private void Calisan_Load(object sender, EventArgs e)
        {
            hizmetcbx.DataSource = baglan.Hizmetlers.ToList();
            hizmetcbx.ValueMember = "HizmetNo";
            hizmetcbx.DisplayMember = "hizmetAdi";
        }

        private void deleteb_Click(object sender, EventArgs e)
        {
            int cno = Convert.ToInt32(cadtxt.Tag);
            var sil = baglan.Calisanlars.Where(x => x.calisanNo == cno).FirstOrDefault();

            baglan.Calisanlars.Remove(sil);
            baglan.SaveChanges();
            Listele();

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow satir = dataGridView1.CurrentRow;
            cadtxt.Tag = satir.Cells["calisanNo"].Value.ToString();
            cadtxt.Text = satir.Cells["calisanAd"].Value.ToString();
            hizmetcbx.Text = satir.Cells["verdigihizmet"].Value.ToString();
            ctipcbx.Text = satir.Cells["calismatipi"].Value.ToString();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (cadtxt.Text != null)
            {
                string cals = cadtxt.Text;

                dataGridView1.DataSource = baglan.Calisanlars.Where(x => x.calisanAd == cadtxt.Text).ToList();
            }

            

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (hizmetcbx.SelectedValue != null)
            {
                int hizm = Convert.ToInt32(hizmetcbx.SelectedValue);

                dataGridView1.DataSource = baglan.Calisanlars.Where(x => x.verdigiHizmet == hizm).ToList();

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (ctipcbx.SelectedText != null)
            {
                dataGridView1.DataSource = baglan.Calisanlars.Where(x => x.calismaTipi == ctipcbx.Text).ToList();
            }
        }
    }
}
