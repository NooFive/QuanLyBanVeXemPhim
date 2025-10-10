using Nhom10_QuanLyBanVeXemPhim.DAL;
using Nhom10_QuanLyBanVeXemPhim.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nhom10_QuanLyBanVeXemPhim.BLL
{
    public class NhanVienBLL
    {
        private NhanVienDAL dal = new NhanVienDAL();

        public List<NhanVienDTO> LayDanhSachNhanVien()
        {
            return dal.GetAll();
        }

        public bool ThemNhanVien(NhanVienDTO nv)
        {
            if (string.IsNullOrWhiteSpace(nv.TenDangNhap) || string.IsNullOrWhiteSpace(nv.MatKhau) || string.IsNullOrWhiteSpace(nv.TenNV))
                return false;
            return dal.Insert(nv);
        }

        public bool SuaNhanVien(NhanVienDTO nv)
        {
            if (nv.MaNV <= 0 || string.IsNullOrWhiteSpace(nv.TenDangNhap) || string.IsNullOrWhiteSpace(nv.MatKhau) || string.IsNullOrWhiteSpace(nv.TenNV))
                return false;
            return dal.Update(nv);
        }

        public bool XoaNhanVien(int maNV)
        {
            if (maNV <= 0)
                return false;
            return dal.Delete(maNV);
        }

        public NhanVienDTO DangNhap(string username, string password)
        {
            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
                return null;
            return dal.DangNhap(username, password);
        }
    }
}
