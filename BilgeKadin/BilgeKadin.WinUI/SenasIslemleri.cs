using BilgeKadin.BLL;
using BilgeKadin.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace BilgeKadin.WinUI
{
    public partial class SenasIslemleri : Form
    {
        public SenasIslemleri()
        {
            InitializeComponent();
        }
        
        SinifDersRepository repo = new SinifDersRepository();
        DersRepository dersrepo = new DersRepository();
        SinifRepository sinifRepo = new SinifRepository();
        OgretmenRepository ogretmenRepo = new OgretmenRepository();
        OgrenciRepository ogrenciRepo = new OgrenciRepository();
        SeansRepository seansRepo = new SeansRepository();

        SinifDers secilenSinifDers;
        
        Ders secilenDers;
        Sinif secilenSinif;
        Ogretmen secilenOgretmen;
        Seans secilenSeans;
        List<Ogrenci> secilenOgrenciler = new List<Ogrenci>();
        //SinifDers sd = new SinifDers();
        SinifDers sd;
        private void button1_Click(object sender, EventArgs e)
        {
            sd = new SinifDers();
            if (güncelleme)
            {
                SinifDers güncellenecek = repo.GetAll().FirstOrDefault(z => z.Id == Convert.ToInt32(txtsdID.Text));
                güncellenecek.Ogretmen = secilenOgretmen;
                güncellenecek.Ders = secilenDers;
                güncellenecek.Seans = secilenSeans;
                güncellenecek.Sinif = secilenSinif;
                güncellenecek.Ogrencis = secilenOgrenciler;
                repo.Update(güncellenecek);
                VeriDoldur();
                MessageBox.Show("Seçtiğiniz Seans Güncellendi");

            }
            else
            {
                foreach (Ogrenci ogrenci in checkedListBox1.CheckedItems)
                {
                    secilenOgrenciler.Add(ogrenci);
                }

                if (secilenDers == null ||
                    secilenSinif == null ||
                    secilenOgretmen == null ||
                    secilenSeans == null || secilenOgrenciler.Count == 0)
                {
                    MessageBox.Show("Alanları Eksiksiz Doldurun");
                }
                else
                {
                    sd.Ders = secilenDers;
                    sd.Sinif = secilenSinif;
                    sd.Ogretmen = secilenOgretmen;
                    sd.Seans = secilenSeans;
                    sd.Ogrencis = secilenOgrenciler;


                    if (KontenjanKontrol(secilenSinif, secilenOgrenciler))
                    {
                        repo.Add(sd);
                        MessageBox.Show("Yeni Seans Eklendi");
                    } 
                }
           
                   VeriDoldur();
                
                
            }

            if (sd != null )
            {
                sd = new SinifDers();
                secilenOgrenciler = new List<Ogrenci>();

            }

            try
            {
                //this.Close();


                //SenasIslemleri s = new SenasIslemleri();
                //s.OnShown();
                //TODO : Ege 15 kontenjan Kontrol
                //Seçilen sınıfın kontenjan miktarını alır
                //int sinifKontenjan = sinifRepo.Get(z => z.Id == secilenSinif.Id)
                //            .FirstOrDefault().Kontenjan;

                //ogrenci sayısı checkbox dan seçilen ögrencilerdir

                //if (sinifKontenjan > secilenOgrenciler)
                //{
                //    MessageBox.Show("Kontenjan Dolur");
                //}

                //TODO : öğrenci o seansa atanırken farklı bir grup ile derse giriyor mu




                //foreach (Ogrenci secilenogrenci in secilenOgrenciler)
                //{
                //    var result = repo.Get(z => z.Seans.Id == secilenSeans.Id).
                //      FirstOrDefault(z => z.Ogrencis.Contains(secilenogrenci));
                //    if (result != null)
                //    {
                //        MessageBox.Show($"Seçilen Öğreci {secilenogrenci.Adi} Zaten seansı mevcut");
                //        return;
                //    }
                //}
            }
            catch (Exception)
            {

                throw;
            }

          
        }

       // private void kontenjanAzalt(Sinif sınıf)
       // {
       //     var kontenjan = sınıf.GetType().GetProperty("Kontenjan");
       //     kontenjan.SetValue(sınıf,sınıf.Kontenjan,)
       // }

        private bool KontenjanKontrol(Sinif kontrolSınıfı,List<Ogrenci>kontrolOgrenciler)
        {

            var kontenjanproperty = kontrolSınıfı.GetType().GetProperty("Kontenjan");
            int Kontenjan = sinifRepo.Get(z => z.Id == kontrolSınıfı.Id).FirstOrDefault().Kontenjan;
            int fark = Kontenjan - kontrolOgrenciler.Count();
            if (kontrolOgrenciler.Count()<Kontenjan)
            {
                kontenjanproperty.SetValue(kontrolSınıfı, kontrolSınıfı.Kontenjan - kontrolOgrenciler.Count(),null); 

                MessageBox.Show("Seçilen Sınıfta Kalan Kontenjan: " +"  " + fark.ToString()  );

                return true;
            }
            else
            {
                MessageBox.Show("Seçilen Sınıfta Yeterli Kontenjan Yok");
                return false;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            VeriDoldur();
        }

        private void VeriDoldur()
        {
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = (from x in repo.GetAll()
                                        select new { x.Id, x.Ders, x.Ogretmen, x.Seans, x.Sinif,x.Sinif.Kontenjan }).ToList();

            ListBox lst = checkedListBox1;
            lst.DataSource = ogrenciRepo.GetAll();
            lst.DisplayMember = "Adi";
            lst.ValueMember = "Id";

            cmbDers.Text = "Seçiniz...";
            cmbDers.DataSource = dersrepo.GetAll();
            cmbDers.DisplayMember = "Adi";
            cmbDers.ValueMember = "Id";

            cmbOgretmen.Text = "Seçiniz...";
            cmbOgretmen.DataSource = ogretmenRepo.GetAll();
            cmbOgretmen.DisplayMember = "Adi";
            cmbOgretmen.ValueMember = "Id";


            cmbSeans.Text = "Seçiniz...";
            cmbSeans.DataSource = seansRepo.GetAll();
            cmbSeans.DisplayMember = "Adi";
            cmbSeans.ValueMember = "Id";


            
            cmbSinif.DataSource = sinifRepo.GetAll();
            cmbSinif.DisplayMember = "Adi";
            cmbSinif.ValueMember = "Id";

        }

        private void cmbDers_SelectionChangeCommitted(object sender, EventArgs e)
        {
            var selectedId = (int)cmbDers.SelectedValue;
            secilenDers = dersrepo.GetAll().FirstOrDefault(z => z.Id == selectedId);
        }

        private void cmbSinif_SelectionChangeCommitted(object sender, EventArgs e)
        {
            var selectedId = (int)cmbSinif.SelectedValue;
            secilenSinif = sinifRepo.GetAll().FirstOrDefault(z => z.Id == selectedId);
        }

        private void cmbOgretmen_SelectionChangeCommitted(object sender, EventArgs e)
        {
            var selectedId = (int)cmbOgretmen.SelectedValue;
            secilenOgretmen = ogretmenRepo.GetAll().FirstOrDefault(z => z.Id == selectedId);
        }

        private void cmbSeans_SelectionChangeCommitted(object sender, EventArgs e)
        {
            var selectedId = (int)cmbSeans.SelectedValue;
            secilenSeans = seansRepo.GetAll().FirstOrDefault(z => z.Id == selectedId);
        }
       
        private void button2_Click(object sender, EventArgs e)
        {
            int aydi = 0;
            aydi = Convert.ToInt32(txtsdID.Text);
            var a = repo.GetAll().FirstOrDefault(z => z.Id == aydi).Ogrencis.ToList();
            dataGridView1.DataSource = a;
            MessageBox.Show("Dersi Alan Öğrenci Sayısı:" + a.Count().ToString());
        }

        private void silToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
           
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                SinifDers sd = repo.GetAll().FirstOrDefault(z => z.Id == Convert.ToInt32(txtsdID.Text));
                Sinif sinif = repo.GetAll().FirstOrDefault(z => z.Id == Convert.ToInt32(txtsdID.Text)).Sinif;
                List<Ogrenci> ogrenciler = repo.GetAll().FirstOrDefault(z => z.Id == Convert.ToInt32(txtsdID.Text)).Ogrencis.ToList();
                kontenjanGüncelle(sinif, ogrenciler);
                repo.Delete(sd);
                MessageBox.Show("Silindi");
                VeriDoldur();
            }
            catch (Exception)
            {

                MessageBox.Show("Girilen Id'yi Kontrol edin");

            }

        }

        private void kontenjanGüncelle(Sinif kontrolSınıfı, List<Ogrenci> kontrolOgrenciler)
        {
            var kontenjan = kontrolSınıfı.GetType().GetProperty("Kontenjan");
            kontenjan.SetValue(kontrolSınıfı, kontrolSınıfı.Kontenjan + kontrolOgrenciler.Count(), null);
            VeriDoldur();
        }
        bool güncelleme = false;
        private void button4_Click(object sender, EventArgs e)
        {
            SinifDers sd = repo.GetAll().FirstOrDefault(z => z.Id == Convert.ToInt32(txtsdID.Text));
            cmbDers.Text = sd.Ders.ToString();
            cmbOgretmen.Text = sd.Ogretmen.ToString();
            cmbSeans.Text = sd.Seans.ToString();
            cmbSinif.Text = sd.Sinif.ToString();
            güncelleme = true;
            toolTip1.Active = true;

        }

        private void button1_MouseHover(object sender, EventArgs e)
        {
            
        }
    }
}
