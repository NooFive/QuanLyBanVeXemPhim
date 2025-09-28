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

        public (bool success, bool isAdmin, string tenNV) KiemTraDangNhap(string user, string pass)
        {
            NhanVienDTO nv = dal.DangNhap(user, pass);
            if (nv != null)
            {
                return (true, nv.LaAdmin, nv.TenNV);
            }
            return (false, false, null);
        }
    }
}
