using Nhom10_QuanLyBanVeXemPhim.DAL;
using Nhom10_QuanLyBanVeXemPhim.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using Nhom10_QuanLyBanVeXemPhim.DAL;
using Nhom10_QuanLyBanVeXemPhim.DTO;
using System.Data;

namespace Nhom10_QuanLyBanVeXemPhim.BLL
{
    public class PhongChieuBLL
    {
        private PhongChieuDAL dal = new PhongChieuDAL();

        // Lấy danh sách phòng chiếu dưới dạng List
        public List<PhongChieuDTO> LayDanhSachPhong()
        {
            return dal.GetAll();
        }

        // Thêm phòng chiếu
        public bool ThemPhong(PhongChieuDTO p)
        {
            if (string.IsNullOrWhiteSpace(p.TenPhong) || p.SoChoNgoi <= 0)
                return false;

            return dal.Insert(p);
        }

        // Sửa phòng chiếu
        public bool SuaPhong(PhongChieuDTO p)
        {
            if (p.MaPhong <= 0 || string.IsNullOrWhiteSpace(p.TenPhong) || p.SoChoNgoi <= 0)
                return false;

            return dal.Update(p);
        }

        // Xóa phòng chiếu
        public bool XoaPhong(int maPhong)
        {
            if (maPhong <= 0)
                return false;

            return dal.Delete(maPhong);
        }
    }
}

