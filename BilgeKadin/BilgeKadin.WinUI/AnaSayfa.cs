using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BilgeKadin.WinUI
{
    public partial class AnaSayfa : Form
    {
        public AnaSayfa()
        {
            InitializeComponent();
        }

        private void btnYeniOgrenci_Click(object sender, EventArgs e)
        {
            OgrenciKayit ogrKayit = new OgrenciKayit();
            ogrKayit.ShowDialog();
        }

        private void kayitliOgrenci_Click(object sender, EventArgs e)
        {
            OgrenciListesi ogrList = new OgrenciListesi();
            ogrList.ShowDialog();
        }

        private void seansTanımlaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SenasIslemleri seansTanimlama = new SenasIslemleri();
            seansTanimlama.ShowDialog();
        }

        private void seansListesiToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void öğretmenTanımlaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OgretmenKayit ogretmenkaydet = new OgretmenKayit();
            ogretmenkaydet.ShowDialog();
        }

        private void öğretmenListesiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OgretmenListele listele = new OgretmenListele();
            listele.ShowDialog();
        }

        private void sınıfTanımlaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SinifKaydet sk = new SinifKaydet();
            sk.ShowDialog();
        }

        private void sınıfListesiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SinifListele sl = new SinifListele();
            sl.ShowDialog();

        }

        private void dersListesiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DersListele liste = new DersListele();
            liste.ShowDialog();
        }

        private void dersEkleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DersKaydet kaydet = new DersKaydet();
            kaydet.ShowDialog();
        }
    }
}
