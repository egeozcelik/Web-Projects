namespace BilgeKadin.WinUI
{
    partial class AnaSayfa
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AnaSayfa));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.ögrenciİşlemleriToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btnYeniOgrenci = new System.Windows.Forms.ToolStripMenuItem();
            this.kayitliOgrenci = new System.Windows.Forms.ToolStripMenuItem();
            this.seansİşlemleriToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.seansTanımlaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sinifİşlemlerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sınıfTanımlaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sınıfListesiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.öğretmenİşlemleriToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.öğretmenTanımlaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.öğretmenListesiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dersİşlemleriToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dersListesiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dersEkleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ögrenciİşlemleriToolStripMenuItem,
            this.seansİşlemleriToolStripMenuItem,
            this.sinifİşlemlerToolStripMenuItem,
            this.öğretmenİşlemleriToolStripMenuItem,
            this.dersİşlemleriToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1167, 28);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // ögrenciİşlemleriToolStripMenuItem
            // 
            this.ögrenciİşlemleriToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnYeniOgrenci,
            this.kayitliOgrenci});
            this.ögrenciİşlemleriToolStripMenuItem.Name = "ögrenciİşlemleriToolStripMenuItem";
            this.ögrenciİşlemleriToolStripMenuItem.Size = new System.Drawing.Size(135, 24);
            this.ögrenciİşlemleriToolStripMenuItem.Text = "Ögrenci İşlemleri";
            // 
            // btnYeniOgrenci
            // 
            this.btnYeniOgrenci.Name = "btnYeniOgrenci";
            this.btnYeniOgrenci.Size = new System.Drawing.Size(206, 26);
            this.btnYeniOgrenci.Text = "Yeni Kayıt";
            this.btnYeniOgrenci.Click += new System.EventHandler(this.btnYeniOgrenci_Click);
            // 
            // kayitliOgrenci
            // 
            this.kayitliOgrenci.Name = "kayitliOgrenci";
            this.kayitliOgrenci.Size = new System.Drawing.Size(206, 26);
            this.kayitliOgrenci.Text = "Kayıtlı Öğrenciler";
            this.kayitliOgrenci.Click += new System.EventHandler(this.kayitliOgrenci_Click);
            // 
            // seansİşlemleriToolStripMenuItem
            // 
            this.seansİşlemleriToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.seansTanımlaToolStripMenuItem});
            this.seansİşlemleriToolStripMenuItem.Name = "seansİşlemleriToolStripMenuItem";
            this.seansİşlemleriToolStripMenuItem.Size = new System.Drawing.Size(121, 24);
            this.seansİşlemleriToolStripMenuItem.Text = "Seans İşlemleri";
            // 
            // seansTanımlaToolStripMenuItem
            // 
            this.seansTanımlaToolStripMenuItem.Name = "seansTanımlaToolStripMenuItem";
            this.seansTanımlaToolStripMenuItem.Size = new System.Drawing.Size(223, 26);
            this.seansTanımlaToolStripMenuItem.Text = "Tüm Seans İşlemleri";
            this.seansTanımlaToolStripMenuItem.Click += new System.EventHandler(this.seansTanımlaToolStripMenuItem_Click);
            // 
            // sinifİşlemlerToolStripMenuItem
            // 
            this.sinifİşlemlerToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.sınıfTanımlaToolStripMenuItem,
            this.sınıfListesiToolStripMenuItem});
            this.sinifİşlemlerToolStripMenuItem.Name = "sinifİşlemlerToolStripMenuItem";
            this.sinifİşlemlerToolStripMenuItem.Size = new System.Drawing.Size(112, 24);
            this.sinifİşlemlerToolStripMenuItem.Text = "Sınıf İşlemleri";
            // 
            // sınıfTanımlaToolStripMenuItem
            // 
            this.sınıfTanımlaToolStripMenuItem.Name = "sınıfTanımlaToolStripMenuItem";
            this.sınıfTanımlaToolStripMenuItem.Size = new System.Drawing.Size(176, 26);
            this.sınıfTanımlaToolStripMenuItem.Text = "Sınıf Tanımla";
            this.sınıfTanımlaToolStripMenuItem.Click += new System.EventHandler(this.sınıfTanımlaToolStripMenuItem_Click);
            // 
            // sınıfListesiToolStripMenuItem
            // 
            this.sınıfListesiToolStripMenuItem.Name = "sınıfListesiToolStripMenuItem";
            this.sınıfListesiToolStripMenuItem.Size = new System.Drawing.Size(176, 26);
            this.sınıfListesiToolStripMenuItem.Text = "Sınıf Listesi";
            this.sınıfListesiToolStripMenuItem.Click += new System.EventHandler(this.sınıfListesiToolStripMenuItem_Click);
            // 
            // öğretmenİşlemleriToolStripMenuItem
            // 
            this.öğretmenİşlemleriToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.öğretmenTanımlaToolStripMenuItem,
            this.öğretmenListesiToolStripMenuItem});
            this.öğretmenİşlemleriToolStripMenuItem.Name = "öğretmenİşlemleriToolStripMenuItem";
            this.öğretmenİşlemleriToolStripMenuItem.Size = new System.Drawing.Size(150, 24);
            this.öğretmenİşlemleriToolStripMenuItem.Text = "Öğretmen İşlemleri";
            // 
            // öğretmenTanımlaToolStripMenuItem
            // 
            this.öğretmenTanımlaToolStripMenuItem.Name = "öğretmenTanımlaToolStripMenuItem";
            this.öğretmenTanımlaToolStripMenuItem.Size = new System.Drawing.Size(214, 26);
            this.öğretmenTanımlaToolStripMenuItem.Text = "Öğretmen Tanımla";
            this.öğretmenTanımlaToolStripMenuItem.Click += new System.EventHandler(this.öğretmenTanımlaToolStripMenuItem_Click);
            // 
            // öğretmenListesiToolStripMenuItem
            // 
            this.öğretmenListesiToolStripMenuItem.Name = "öğretmenListesiToolStripMenuItem";
            this.öğretmenListesiToolStripMenuItem.Size = new System.Drawing.Size(214, 26);
            this.öğretmenListesiToolStripMenuItem.Text = "Öğretmen Listesi";
            this.öğretmenListesiToolStripMenuItem.Click += new System.EventHandler(this.öğretmenListesiToolStripMenuItem_Click);
            // 
            // dersİşlemleriToolStripMenuItem
            // 
            this.dersİşlemleriToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.dersListesiToolStripMenuItem,
            this.dersEkleToolStripMenuItem});
            this.dersİşlemleriToolStripMenuItem.Name = "dersİşlemleriToolStripMenuItem";
            this.dersİşlemleriToolStripMenuItem.Size = new System.Drawing.Size(113, 24);
            this.dersİşlemleriToolStripMenuItem.Text = "Ders İşlemleri";
            // 
            // dersListesiToolStripMenuItem
            // 
            this.dersListesiToolStripMenuItem.Name = "dersListesiToolStripMenuItem";
            this.dersListesiToolStripMenuItem.Size = new System.Drawing.Size(166, 26);
            this.dersListesiToolStripMenuItem.Text = "Ders Listesi";
            this.dersListesiToolStripMenuItem.Click += new System.EventHandler(this.dersListesiToolStripMenuItem_Click);
            // 
            // dersEkleToolStripMenuItem
            // 
            this.dersEkleToolStripMenuItem.Name = "dersEkleToolStripMenuItem";
            this.dersEkleToolStripMenuItem.Size = new System.Drawing.Size(166, 26);
            this.dersEkleToolStripMenuItem.Text = "Ders Ekle";
            this.dersEkleToolStripMenuItem.Click += new System.EventHandler(this.dersEkleToolStripMenuItem_Click);
            // 
            // AnaSayfa
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1167, 431);
            this.Controls.Add(this.menuStrip1);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AnaSayfa";
            this.Text = "AnaSayfa";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem ögrenciİşlemleriToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem btnYeniOgrenci;
        private System.Windows.Forms.ToolStripMenuItem kayitliOgrenci;
        private System.Windows.Forms.ToolStripMenuItem seansİşlemleriToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem seansTanımlaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sinifİşlemlerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sınıfTanımlaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sınıfListesiToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem öğretmenİşlemleriToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem öğretmenTanımlaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem öğretmenListesiToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem dersİşlemleriToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem dersListesiToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem dersEkleToolStripMenuItem;
    }
}