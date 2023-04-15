using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
//using static System.Windows.Forms.VisualStyles.VisualStyleElement.TextBox;

namespace AptManagerCompanyDBfirst
{
    public partial class IsEkrani : Form
    {
        public IsEkrani()
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
            dataGridView1.DataSource = baglan.Islers.ToList();
        }

        private void listb_Click(object sender, EventArgs e)
        {
            Listele();
        }

        private void IsEkrani_Load(object sender, EventArgs e)
        {
            
            aptcbx.DataSource = baglan.Apartmen.ToList();
            aptcbx.ValueMember = "aptNo";
            aptcbx.DisplayMember = "aptAd";

            hizmetcbx.DataSource = baglan.Hizmetlers.ToList();
            hizmetcbx.ValueMember = "hizmetNo";
            hizmetcbx.DisplayMember = "hizmetAdi";

            calisancbx.DataSource = baglan.Calisanlars.ToList();
            calisancbx.ValueMember = "calisanNo";
            calisancbx.DisplayMember = "calisanAd";
        }
        //public int faturaHesap(decimal huc/*int isno, decimal ucret, int gun*/)
        //{
        //    //int hno = 
        //    //decimal huc = baglan.Hizmetlers.Where(x=> x.hizmetNo =)
        //    var query = from h in baglan.Hizmetlers
        //                join iss in baglan.Islers on h.hizmetNo equals iss.hizmetNo
        //                //where iss.isNo == isno && h.hizmetUcret == ucret && iss.isGün == gun
        //                select new {h , iss/*faturaNo = h.hizmetUcret*iss.isGün*/ };

        //    if (query.Any())
        //    {
        //        int hno = baglan.Hizmetlers.Select(x=> x.hizmetNo = hizmetcbx.SelectedValue);
        //        var ucret = baglan.Hizmetlers.Where(x=> x.hizmetNo =hno).Select
        //        return Convert.ToInt32(ucret) * gun;
        //    }

        //    return Convert.ToInt32(ucret) * gun;

        //}

        private void addb_Click(object sender, EventArgs e)
        {
            Isler save = new Isler();
            string aptad = aptcbx.Text;
            var apt = baglan.Apartmen.Where(x=> x.AptAd == aptad).Select(x=> x.AptNo).FirstOrDefault();
            string had = hizmetcbx.Text;
            var hizm = baglan.Hizmetlers.Where(x => x.hizmetAdi == had).Select(x => x.hizmetNo).FirstOrDefault();
            string cad = calisancbx.Text;
            var clsn = baglan.Calisanlars.Where(x => x.calisanAd == cad).Select(x => x.calisanNo).FirstOrDefault();

           
            
            //int isn = Convert.ToInt32(aptcbx.Tag);
            //var total = baglan.Islers.Where(x=> x.isNo == isn).Select(x=> x.faturaToplam).FirstOrDefault(); 

                

            save.aptNo = apt;
            save.hizmetNo = hizm;
            save.calisanNo = clsn;
            save.isGün = Convert.ToInt32(suretxt.Text);
            save.baslangicT = Convert.ToDateTime(maskedTextBox1.Text);
            //save.isGün = Convert.ToInt32(dateTimePicker2.MinDate - dateTimePicker1.MinDate);
            save.bitisT = Convert.ToDateTime(maskedTextBox2.Text);

            //save.faturaToplam = faturaHesap(Convert.ToInt32(calisancbx.Tag), Convert.ToDecimal(ucret), gun);



            baglan.Islers.Add(save);
            baglan.SaveChanges();
            Listele();

        }

        private void updateb_Click(object sender, EventArgs e)
        {
            string aptad = aptcbx.Text;
            var apt = baglan.Apartmen.Where(x => x.AptAd == aptad).Select(x => x.AptNo).FirstOrDefault();
            string had = hizmetcbx.Text;
            var hizm = baglan.Hizmetlers.Where(x => x.hizmetAdi == had).Select(x => x.hizmetNo).FirstOrDefault();
            string cad = calisancbx.Text;
            var clsn = baglan.Calisanlars.Where(x => x.calisanAd == cad).Select(x => x.calisanNo).FirstOrDefault();

            int isno = Convert.ToInt32(calisancbx.Tag);
            var yenile = baglan.Islers.Where(x => x.isNo == isno).FirstOrDefault();

            yenile.aptNo = apt;
            yenile.hizmetNo = hizm;
            yenile.calisanNo = clsn;
            yenile.isGün = Convert.ToInt32(suretxt.Text);
            yenile.baslangicT = Convert.ToDateTime(maskedTextBox1.Text);
            //yenile.isGün = Convert.ToInt32(dateTimePicker2.MinDate - dateTimePicker1.MinDate);
            yenile.bitisT = Convert.ToDateTime(maskedTextBox2.Text);

            baglan.SaveChanges();
            Listele();

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow satir = dataGridView1.CurrentRow;
            calisancbx.Tag = satir.Cells["isNo"].Value.ToString();
            aptcbx.SelectedItem = satir.Cells["aptNo"].Value.ToString();
            hizmetcbx.SelectedItem = satir.Cells["hizmetNo"].Value.ToString();
            calisancbx.SelectedItem = satir.Cells["calisanNo"].Value.ToString();
            //maskedTextBox1.Text = satir.Cells["baslangicT"].Value.ToString();
            suretxt.Text = satir.Cells["isGün"].Value.ToString();
            //maskedTextBox2.Text = satir.Cells["bitisT"].Value.ToString();



        }

        private void deleteb_Click(object sender, EventArgs e)
        {
            int isno = Convert.ToInt32(calisancbx.Tag);
            var sil = baglan.Islers.Where(x => x.isNo == isno).FirstOrDefault();
            baglan.Islers.Remove(sil);
            baglan.SaveChanges();
            Listele();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Apt apt = new Apt();
            apt.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Hizmet hizmet = new Hizmet();
            hizmet.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Calisan calisan = new Calisan();
            calisan.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {

            if (aptcbx.SelectedValue != null)
            {
                int apt = Convert.ToInt32(aptcbx.SelectedValue);

                dataGridView1.DataSource = baglan.Islers.Where(x => x.aptNo == apt).ToList();
            }
           
       
        }

        private void button6_Click(object sender, EventArgs e)
        {
             if (hizmetcbx.SelectedValue != null)
             {
                int hizm = Convert.ToInt32(hizmetcbx.SelectedValue);

                dataGridView1.DataSource = baglan.Islers.Where(x => x.hizmetNo == hizm).ToList();
             }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (calisancbx.SelectedValue != null)
            {
                int cals = Convert.ToInt32(calisancbx.SelectedValue);

                dataGridView1.DataSource = baglan.Islers.Where(x => x.calisanNo == cals).ToList();
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (maskedTextBox1.Text != null)
            {
                var bt = Convert.ToDateTime(maskedTextBox1.Text);
                dataGridView1.DataSource = baglan.Islers.Where(x => x.baslangicT == bt).ToList();
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            if (suretxt.Text != null)
            {
                int sure = Convert.ToInt32(suretxt.Text);
                dataGridView1.DataSource = baglan.Islers.Where(x => x.isGün == sure).ToList();
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            if (maskedTextBox2.Text != null)
            {
                var bt = Convert.ToDateTime(maskedTextBox2.Text);
                dataGridView1.DataSource = baglan.Islers.Where(x => x.bitisT == bt).ToList();
            }
        }
    }
}
