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
    public partial class OgretmenKayit : Form
    {
        Ogretmen gelenogretmen;
        OgretmenRepository or = new OgretmenRepository();
        public OgretmenKayit(Ogretmen _ogretmen)
        {
            gelenogretmen = _ogretmen;
            InitializeComponent();

        }
        public OgretmenKayit()
        {
            InitializeComponent();
        }
        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
        bool alanKontrol()
        {
            if (string.IsNullOrEmpty(txtAdi.Text) ||
                string.IsNullOrEmpty(txtMail.Text) ||
                string.IsNullOrEmpty(txtSoyadi.Text))


            {
                return false;
            }
            else
                return true;
        }
      private void OgretmenKayit_Load(object sender, EventArgs e)
        {
            if (gelenogretmen != null)
            {
                txtAdi.Text = gelenogretmen.Adi;
                txtMail.Text = gelenogretmen.Mail;
                txtSoyadi.Text = gelenogretmen.Soyadi;

                if (gelenogretmen.DogumTarihi != null)
                {
                    dtTarih.Value = gelenogretmen.DogumTarihi.Value;
                }
                if (gelenogretmen.Cinsiyet)
                {
                    rdERkek.Checked = true;
                }
                else
                {
                    rdDisi.Checked = true;
                }
            }
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            if (alanKontrol())
            {
                if (gelenogretmen == null)
                {
                    Ogretmen o = new Ogretmen();
                    o.Adi = txtAdi.Text;
                    o.Soyadi = txtSoyadi.Text;
                    o.Mail = txtMail.Text;
                    o.DogumTarihi = dtTarih.Value;
                    o.Cinsiyet = rdDisi.Checked ? false : true;
                    or.Add(o);
                    MessageBox.Show("Kayıt Başarılı");
                }
                else
                {
                    gelenogretmen.Adi = txtAdi.Text;
                    gelenogretmen.Soyadi = txtSoyadi.Text;
                    gelenogretmen.Mail = txtMail.Text;
                    gelenogretmen.DogumTarihi = dtTarih.Value;
                    gelenogretmen.Cinsiyet = rdDisi.Checked ? false : true;
                    or.Update(gelenogretmen);
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
            OgretmenListele liste = new OgretmenListele();
            liste.ShowDialog();

        }
    }
}
