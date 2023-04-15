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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        AptManagerCompanyEntities baglan = new AptManagerCompanyEntities();


        public bool GirisYap(string ad, string sifre)
        {
            var query = from k in baglan.Kullanicilars
                        where k.kullaniciAdi == ad && k.sifre == sifre
                        select k;
            if (query.Any())
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        private void enterb_Click(object sender, EventArgs e)
        {

            if (GirisYap(unametxt.Text, pswtxt.Text)== true)
            {
                MessageBox.Show("Giriş Başarılı!");
                Anasayfa asayfa = new Anasayfa();
                this.Hide();
                asayfa.Show();
            }
            else
            {
                MessageBox.Show("Giriş Başarısız!");
                unametxt.Clear();
                pswtxt.Clear();
            }


            
        }
    }
}
