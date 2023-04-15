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
    public partial class Yoneticiler : Form
    {
        public Yoneticiler()
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
            dataGridView1.DataSource = baglan.AptYoneticilers.ToList();

        }

        private void addb_Click(object sender, EventArgs e)
        {
            AptYoneticiler save = new AptYoneticiler();
            string aptad = aptcbx.Text;
            var item = baglan.Apartmen.Where(x => x.AptAd == aptad).Select(x => x.AptNo).FirstOrDefault();
            
            save.aptNo = item;
            save.yoneticiAd = yadtxt.Text;
            save.telefon = teltxt.Text;
            save.daireNo = Convert.ToInt32(dairetxt.Text);

            baglan.AptYoneticilers.Add(save);
            baglan.SaveChanges();
            Listele();
        }

        private void listb_Click(object sender, EventArgs e)
        {
            Listele();
        }

        private void Yoneticiler_Load(object sender, EventArgs e)
        {
            aptcbx.DataSource = baglan.Apartmen.ToList();
            aptcbx.ValueMember = "AptNo";
            aptcbx.DisplayMember = "AptAd";
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow satir = dataGridView1.CurrentRow;
            aptcbx.DisplayMember = satir.Cells["aptNo"].Value.ToString();
            yadtxt.Text = satir.Cells["yoneticiAd"].Value.ToString();
            teltxt.Text = satir.Cells["telefon"].Value.ToString();
            dairetxt.Text = satir.Cells["daireno"].Value.ToString();
        }

        private void updateb_Click(object sender, EventArgs e)
        {
            string aptad = aptcbx.Text;
            var item = baglan.Apartmen.Where(x => x.AptAd == aptad).Select(x => x.AptNo).FirstOrDefault();
            var yenile = baglan.AptYoneticilers.Where(x => x.aptNo == item).FirstOrDefault();
            
           

            yenile.aptNo = item;
            yenile.yoneticiAd = yadtxt.Text;
            yenile.telefon = teltxt.Text;
            yenile.daireNo = Convert.ToInt32(dairetxt.Text);

            
            baglan.SaveChanges();
            Listele();

        }

        private void deleteb_Click(object sender, EventArgs e)
        {
            string aptad = aptcbx.Text;
            var item = baglan.Apartmen.Where(x => x.AptAd == aptad).Select(x => x.AptNo).FirstOrDefault();
            var yenile = baglan.AptYoneticilers.Where(x => x.aptNo == item).FirstOrDefault();

            baglan.SaveChanges();
            Listele();
        }
    }
}
