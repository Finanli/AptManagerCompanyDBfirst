using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity.Core.Common.CommandTrees.ExpressionBuilder;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;

namespace AptManagerCompanyDBfirst
{
    public partial class Apt : Form
    {
        public Apt()
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
            dataGridView1.DataSource = baglan.Apartmen.ToList();
        }


        private void addb_Click(object sender, EventArgs e)
        {
            Apartman save = new Apartman();
            save.AptAd = aptadtxt.Text;
            save.daireS = Convert.ToInt32(dsayitxt.Text);
            save.katS = Convert.ToInt32(ksayitxt.Text);
            save.adres = adrestxt.Text;
            save.asansor = Convert.ToBoolean(checkedListBox1.GetItemCheckState(0));
            save.havuz = Convert.ToBoolean(checkedListBox1.GetItemCheckState(1));
            save.sporS = Convert.ToBoolean(checkedListBox1.GetItemCheckState(2));

            baglan.Apartmen.Add(save);
            baglan.SaveChanges();
            Listele();
        }
        

        private void listb_Click(object sender, EventArgs e)
        {
            Listele();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow satir = dataGridView1.CurrentRow;
            aptadtxt.Tag = satir.Cells["AptNo"].Value.ToString();
            aptadtxt.Text = satir.Cells["AptAd"].Value.ToString();
            dsayitxt.Text = satir.Cells["DaireS"].Value.ToString();
            ksayitxt.Text = satir.Cells["KatS"].Value.ToString();
            adrestxt.Text = satir.Cells["Adres"].Value.ToString();
            //if (checkedListBox1.CheckOnClick= satir.Cells["Asansör"].Value == true)
            //{
            //    checkedListBox1.SetItemCheckState(0) == true;
            //}
            //if (satir.Cells["Asansör"].checked == true;)
            //{
            //    checkedListBox1.SetItemCheckState(0) == CheckState.Checked;

            //}
            //else if (checkedListBox1.GetItemCheckState(1) == CheckState.Checked)
            //{
            //    Apartman save = new Apartman();
            //    save.havuz = true;

            //    baglan.Apartmen.Add(save);
            //    baglan.SaveChanges();
            //}
            //else if (checkedListBox1.GetItemCheckState(1) == CheckState.Checked)
            //{
            //    Apartman save = new Apartman();
            //    save.sporS = true;

            //    baglan.Apartmen.Add(save);
            //    baglan.SaveChanges();
            //}
            //DataGridViewCheckBoxCell chk = new DataGridViewCheckBoxColumn() ;
            ////checkedListBox1.SetItemChecked["Asansör"].
            //checkedListBox1.CheckOnClick = chk.["Havuz"].Displayed;
            //checkedListBox1.CheckOnClick = chk.Cells["SporS"].Displayed;
        }

        
        private void updateb_Click(object sender, EventArgs e)
        {
            int aptno = Convert.ToInt32(aptadtxt.Tag);
            
            var yenile = baglan.Apartmen.Where(x=> x.AptNo == aptno).FirstOrDefault();

            
            yenile.AptAd = aptadtxt.Text;
            yenile.daireS = Convert.ToInt32(dsayitxt.Text);
            yenile.katS = Convert.ToInt32(ksayitxt.Text);
            yenile.adres = adrestxt.Text;
            yenile.asansor = Convert.ToBoolean(checkedListBox1.GetItemCheckState(0));
            yenile.havuz = Convert.ToBoolean(checkedListBox1.GetItemCheckState(1));
            yenile.sporS = Convert.ToBoolean(checkedListBox1.GetItemCheckState(2));

            baglan.Apartmen.Add(yenile);
            baglan.SaveChanges();
            Listele();
        }

        private void deleteb_Click(object sender, EventArgs e)
        {
            int aptno = Convert.ToInt32(aptadtxt.Tag);
            var sil = baglan.Apartmen.Where(x => x.AptNo == aptno).FirstOrDefault();

            baglan.Apartmen.Remove(sil);
            baglan.SaveChanges();
            Listele();
        }

        private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            //if (checkedListBox1.GetItemCheckState(0) == CheckState.Checked) 
            //{
            //    Apartman save = new Apartman();
            //    save.asansor = true;

            //    baglan.Apartmen.Add(save);
            //    baglan.SaveChanges();

            //}
            //else if (checkedListBox1.GetItemCheckState(1) == CheckState.Checked)
            //{
            //    Apartman save = new Apartman();
            //    save.havuz = true;

            //    baglan.Apartmen.Add(save);
            //    baglan.SaveChanges();
            //}
            //else if (checkedListBox1.GetItemCheckState(1) == CheckState.Checked)
            //{
            //    Apartman save = new Apartman();
            //    save.sporS = true;

            //    baglan.Apartmen.Add(save);
            //    baglan.SaveChanges();
            //}
        }

        private void yonetb_Click(object sender, EventArgs e)
        {
            
            Yoneticiler yoneticiler = new Yoneticiler();
            yoneticiler.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (aptadtxt.Text != null)
            {
                string apta = aptadtxt.Text;

                dataGridView1.DataSource = baglan.Apartmen.Where(x => x.AptAd == apta).ToList();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (dsayitxt.Text != null)
            {
                int dsayi = Convert.ToInt32(dsayitxt.Text);

                dataGridView1.DataSource = baglan.Apartmen.Where(x => x.daireS == dsayi).ToList();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (ksayitxt.Text != null)
            {
                int ksayi = Convert.ToInt32(ksayitxt.Text);

                dataGridView1.DataSource = baglan.Apartmen.Where(x => x.katS == ksayi).ToList();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (adrestxt.Text != null)
            {
                string adres = adrestxt.Text;

                dataGridView1.DataSource = baglan.Apartmen.Where(x => x.adres == adres).ToList();
            }
        }
    }
}
