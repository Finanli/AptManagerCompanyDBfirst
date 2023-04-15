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
    public partial class Hizmet : Form
    {
        public Hizmet()
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
            dataGridView1.DataSource = baglan.Hizmetlers.ToList();
        }

        private void listb_Click(object sender, EventArgs e)
        {
            Listele();
        }

        private void addb_Click(object sender, EventArgs e)
        {
            Hizmetler save = new Hizmetler();

            save.hizmetAdi = hadtxt.Text;
            save.hizmetUcret = Convert.ToDecimal(hucrettxt.Text);

            baglan.Hizmetlers.Add(save);
            baglan.SaveChanges();
            Listele();

        }

        private void updateb_Click(object sender, EventArgs e)
        {
            int hno = Convert.ToInt32(hucrettxt.Tag);
            var yenile = baglan.Hizmetlers.Where(x=> x.hizmetNo == hno).FirstOrDefault();

            yenile.hizmetAdi = hadtxt.Text;
            yenile.hizmetUcret = Convert.ToDecimal(hucrettxt.Text);

            baglan.SaveChanges();
            Listele();
        }

        private void deleteb_Click(object sender, EventArgs e)
        {
            int hno = Convert.ToInt32(hucrettxt.Tag);
            var sil = baglan.Hizmetlers.Where(x => x.hizmetNo == hno).FirstOrDefault();

            baglan.Hizmetlers.Remove(sil);
            baglan.SaveChanges();
            Listele();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow satir = new DataGridViewRow();
            hadtxt.Text = satir.Cells["hizmetAdi"].Value.ToString();
            hucrettxt.Text = satir.Cells["hizmetucret"].Value.ToString();

        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (hadtxt.Text != null)
            {
                string hizm = hadtxt.Text;

                dataGridView1.DataSource = baglan.Hizmetlers.Where(x => x.hizmetAdi == hizm).ToList();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (hucrettxt.Text != null)
            {
                int hucr = Convert.ToInt32(hucrettxt.Text);

                dataGridView1.DataSource = baglan.Hizmetlers.Where(x => x.hizmetUcret == hucr).ToList();
            }
        }
    }
}
