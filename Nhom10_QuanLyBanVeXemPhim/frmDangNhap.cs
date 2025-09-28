using Nhom10_QuanLyBanVeXemPhim.BLL;
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
    public partial class frmDangNhap : Form
    {
        public frmDangNhap()
        {
            InitializeComponent();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            txtUsername.Focus();
            string user = txtUsername.Text.Trim();
            string pass = txtPassword.Text.Trim();

            var bll = new NhanVienBLL();
            var result = bll.KiemTraDangNhap(user, pass);

            if (result.success)
            {
                this.Hide();

                if (result.isAdmin)
                {
                    MessageBox.Show($"Xin chào quản trị {result.tenNV}", "Thông báo");
                    frmAdmin f = new frmAdmin();
                    f.ShowDialog();
                }
                else
                {
                    MessageBox.Show($"Xin chào nhân viên {result.tenNV}", "Thông báo");
                    frmBanVe f = new frmBanVe();
                    f.ShowDialog();
                }

                this.Close();
            }
            else
            {
                txtUsername.Clear();
                txtPassword.Clear();
                MessageBox.Show("Sai tài khoản hoặc mật khẩu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
