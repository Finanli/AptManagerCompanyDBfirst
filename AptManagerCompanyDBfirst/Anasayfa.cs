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
    public partial class Anasayfa : Form
    {
        public Anasayfa()
        {
            InitializeComponent();
            
            
        }

        

        private void apartmanb_Click(object sender, EventArgs e)
        {
            scpanel.Controls.Clear();
            Apt apartman = new Apt();
            apartman.TopLevel = false;
            scpanel.Controls.Add(apartman);
            apartman.Show();
            apartman.Dock = DockStyle.Fill;
            apartman.BringToFront();
           

            
            
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void hizmetb_Click(object sender, EventArgs e)
        {
            scpanel.Controls.Clear();
            Hizmet hizmet = new Hizmet();
            hizmet.TopLevel = false;
            scpanel.Controls.Add(hizmet);
            hizmet.Show();
            hizmet.Dock = DockStyle.Fill;
            hizmet.BringToFront();
        }

        private void calisanb_Click(object sender, EventArgs e)
        {
            scpanel.Controls.Clear();
            Calisan cls = new Calisan();
            cls.TopLevel = false;
            scpanel.Controls.Add(cls);
            cls.Show();
            cls.Dock = DockStyle.Fill;
            cls.BringToFront();
        }

        private void kullanicib_Click(object sender, EventArgs e)
        {
            scpanel.Controls.Clear();
            Kullanici kln = new Kullanici();
            kln.TopLevel = false;
            scpanel.Controls.Add(kln);
            kln.Show();
            kln.Dock = DockStyle.Fill;
            kln.BringToFront();
        }

        private void islerb_Click(object sender, EventArgs e)
        {
            scpanel.Controls.Clear();
            IsEkrani ise = new IsEkrani();
            ise.TopLevel = false;
            scpanel.Controls.Add(ise);
            ise.Show();
            ise.Dock = DockStyle.Fill;
            ise.BringToFront();
        }

        private void raporb_Click(object sender, EventArgs e)
        {
            scpanel.Controls.Clear();
            RaporEkranı rpe = new RaporEkranı();
            rpe.TopLevel = false;
            scpanel.Controls.Add(rpe);
            rpe.Show();
            rpe.Dock = DockStyle.Fill;
            rpe.BringToFront();
        }
    }
}
