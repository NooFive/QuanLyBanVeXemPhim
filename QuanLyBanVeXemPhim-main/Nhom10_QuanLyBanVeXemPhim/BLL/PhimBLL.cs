using Nhom10_QuanLyBanVeXemPhim.DAL;
using Nhom10_QuanLyBanVeXemPhim.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nhom10_QuanLyBanVeXemPhim.BLL
{
    public class PhimBLL
    {
        private PhimDAL dal = new PhimDAL();

        public List<PhimDTO> LayDanhSachPhim()
        {
            return dal.GetAll();
        }

        public bool ThemPhim(PhimDTO p, List<int> dsMaTheLoai)
        {
            if (string.IsNullOrWhiteSpace(p.TenPhim)
                || p.ThoiLuong <= 0
                || p.NgayKC == default
                || p.NgayKT == default
                || string.IsNullOrWhiteSpace(p.QuocGia)
                || p.GioiHanTuoi <= 0)
            {
                return false;
            }

            return dal.Insert(p, dsMaTheLoai) > 0;
        }

        public bool SuaPhim(PhimDTO p, List<int> dsMaTheLoai)
        {
            if (p.MaPhim <= 0
                || string.IsNullOrWhiteSpace(p.TenPhim)
                || p.ThoiLuong <= 0
                || p.NgayKC == default
                || p.NgayKT == default
                || string.IsNullOrWhiteSpace(p.QuocGia)
                || p.GioiHanTuoi <= 0)
            {
                return false;
            }

            return dal.Update(p, dsMaTheLoai);
        }

        public bool XoaPhim(int maPhim)
        {
            if (maPhim <= 0)
                return false;
            return dal.Delete(maPhim);
        }
    }
}
