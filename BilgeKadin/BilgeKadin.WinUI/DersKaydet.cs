using BilgeKadin.BLL;
using BilgeKadin.Entity;
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
    public partial class DersKaydet : Form
    {
        public DersKaydet(Ders _ders)
        {
            gelenDers = _ders;
            InitializeComponent();
        }
        Ders gelenDers;
        DersRepository repo = new DersRepository();
        public DersKaydet()
        {
            InitializeComponent();
            AlanKontrol();
        }

        private bool AlanKontrol()
        {
            if (string.IsNullOrEmpty(txtAdi.Text)||
                string.IsNullOrEmpty(txtSaat.Text)||
                string.IsNullOrEmpty(rchAcıklama.Text))
            {
                return false;

            }
            return true;
        }

        private void DersKaydet_Load(object sender, EventArgs e)
        {
            if (gelenDers != null)
            {
                txtAdi.Text = gelenDers.Adi;
                txtSaat.Text = gelenDers.Saat.ToString();
                rchAcıklama.Text = gelenDers.Aciklama;
            }
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            if (AlanKontrol())
            {

                if (gelenDers == null)
                {
                    Ders ders = new Ders();
                    ders.Adi = txtAdi.Text;
                    ders.Saat = Convert.ToInt32(txtSaat.Text);
                    ders.Aciklama = rchAcıklama.Text;
                    repo.Add(ders);
                    MessageBox.Show("kayit başarılı");
                }
                else
                {
                    gelenDers.Adi = txtAdi.Text;
                    gelenDers.Saat = Convert.ToInt32(txtSaat.Text);
                    gelenDers.Aciklama = rchAcıklama.Text;
                    repo.Update(gelenDers);
                    MessageBox.Show("Güncelleme Başarılı");
                } 
            }
            else
            {
                MessageBox.Show("Bütün Alanları Doldurun");
            }

        }

        private void btnListele_Click(object sender, EventArgs e)
        {
            DersListele listele = new DersListele();
            listele.ShowDialog();

        }
    }
}
