using Nhom10_QuanLyBanVeXemPhim.BLL;
using Nhom10_QuanLyBanVeXemPhim.DAL;
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
        private PhongChieuBLL phongbll = new PhongChieuBLL();
        private SuatChieuBLL scbll = new SuatChieuBLL();
        private TheLoaiPhimBLL tlbll = new TheLoaiPhimBLL();
        private NhanVienBLL nvBLL = new NhanVienBLL();
        private PhimBLL phimBll = new PhimBLL();

        public frmAdmin()
        {
            InitializeComponent();
        }
        private void frmAdmin_Load(object sender, EventArgs e)
        {
            LoadDSPhong();
            SetMaPhong();

            LoadPhongToComboBox();
            LoadPhimToComboBox();
            LoadDSSuatChieu();
            SetMaSuatChieu();

            LoadDSTheloai();
            SetMaTL();

            LoadDSNhanVien();
            SetMaNhanVien();

            LoadDSPhim();
            LoadTheLoaiToCheckedListBox();
            SetMaPhim();
        }
        //=========================================PHÒNG CHIẾU===================================================
        private void LoadDSPhong()
        {
            dgvPhongChieu.DataSource = phongbll.LayDanhSachPhong();
        }
        private void SetMaPhong()
        {
            var list = phongbll.LayDanhSachPhong();
            int nextId = list.Count > 0 ? list.Max(x => x.MaPhong) + 1 : 1;

            txtMaPC.Text = nextId.ToString();
            txtMaPC.ReadOnly = true;
        }
        private void dgvPhongChieu_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvPhongChieu.Rows[e.RowIndex];
                txtMaPC.Text = row.Cells["MaPhong"].Value.ToString();
                txtTenPC.Text = row.Cells["TenPhong"].Value.ToString();
                txtSoCN.Text = row.Cells["SoChoNgoi"].Value.ToString();
                cbTinhTrang.Text = row.Cells["TinhTrang"].Value.ToString();
                btnThemPC.Text = "Cập nhật";
                txtMaPC.ReadOnly = true;
            }
        }
        private void btnThemPC_Click(object sender, EventArgs e)
        {
            PhongChieuDTO p = new PhongChieuDTO
            {
                TenPhong = txtTenPC.Text,
                SoChoNgoi = int.Parse(txtSoCN.Text),
                TinhTrang = cbTinhTrang.Text
            };

            if (btnThemPC.Text == "Thêm") // Nếu đang ở chế độ thêm
            {
                if (phongbll.ThemPhong(p))
                    MessageBox.Show("Thêm thành công!", "Thông báo");
                else
                    MessageBox.Show("Thêm thất bại!", "Thông báo");
            }
            else // Nếu đang ở chế độ cập nhật
            {
                p.MaPhong = int.Parse(txtMaPC.Text);
                if (phongbll.SuaPhong(p))
                    MessageBox.Show("Cập nhật thành công!", "Thông báo");
                else
                    MessageBox.Show("Cập nhật thất bại!", "Thông báo");

                btnThemPC.Text = "Thêm"; // Đổi lại nút
            }

            LoadDSPhong();
            SetMaPhong();
            txtTenPC.Clear();
            txtSoCN.Clear();
            cbTinhTrang.SelectedIndex = 0;
        }

        private void tsmDelete_Click(object sender, EventArgs e)
        {
            if (dgvPhongChieu.SelectedRows.Count > 0)
            {
                string maPhong = dgvPhongChieu.SelectedRows[0].Cells["MaPhong"].Value.ToString();

                DialogResult result = MessageBox.Show($"Bạn có chắc muốn xóa phòng {maPhong}?", "Xác nhận", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    if (phongbll.XoaPhong(int.Parse(maPhong)))
                    {
                        MessageBox.Show("Xóa thành công!", "Thông báo");
                        LoadDSPhong();
                        SetMaPhong(); // Sinh mã mới sau khi xóa
                        txtTenPC.Clear();
                        txtSoCN.Clear();
                        cbTinhTrang.SelectedIndex = 0;
                    }
                    else
                    {
                        MessageBox.Show("Xóa thất bại!", "Thông báo");
                    }
                }
            }
        }
        //=========================================SUẤT CHIẾU===================================================
        private void LoadDSSuatChieu()
        {
            dgvSuatChieu.DataSource = scbll.LayDanhSachSuatChieu();
        }
        private void LoadPhongToComboBox()
        {
            var ds = phongbll.LayDanhSachPhong();
            cbMaPhong.DataSource = ds;
            cbMaPhong.DisplayMember = "TenPhong";
            cbMaPhong.ValueMember = "MaPhong";
        }
        private void LoadPhimToComboBox()
        {
            var ds = phimBll.LayDanhSachPhim();
            cbMaPhim.DataSource = ds;
            cbMaPhim.DisplayMember = "TenPhim";
            cbMaPhim.ValueMember = "MaPhim";
        }
        private void SetMaSuatChieu()
        {
            var list = scbll.LayDanhSachSuatChieu();
            int nextId = list.Count > 0 ? list.Max(x => x.MaSC) + 1 : 1;
            txtMaSC.Text = nextId.ToString();
            txtMaSC.ReadOnly = true;
        }

        private void dgvSuatChieu_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvSuatChieu.Rows[e.RowIndex];
                txtMaSC.Text = row.Cells["MaSC"].Value.ToString();
                cbMaPhong.SelectedValue = row.Cells["MaPhong_SC"].Value;
                cbMaPhim.SelectedValue = row.Cells["MaPhim_SC"].Value;
                dtpTGChieu.Value = Convert.ToDateTime(row.Cells["ThoiGianChieu"].Value);
                txtGiaVe.Text = row.Cells["GiaVe"].Value.ToString();

                btnThemSC.Text = "Cập nhật";
                txtMaSC.ReadOnly = true;
            }
        }

        private void btnThemSC_Click(object sender, EventArgs e)
        {
            SuatChieuDTO sc = new SuatChieuDTO
            {
                MaPhong = Convert.ToInt32(cbMaPhong.SelectedValue),
                MaPhim = Convert.ToInt32(cbMaPhim.SelectedValue),
                ThoiGianChieu = dtpTGChieu.Value,
                GiaVe = decimal.Parse(txtGiaVe.Text)
            };

            if (btnThemSC.Text == "Thêm")
            {
                if (scbll.ThemSuatChieu(sc))
                    MessageBox.Show("Thêm thành công!");
                else
                    MessageBox.Show("Thêm thất bại!");
            }
            else
            {
                sc.MaSC = int.Parse(txtMaSC.Text);
                if (scbll.SuaSuatChieu(sc))
                    MessageBox.Show("Cập nhật thành công!");
                else
                    MessageBox.Show("Cập nhật thất bại!");

                btnThemSC.Text = "Thêm";
            }

            LoadDSSuatChieu();
            SetMaSuatChieu();
            txtGiaVe.Clear();
            cbMaPhong.SelectedIndex = 0;
            cbMaPhim.SelectedIndex = 0;
        }

        private void tsmDeleteSC_Click(object sender, EventArgs e)
        {
            if (dgvSuatChieu.SelectedRows.Count > 0)
            {
                string maSC = dgvSuatChieu.SelectedRows[0].Cells["MaSC"].Value.ToString();
                DialogResult dr = MessageBox.Show($"Xóa suất chiếu {maSC}?", "Xác nhận", MessageBoxButtons.YesNo);
                if (dr == DialogResult.Yes)
                {
                    if (scbll.XoaSuatChieu(int.Parse(maSC)))
                    {
                        MessageBox.Show("Xóa thành công!");
                        LoadDSSuatChieu();
                        SetMaSuatChieu();
                        txtGiaVe.Clear();
                        cbMaPhong.SelectedIndex = 0;
                        cbMaPhim.SelectedIndex = 0;
                    }
                    else
                        MessageBox.Show("Xóa thất bại!");
                }
            }
        }
        //==========================================THẺ LOẠI===================================================
        private void LoadDSTheloai()
        {
            dgvTLPhim.DataSource = tlbll.LayDanhSachTheLoai();
        }
        private void SetMaTL()
        {
            var list = tlbll.LayDanhSachTheLoai();
            int nextId = list.Count > 0 ? list.Max(x => x.MaTheLoai) + 1 : 1;
            txtMaTheLoai.Text = nextId.ToString();
            txtMaTheLoai.ReadOnly = true;
        }

        private void dgvTLPhim_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvTLPhim.Rows[e.RowIndex];
                txtMaTheLoai.Text = row.Cells["MaTheLoai"].Value.ToString();
                txtTenTheLoai.Text = row.Cells["TenTheLoai"].Value.ToString();
                btnThemTL.Text = "Cập nhật";
                txtMaTheLoai.ReadOnly = true;
            }
        }

        private void btnThemTL_Click(object sender, EventArgs e)
        {
            TheLoaiPhimDTO tl = new TheLoaiPhimDTO
            {
                TenTheLoai = txtTenTheLoai.Text
            };

            if (btnThemTL.Text == "Thêm")
            {
                if (tlbll.ThemTheLoai(tl))
                    MessageBox.Show("Thêm thành công!", "Thông báo");
                else
                    MessageBox.Show("Thêm thất bại!", "Thông báo");
            }
            else
            {
                tl.MaTheLoai = int.Parse(txtMaTheLoai.Text);
                if (tlbll.SuaTheLoai(tl))
                    MessageBox.Show("Cập nhật thành công!", "Thông báo");
                else
                    MessageBox.Show("Cập nhật thất bại!", "Thông báo");

                btnThemTL.Text = "Thêm";
            }

            LoadDSTheloai();
            SetMaTL();
            txtTenTheLoai.Clear();
        }

        private void tsmDeleteTL_Click(object sender, EventArgs e)
        {
            if (dgvTLPhim.SelectedRows.Count > 0)
            {
                string maTL = dgvTLPhim.SelectedRows[0].Cells["MaTheLoai"].Value.ToString();

                DialogResult result = MessageBox.Show($"Bạn có chắc muốn xóa thể loại {maTL}?", "Xác nhận", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    if (tlbll.XoaTheLoai(int.Parse(maTL)))
                    {
                        MessageBox.Show("Xóa thành công!", "Thông báo");
                        LoadDSTheloai();
                        SetMaTL();
                        txtTenTheLoai.Clear();
                    }
                    else
                        MessageBox.Show("Xóa thất bại!", "Thông báo");
                }
            }
        }
        //=========================================NHÂN VIÊN===================================================
        private void LoadDSNhanVien()
        {
            dgvNhanVien.DataSource = nvBLL.LayDanhSachNhanVien();
        }

        private void SetMaNhanVien()
        {
            var list = nvBLL.LayDanhSachNhanVien();
            int nextId = list.Count > 0 ? list.Max(x => x.MaNV) + 1 : 1;
            txtMaNV.Text = nextId.ToString();
            txtMaNV.ReadOnly = true;
        }

        private void dgvNhanVien_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvNhanVien.Rows[e.RowIndex];
                txtMaNV.Text = row.Cells["MaNV"].Value.ToString();
                txtTenDN.Text = row.Cells["TenDangNhap"].Value.ToString();
                txtMatKhau.Text = row.Cells["MatKhau"].Value.ToString();
                txtTenNV.Text = row.Cells["TenNV"].Value.ToString();

                bool isAdmin = Convert.ToBoolean(row.Cells["LaAdmin"].Value);
                cbQuyen.SelectedItem = isAdmin ? "Quản trị" : "Nhân viên";

                btnThemNV.Text = "Cập nhật";
                txtMaNV.ReadOnly = true;
            }
        }
        private void btnThemNV_Click(object sender, EventArgs e)
        {
            NhanVienDTO nv = new NhanVienDTO
            {
                TenDangNhap = txtTenDN.Text.Trim(),
                MatKhau = txtMatKhau.Text.Trim(),
                TenNV = txtTenNV.Text.Trim(),
                LaAdmin = cbQuyen.SelectedItem.ToString() == "Quản trị"
            };

            if (btnThemNV.Text == "Thêm")
            {
                if (nvBLL.ThemNhanVien(nv))
                    MessageBox.Show("Thêm nhân viên thành công!", "Thông báo");
                else
                    MessageBox.Show("Thêm thất bại!", "Thông báo");
            }
            else
            {
                nv.MaNV = int.Parse(txtMaNV.Text);
                if (nvBLL.SuaNhanVien(nv))
                    MessageBox.Show("Cập nhật thành công!", "Thông báo");
                else
                    MessageBox.Show("Cập nhật thất bại!", "Thông báo");
                btnThemNV.Text = "Thêm";
            }

            // Load lại grid & set mã nhân viên mới
            LoadDSNhanVien();
            SetMaNhanVien();

            // XÓA TRỰC TIẾP CÁC CONTROL (không dùng hàm ClearInput)
            txtTenDN.Clear();
            txtMatKhau.Clear();
            txtTenNV.Clear();
            cbQuyen.SelectedIndex = 1; // Mặc định chọn Nhân viên
        }
        private void tsmDeleteNV_Click(object sender, EventArgs e)
        {
            if (dgvNhanVien.SelectedRows.Count > 0)
            {
                string ma = dgvNhanVien.SelectedRows[0].Cells["MaNV"].Value.ToString();
                DialogResult result = MessageBox.Show($"Bạn có chắc muốn xóa nhân viên {ma}?", "Xác nhận", MessageBoxButtons.YesNo);

                if (result == DialogResult.Yes)
                {
                    if (nvBLL.XoaNhanVien(int.Parse(ma)))
                    {
                        MessageBox.Show("Xóa thành công!", "Thông báo");
                        LoadDSNhanVien();
                        SetMaNhanVien();

                        txtTenDN.Clear();
                        txtMatKhau.Clear();
                        txtTenNV.Clear();
                        cbQuyen.SelectedIndex = 1;
                    }
                    else
                    {
                        MessageBox.Show("Xóa thất bại!", "Thông báo");
                    }
                }
            }
        }
        //============================================PHIM=====================================================
        private void LoadDSPhim()
        {
            dgvPhim.DataSource = phimBll.LayDanhSachPhim();
        }
        private void SetMaPhim()
        {
            var list = phimBll.LayDanhSachPhim();
            int nextId = list.Count > 0 ? list.Max(x => x.MaPhim) + 1 : 1;
            txtMaPhim.Text = nextId.ToString();
            txtMaPhim.ReadOnly = true;
        }
        private void LoadTheLoaiToCheckedListBox()
        {
            clbTheLoai.Items.Clear();
            var ds = tlbll.LayDanhSachTheLoai();  // Giả sử BLL lấy list DTO
            foreach (var tl in ds)
            {
                clbTheLoai.Items.Add(tl);
            }
        }

        private void dgvPhim_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvPhim.Rows[e.RowIndex];
                txtMaPhim.Text = row.Cells["MaPhim"].Value.ToString();
                txtTenPhim.Text = row.Cells["TenPhim"].Value.ToString();
                txtMoTa.Text = row.Cells["MoTa"].Value.ToString();
                txtThoiLuong.Text = row.Cells["ThoiLuong"].Value.ToString();
                dtpKC.Value = Convert.ToDateTime(row.Cells["NgayKC"].Value);
                dtpKT.Value = Convert.ToDateTime(row.Cells["NgayKT"].Value);
                txtQuocGia.Text = row.Cells["QuocGia"].Value.ToString();
                txtGioiHanTuoi.Text = row.Cells["GioiHanTuoi"].Value.ToString();

                // Check lại các thể loại
                foreach (int i in Enumerable.Range(0, clbTheLoai.Items.Count))
                {
                    clbTheLoai.SetItemChecked(i, false);
                }

                string theLoaiHienThi = row.Cells["MaTheLoai_Phim"].Value?.ToString();
                if (!string.IsNullOrEmpty(theLoaiHienThi))
                {
                    string[] arr = theLoaiHienThi.Split(',');
                    foreach (string tl in arr)
                    {
                        for (int i = 0; i < clbTheLoai.Items.Count; i++)
                        {
                            var item = clbTheLoai.Items[i] as TheLoaiPhimDTO;
                            if (item != null && item.TenTheLoai.Trim() == tl.Trim())
                                clbTheLoai.SetItemChecked(i, true);
                        }
                    }
                }

                btnThemPhim.Text = "Cập nhật";
            }
        }
        private void btnThemPhim_Click(object sender, EventArgs e)
        {
            PhimDTO p = new PhimDTO
            {
                TenPhim = txtTenPhim.Text,
                MoTa = txtMoTa.Text,
                ThoiLuong = int.Parse(txtThoiLuong.Text),
                NgayKC = dtpKC.Value,
                NgayKT = dtpKT.Value,
                QuocGia = txtQuocGia.Text,
                GioiHanTuoi = int.Parse(txtGioiHanTuoi.Text)
            };

            // Lấy danh sách thể loại được check
            List<int> dsMaTL = new List<int>();
            foreach (var item in clbTheLoai.CheckedItems)
            {
                if (item is TheLoaiPhimDTO tl)
                    dsMaTL.Add(tl.MaTheLoai);
            }

            if (btnThemPhim.Text == "Thêm")
            {
                if (phimBll.ThemPhim(p, dsMaTL))
                    MessageBox.Show("Thêm phim thành công!");
                else
                    MessageBox.Show("Thêm thất bại!");
            }
            else
            {
                p.MaPhim = int.Parse(txtMaPhim.Text);
                if (phimBll.SuaPhim(p, dsMaTL))
                    MessageBox.Show("Cập nhật thành công!");
                else
                    MessageBox.Show("Cập nhật thất bại!");

                btnThemPhim.Text = "Thêm";
            }

            LoadDSPhim();
            SetMaPhim();

            txtTenPhim.Clear();
            txtMoTa.Clear();
            txtThoiLuong.Clear();
            txtQuocGia.Clear();
            txtGioiHanTuoi.Clear();
            for (int i = 0; i < clbTheLoai.Items.Count; i++)
                clbTheLoai.SetItemChecked(i, false);
        }

        private void tsmDeletePhim_Click(object sender, EventArgs e)
        {
            if (dgvPhim.SelectedRows.Count > 0)
            {
                string ma = dgvPhim.SelectedRows[0].Cells["MaPhim"].Value.ToString();
                DialogResult dr = MessageBox.Show($"Xóa phim {ma}?", "Xác nhận", MessageBoxButtons.YesNo);

                if (dr == DialogResult.Yes)
                {
                    if (phimBll.XoaPhim(int.Parse(ma)))
                    {
                        MessageBox.Show("Xóa thành công!");
                        LoadDSPhim();
                        SetMaPhim();
                    }
                    else
                        MessageBox.Show("Xóa thất bại!");
                }
            }
        }    
    }
}


            
        

        
    

