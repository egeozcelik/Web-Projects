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
    public partial class SinifKaydet : Form
    {
        public SinifKaydet()
        {
            InitializeComponent();
        }
        public SinifKaydet(Sinif _sinif)
        {
            gelenSinif = _sinif;
            InitializeComponent();
        }
        Sinif gelenSinif;
        SinifRepository repo = new SinifRepository();

        private void SinifKaydet_Load(object sender, EventArgs e)
        {
            if (gelenSinif != null)
            {
                txtAdi.Text = gelenSinif.Adi;
                txtSoyadi.Text = gelenSinif.Kontenjan.ToString() ;
            }
                
                
               
        }
        bool AlanKontrol()
        {
            if (String.IsNullOrEmpty(txtAdi.Text) ||
                
                String.IsNullOrEmpty(txtSoyadi.Text) 
              
                )
            {
                return false;
            }
            return true;
        }
        private void btnKaydet_Click(object sender, EventArgs e)
        {
            if (AlanKontrol())
            {
                Sinif yeni = new Sinif();
                yeni.Adi = txtAdi.Text;
                yeni.Kontenjan = Convert.ToInt32(txtSoyadi.Text);
                repo.Add(yeni);
                MessageBox.Show("Kayit Başarılı");
            }
            else
            {
                gelenSinif.Adi = txtAdi.Text;
                gelenSinif.Kontenjan = Convert.ToInt32(txtSoyadi.Text);
                repo.Update(gelenSinif);
                MessageBox.Show("Güncelleme Başarılı");

            }
        }

        private void btnListele_Click(object sender, EventArgs e)
        {
            SinifListele liste = new SinifListele();
            liste.ShowDialog();
        }
    }
}
