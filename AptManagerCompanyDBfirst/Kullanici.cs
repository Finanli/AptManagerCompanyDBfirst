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
    public partial class Kullanici : Form
    {
        public Kullanici()
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
            dataGridView1.DataSource = baglan.Kullanicilars.ToList();
        }

        private void listb_Click(object sender, EventArgs e)
        {
            Listele();
        }

        private void addb_Click(object sender, EventArgs e)
        {
            Kullanicilar save = new Kullanicilar();

            save.kullaniciAdi = kadtxt.Text;
            save.sifre = sifretxt.Text;

            baglan.Kullanicilars.Add(save);
            baglan.SaveChanges();
            Listele();

        }

        private void updateb_Click(object sender, EventArgs e)
        {
            int kno = Convert.ToInt32(kadtxt.Tag);
            var yenile = baglan.Kullanicilars.Where(x=> x.kullaniciNo == kno).FirstOrDefault();

            yenile.kullaniciAdi = kadtxt.Text;
            yenile.sifre = sifretxt.Text;

            baglan.SaveChanges();
            Listele();
        }

        private void deleteb_Click(object sender, EventArgs e)
        {
            int kno = Convert.ToInt32(kadtxt.Tag);
            var sil = baglan.Kullanicilars.Where(x => x.kullaniciNo == kno).FirstOrDefault();

            baglan.SaveChanges();
            Listele();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (kadtxt.Text != null)
            {
                string kad = kadtxt.Text;

                dataGridView1.DataSource = baglan.Kullanicilars.Where(x => x.kullaniciAdi == kad).ToList();
            }
        }
    }
}
