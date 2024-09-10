using BilgeKadin.BLL;
using BilgeKadin.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BilgeKadin.WinUI
{
    public partial class OgrenciListesi : Form
    {
        public OgrenciListesi()
        {
            InitializeComponent();
        }

        Ogrenci secilenOgrenci;

        OgrenciRepository repo = new OgrenciRepository();
        private void OgrenciListesi_Load(object sender, EventArgs e)
        {
            VeriDoldur(null);
        }
        private void btnFiltrele_Click(object sender, EventArgs e)
        {
            Expression<Func<Ogrenci, bool>> fitne = null;
            if (txtAdi.Text.Length > 0)
            {
                fitne = z => z.Adi.Contains(txtAdi.Text);
            }
            if (txtMail.Text.Length > 0)
            {
                fitne = z => z.Mail.Contains(txtMail.Text);
            }
            if (txtTelefon.Text.Length > 0)
            {
                fitne = z => z.Telefon.Contains(txtTelefon.Text);
            }
            VeriDoldur(fitne);
        }

        private void VeriDoldur(Expression<Func<Ogrenci, bool>> expFunc)
        {
            lstOgrenci.Items.Clear();
            List<Ogrenci> ogrenciler = new List<Ogrenci>();
            if (expFunc == null)
            {
                ogrenciler = repo.GetAll();
            }
            else
            {
                ogrenciler = repo.Get(expFunc).ToList();
            }

            foreach (Ogrenci ogrenci in ogrenciler)
            {
                ListViewItem li = new ListViewItem(ogrenci.Adi);
                li.SubItems.Add(ogrenci.Soyadi);
                li.SubItems.Add(ogrenci.Telefon);
                li.SubItems.Add(ogrenci.Mail);
                li.Tag = ogrenci;
                lstOgrenci.Items.Add(li);
            }
        }

        private void silToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (secilenOgrenci != null)
            {
                DialogResult dialog = MessageBox.Show("Silicem Emin misin ?",
                       "Son Silici",
                       MessageBoxButtons.OKCancel,
                       MessageBoxIcon.Warning,
                       MessageBoxDefaultButton.Button2);

                if (dialog == DialogResult.OK)
                {
                    repo.Delete(secilenOgrenci);
                    VeriDoldur(null);
                }
                else
                {
                    MessageBox.Show("Son Silici Durdu");
                }
            }
            else
            {
                MessageBox.Show("Silinecek Öğrenciyi Seçin");
            }
        }

        private void guncelle_Click(object sender, EventArgs e)
        {
            OgrenciKayit kayitAc = new OgrenciKayit(secilenOgrenci);
            kayitAc.ShowDialog();
        }

        private void lstOgrenci_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstOgrenci.SelectedItems.Count == 0) return;
            ListViewItem li = lstOgrenci.SelectedItems[0];
            secilenOgrenci = (Ogrenci)li.Tag;

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
