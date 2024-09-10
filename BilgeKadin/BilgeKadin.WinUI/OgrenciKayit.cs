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
    public partial class OgrenciKayit : Form
    {
        Ogrenci gelenOgrenci;
        OgrenciRepository repo = new OgrenciRepository();
        public OgrenciKayit()
        {
            InitializeComponent();
        }
        public OgrenciKayit(Ogrenci _ogrenci)
        {
            gelenOgrenci = _ogrenci;
            InitializeComponent();
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            if (AlanKontrol())
            {
                if (gelenOgrenci == null)
                {
                    Ogrenci ogr = new Ogrenci();
                    ogr.Adi = txtAdi.Text;
                    ogr.Soyadi = txtSoyadi.Text;
                    ogr.Mail = txtMail.Text;
                    ogr.Telefon = txtTelefon.Text;
                    ogr.DogumTarihi = dtTarih.Value;
                    ogr.Cinsiyet = rdDisi.Checked ? false : true;
                    repo.Add(ogr);
                    MessageBox.Show("Kayıt Başarılı");
                }
                else
                {
                    gelenOgrenci.Adi = txtAdi.Text;
                    gelenOgrenci.Soyadi = txtSoyadi.Text;
                    gelenOgrenci.Mail = txtMail.Text;
                    gelenOgrenci.Telefon = txtTelefon.Text;
                    gelenOgrenci.DogumTarihi = dtTarih.Value;
                    gelenOgrenci.Cinsiyet = rdDisi.Checked ? false : true;
                    repo.Update(gelenOgrenci);
                    MessageBox.Show("Güncelleme Başarılı");
                }

            }
            else
            {
                MessageBox.Show("Alanları Kontrol Edin");
            }
        }

        bool AlanKontrol()
        {
            if (String.IsNullOrEmpty(txtAdi.Text) ||
                String.IsNullOrEmpty(txtMail.Text) ||
                String.IsNullOrEmpty(txtSoyadi.Text) ||
                String.IsNullOrEmpty(txtTelefon.Text)
                )
            {
                return false;
            }
            return true;
        }

        private void btnListele_Click(object sender, EventArgs e)
        {
            OgrenciListesi liste = new OgrenciListesi();
            liste.ShowDialog();
        }

        private void OgrenciKayit_Load(object sender, EventArgs e)
        {
            if (gelenOgrenci != null)
            {
                txtAdi.Text = gelenOgrenci.Adi;
                txtMail.Text = gelenOgrenci.Mail;
                txtSoyadi.Text = gelenOgrenci.Soyadi;
                txtTelefon.Text = gelenOgrenci.Telefon;
                if (gelenOgrenci.DogumTarihi != null)
                {
                    dtTarih.Value = gelenOgrenci.DogumTarihi.Value;
                }
                if (gelenOgrenci.Cinsiyet)
                {
                    rdERkek.Checked = true;
                }
                else
                {
                    rdDisi.Checked = true;
                }
            }
        }
    }
}
