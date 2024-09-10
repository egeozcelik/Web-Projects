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
    public partial class OgretmenListele : Form
    {
        public OgretmenListele()
        {
            InitializeComponent();
        }
        Ogretmen secilenOgretmen;
        OgretmenRepository repo = new OgretmenRepository();

        private void OgretmenListele_Load(object sender, EventArgs e)
        {
            VeriDoldur(null);
        }

        private void VeriDoldur(Expression<Func<Ogretmen, bool>> expFunc)
        {
            lstOgretmen.Items.Clear();
            List<Ogretmen> ogretmenler = new List<Ogretmen>();
            if (expFunc == null)
            {
                ogretmenler=repo.GetAll();

            }
            else
            {
                ogretmenler = repo.Get(expFunc).ToList();

            }
            foreach (Ogretmen ogretmen in ogretmenler)
            {
                ListViewItem li = new ListViewItem(ogretmen.Adi);
                li.SubItems.Add(ogretmen.Soyadi);
                li.SubItems.Add(ogretmen.Mail);
                li.Tag = ogretmen;
                lstOgretmen.Items.Add(li);


            }
        }

        private void btnFiltrele_Click(object sender, EventArgs e)
        {
            Expression<Func<Ogretmen, bool>> fitne = null;
            if (txtAdi.Text.Length > 0)
            {
                fitne = z => z.Adi.Contains(txtAdi.Text);
            }
            if (txtMail.Text.Length > 0)
            {
                fitne = z => z.Mail.Contains(txtMail.Text);
            }
         
            VeriDoldur(fitne);
        }

        private void lstOgretmen_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstOgretmen.SelectedItems.Count == 0) return;
            ListViewItem li = lstOgretmen.SelectedItems[0];
            secilenOgretmen = (Ogretmen)li.Tag;
        }

        private void silToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (secilenOgretmen != null)
            {
                DialogResult dialog = MessageBox.Show("Silicem Emin misin ?",
                       "Son Silici",
                       MessageBoxButtons.OKCancel,
                       MessageBoxIcon.Warning,
                       MessageBoxDefaultButton.Button2);

                if (dialog == DialogResult.OK)
                {
                    repo.Delete(secilenOgretmen);
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

        private void güncelleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OgretmenKayit yenikayit = new OgretmenKayit(secilenOgretmen);
            yenikayit.ShowDialog();
        }
    }
}
