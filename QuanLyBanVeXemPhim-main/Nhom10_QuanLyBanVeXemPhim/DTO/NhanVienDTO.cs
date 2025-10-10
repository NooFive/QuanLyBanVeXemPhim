using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nhom10_QuanLyBanVeXemPhim.DTO
{
    public class NhanVienDTO
    {
        public int MaNV { get; set; }
        public string TenDangNhap { get; set; }
        public string MatKhau { get; set; }
        public string TenNV { get; set; }
        public bool LaAdmin { get; set; }
        public NhanVienDTO()
        {

        }
        public NhanVienDTO(int maNV, string tenDangNhap, string matKhau, string tenNV, bool laAdmin)
        {
            MaNV = maNV;
            TenDangNhap = tenDangNhap;
            MatKhau = matKhau;
            TenNV = tenNV;
            LaAdmin = laAdmin;
        }
    }
}
