namespace Nhom10_QuanLyBanVeXemPhim
{
    partial class frmBanVe
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmBanVe));
            this.guna2GradientPanel1 = new Guna.UI2.WinForms.Guna2GradientPanel();
            this.lbDSPhim = new System.Windows.Forms.ListBox();
            this.txtTimKiemPhim = new Guna.UI2.WinForms.Guna2TextBox();
            this.guna2Elipse1 = new Guna.UI2.WinForms.Guna2Elipse(this.components);
            this.guna2Panel1 = new Guna.UI2.WinForms.Guna2Panel();
            this.lbSuatChieu = new System.Windows.Forms.ListBox();
            this.picBoxPoster = new Guna.UI2.WinForms.Guna2PictureBox();
            this.guna2Elipse2 = new Guna.UI2.WinForms.Guna2Elipse(this.components);
            this.guna2GradientPanel1.SuspendLayout();
            this.guna2Panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picBoxPoster)).BeginInit();
            this.SuspendLayout();
            // 
            // guna2GradientPanel1
            // 
            this.guna2GradientPanel1.Controls.Add(this.lbDSPhim);
            this.guna2GradientPanel1.Controls.Add(this.txtTimKiemPhim);
            this.guna2GradientPanel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.guna2GradientPanel1.Location = new System.Drawing.Point(0, 0);
            this.guna2GradientPanel1.Name = "guna2GradientPanel1";
            this.guna2GradientPanel1.Size = new System.Drawing.Size(236, 450);
            this.guna2GradientPanel1.TabIndex = 0;
            // 
            // lbDSPhim
            // 
            this.lbDSPhim.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lbDSPhim.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbDSPhim.FormattingEnabled = true;
            this.lbDSPhim.ItemHeight = 17;
            this.lbDSPhim.Items.AddRange(new object[] {
            "Avatar 2",
            "The Marvel",
            "Mèo Béo Siêu Quậy",
            "Mưa Đỏ",
            "Làm Giàu Với Ma"});
            this.lbDSPhim.Location = new System.Drawing.Point(12, 58);
            this.lbDSPhim.Name = "lbDSPhim";
            this.lbDSPhim.Size = new System.Drawing.Size(213, 374);
            this.lbDSPhim.TabIndex = 1;
            this.lbDSPhim.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.lbDSPhim_DrawItem);
            // 
            // txtTimKiemPhim
            // 
            this.txtTimKiemPhim.BorderRadius = 10;
            this.txtTimKiemPhim.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtTimKiemPhim.DefaultText = "";
            this.txtTimKiemPhim.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtTimKiemPhim.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtTimKiemPhim.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtTimKiemPhim.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtTimKiemPhim.FillColor = System.Drawing.Color.WhiteSmoke;
            this.txtTimKiemPhim.FocusedState.BorderColor = System.Drawing.Color.DodgerBlue;
            this.txtTimKiemPhim.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtTimKiemPhim.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtTimKiemPhim.IconLeft = ((System.Drawing.Image)(resources.GetObject("txtTimKiemPhim.IconLeft")));
            this.txtTimKiemPhim.Location = new System.Drawing.Point(12, 12);
            this.txtTimKiemPhim.Name = "txtTimKiemPhim";
            this.txtTimKiemPhim.PlaceholderText = "Tìm kiếm tên phim..";
            this.txtTimKiemPhim.SelectedText = "";
            this.txtTimKiemPhim.Size = new System.Drawing.Size(213, 36);
            this.txtTimKiemPhim.TabIndex = 0;
            // 
            // guna2Elipse1
            // 
            this.guna2Elipse1.BorderRadius = 20;
            this.guna2Elipse1.TargetControl = this.lbDSPhim;
            // 
            // guna2Panel1
            // 
            this.guna2Panel1.Controls.Add(this.lbSuatChieu);
            this.guna2Panel1.Controls.Add(this.picBoxPoster);
            this.guna2Panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.guna2Panel1.Location = new System.Drawing.Point(236, 0);
            this.guna2Panel1.Name = "guna2Panel1";
            this.guna2Panel1.Size = new System.Drawing.Size(564, 450);
            this.guna2Panel1.TabIndex = 1;
            // 
            // lbSuatChieu
            // 
            this.lbSuatChieu.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lbSuatChieu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbSuatChieu.FormattingEnabled = true;
            this.lbSuatChieu.Location = new System.Drawing.Point(0, 200);
            this.lbSuatChieu.Name = "lbSuatChieu";
            this.lbSuatChieu.Size = new System.Drawing.Size(564, 250);
            this.lbSuatChieu.TabIndex = 1;
            // 
            // picBoxPoster
            // 
            this.picBoxPoster.BorderRadius = 20;
            this.picBoxPoster.Dock = System.Windows.Forms.DockStyle.Top;
            this.picBoxPoster.ImageRotate = 0F;
            this.picBoxPoster.Location = new System.Drawing.Point(0, 0);
            this.picBoxPoster.Name = "picBoxPoster";
            this.picBoxPoster.Size = new System.Drawing.Size(564, 200);
            this.picBoxPoster.TabIndex = 0;
            this.picBoxPoster.TabStop = false;
            // 
            // guna2Elipse2
            // 
            this.guna2Elipse2.BorderRadius = 15;
            this.guna2Elipse2.TargetControl = this.lbSuatChieu;
            // 
            // frmBanVe
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.guna2Panel1);
            this.Controls.Add(this.guna2GradientPanel1);
            this.Name = "frmBanVe";
            this.Text = "Bán vé";
            this.guna2GradientPanel1.ResumeLayout(false);
            this.guna2Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picBoxPoster)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2GradientPanel guna2GradientPanel1;
        private Guna.UI2.WinForms.Guna2TextBox txtTimKiemPhim;
        private System.Windows.Forms.ListBox lbDSPhim;
        private Guna.UI2.WinForms.Guna2Elipse guna2Elipse1;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel1;
        private System.Windows.Forms.ListBox lbSuatChieu;
        private Guna.UI2.WinForms.Guna2PictureBox picBoxPoster;
        private Guna.UI2.WinForms.Guna2Elipse guna2Elipse2;
    }
}