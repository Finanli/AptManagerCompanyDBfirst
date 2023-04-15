using Microsoft.Win32.SafeHandles;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AptManagerCompanyDBfirst
{
    public partial class RaporEkranı : Form
    {
        public RaporEkranı()
        {
            InitializeComponent();
        }

        AptManagerCompanyEntities baglan = new AptManagerCompanyEntities();

        private void button1_Click(object sender, EventArgs e)
        {
            var query = from cls in baglan.Calisanlars
                        join hzm in baglan.Hizmetlers on cls.verdigiHizmet equals hzm.hizmetNo
                        select new { 
                        cls.calisanAd,
                        hzm.hizmetAdi
                        };

            dataGridView1.DataSource = query.ToList();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var query = from apt in baglan.Apartmen
                        join isl in baglan.Islers on apt.AptNo equals isl.aptNo
                        join hzm in baglan.Hizmetlers on isl.hizmetNo equals hzm.hizmetNo
                        group new
                        {
                            apt,
                            hzm
                        } by new
                        {
                            apt.AptAd,
                            hzm.hizmetAdi
                        } into apthizm

                        select new
                        {
                            AptAdi =apthizm.Key.AptAd,
                            HizmetAd = apthizm.Key.hizmetAdi,
                            HizmetSayi = apthizm.Count()
                            //AptAd = Apt.Key,
                            //HizmetAD = Apt.
                            //isl.isGün

                        };

            dataGridView1.DataSource = query.ToList() ;

        }

        private void button3_Click(object sender, EventArgs e)
        {
            var query = from isl in baglan.Islers
                        join apt in baglan.Apartmen on isl.aptNo equals apt.AptNo
                        join hzm in baglan.Hizmetlers on isl.hizmetNo equals hzm.hizmetNo
                      
                        select new
                        {
                           apt.AptAd,
                           hzm.hizmetAdi,
                           hzm.hizmetUcret,
                           isl.isGün,
                           FaturaToplam = isl.isGün*hzm.hizmetUcret
                        };
            dataGridView1.DataSource = query.ToList() ;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            var query = from isl in baglan.Islers
                        join hzm in baglan.Hizmetlers on isl.hizmetNo equals hzm.hizmetNo
                        group new
                        { isl, hzm } 
                        by new { isl.baslangicT.Value.Year,
                                 hzm.hizmetAdi }
                        into yilagore

                        select new
                        {
                            Yıl = yilagore.Key.Year,
                            HizmetAd = yilagore.Key.hizmetAdi,
                            HizmetSayi = yilagore.Count()
                        };

            dataGridView1.DataSource = query.ToList();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            var query = from isl in baglan.Islers
                        join hzm in baglan.Hizmetlers on isl.hizmetNo equals hzm.hizmetNo
                        group isl by isl.baslangicT.Value.Year into yilagore
                        select new
                        {
                            Yil = yilagore.Key,
                            Gelir = yilagore.Sum(x => x.isGün * x.Hizmetler.hizmetUcret)
                        };
            dataGridView1.DataSource = query.ToList();
        }
    }
}
