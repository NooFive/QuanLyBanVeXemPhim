using Nhom10_QuanLyBanVeXemPhim.BLL;
using Nhom10_QuanLyBanVeXemPhim.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Nhom10_QuanLyBanVeXemPhim
{
    public partial class frmAdmin : Form
    {
        public frmAdmin()
        {
            InitializeComponent();
        }
        private void frmAdmin_Load(object sender, EventArgs e)
        {
            LoadPhongChieu();
        }
        private void guna2TabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tcMenu.SelectedTab == tcPhongChieu)
            {
                LoadPhongChieu();
            }
        }

        private void LoadPhongChieu()
        {
            var bll = new PhongChieuBLL();
            var list = bll.LayDanhSachPhong();
            dgvPhongChieu.AutoGenerateColumns = false;
            dgvPhongChieu.DataSource = list;         

        }

        private void btnThemPC_Click(object sender, EventArgs e)
        {
            var p = new PhongChieuDTO()
            {
                TenPhong = txtTenPC.Text.Trim(),
                SoChoNgoi = int.Parse(txtSoCN.Text),
                TinhTrang = cbTinhTrang.Text
            };
            var bll = new PhongChieuBLL();
            if (bll.ThemPhong(p))
            {
                MessageBox.Show("Thêm thành công!");
                LoadPhongChieu();
            }
            else
            {
                MessageBox.Show("Thêm thất bại!");
            }
        }

        
    }
}
