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
    public partial class DersListele : Form
    {
        public DersListele()
        {
            InitializeComponent();
        }
        Ders secilenDers;
        DersRepository repo = new DersRepository();
        private void DersListele_Load(object sender, EventArgs e)
        {
            VeriDoldur(null);
        }

        private void VeriDoldur(Expression<Func<Ders, bool>> expFunc)
        {
            lstDers.Items.Clear();
            List<Ders> dersler = new List<Ders>();
            if (expFunc == null)
            {
                dersler = repo.GetAll();
            }
            else
            {
                dersler = repo.Get(expFunc).ToList();
            }

            foreach (Ders ders in dersler)
            {
                ListViewItem li = new ListViewItem(ders.Adi);
                li.SubItems.Add(ders.Aciklama);
                //li.SubItems.Add(ders.Aktif.ToString());
                li.SubItems.Add(ders.Saat.ToString());
                li.Tag = ders;
                lstDers.Items.Add(li);
            }
        }

        private void btnFiltrele_Click(object sender, EventArgs e)
        {
            Expression<Func<Ders, bool>> fitne = null;
            if (txtAdi.Text.Length > 0)
            {
                fitne = z => z.Adi.Contains(txtAdi.Text);
            }
            if (txtSaat.Text.Length > 0)
            {
                fitne = z => z.Saat.ToString().Contains(txtSaat.Text);
            }
          
            VeriDoldur(fitne);
        }

        private void silToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (secilenDers != null)
            {
                DialogResult dialog = MessageBox.Show("Silicem Emin misin ?",
                       "Son Silici",
                       MessageBoxButtons.OKCancel,
                       MessageBoxIcon.Warning,
                       MessageBoxDefaultButton.Button2);

                if (dialog == DialogResult.OK)
                {
                    repo.Delete(secilenDers);
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
            DersKaydet kayit = new DersKaydet(secilenDers);
            kayit.ShowDialog();
        }

        private void lstDers_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstDers.SelectedItems.Count == 0) return;
            ListViewItem li = lstDers.SelectedItems[0];
            secilenDers = (Ders)li.Tag;
        }
    }
}
