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
    public partial class SinifListele : Form
    {
        public SinifListele()
        {
            InitializeComponent();
        }
        SinifRepository sr = new SinifRepository();
        Sinif secilenSinif;
       // private void silToolStripMenuItem_Click(object sender, EventArgs e)
       // {
       //     if (secilenSinif != null)
       //     {
       //         DialogResult dialog = MessageBox.Show("Silicem Emin misin ?",
       //                "Son Silici",
       //                MessageBoxButtons.OKCancel,
       //                MessageBoxIcon.Warning,
       //                MessageBoxDefaultButton.Button2);
       //
       //         if (dialog == DialogResult.OK)
       //         {
       //             sr.Delete(secilenSinif);
       //             VeriDoldur(null);
       //         }
       //         else
       //         {
       //             MessageBox.Show("Son Silici Durdu");
       //         }
       //     }
       //     else
       //     {
       //         MessageBox.Show("Silinecek Öğrenciyi Seçin");
       //     }
       // }

        private void SinifListele_Load(object sender, EventArgs e)
        {
            VeriDoldur(null);
        }

        private void VeriDoldur(Expression<Func<Sinif, bool>> expFunc)
        {
             
            lstSinif.Items.Clear();

            List<Sinif> siniflar = new List<Sinif>();
            if (expFunc == null)
            {
                siniflar = sr.GetAll();
            }
            else
            {
                siniflar = sr.Get(expFunc).ToList();
}

            foreach (Sinif   sınıf in siniflar)
            {
                ListViewItem li = new ListViewItem(sınıf.Adi);
                    li.SubItems.Add(sınıf.Kontenjan.ToString());
                
                li.Tag =sınıf;
                lstSinif.Items.Add(li);
            }
        }

        private void btnFiltrele_Click(object sender, EventArgs e)
        {
            Expression<Func<Sinif, bool>> fitne = null;
            if (txtAdi.Text.Length > 0)
            {
                fitne = z => z.Adi.Contains(txtAdi.Text);
            }
            if (txtTelefon.Text.Length > 0)
            {
                fitne = z => z.Kontenjan.ToString().Contains(txtTelefon.Text);
            }
           
            VeriDoldur(fitne);
        }

      //  private void güncelleToolStripMenuItem_Click(object sender, EventArgs e)
      //  {
      //      SinifKaydet kayitAc = new SinifKaydet(secilenSinif);
      //      kayitAc.ShowDialog();
      //  }

        private void lstSinif_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstSinif.SelectedItems.Count == 0) return;
            ListViewItem li = lstSinif.SelectedItems[0];
            secilenSinif = (Sinif)li.Tag;
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void silToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            if (secilenSinif != null)
            {
                DialogResult dialog = MessageBox.Show("Silicem Emin misin ?",
                       "Son Silici",
                       MessageBoxButtons.OKCancel,
                       MessageBoxIcon.Warning,
                       MessageBoxDefaultButton.Button2);

                if (dialog == DialogResult.OK)
                {
                    sr.Delete(secilenSinif);
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

        private void güncelleToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            SinifKaydet kayitAc = new SinifKaydet(secilenSinif);
            kayitAc.ShowDialog();
        }
    }
}
