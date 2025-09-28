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

namespace Nhom10_QuanLyBanVeXemPhim.BLL
{
    public class PhongChieuBLL
    {
        private PhongChieuDAL dal = new PhongChieuDAL();

        public List<PhongChieuDTO> LayDanhSachPhong()
        {
            return dal.GetAll();
        }

        public bool ThemPhong(PhongChieuDTO p)
        {
            if (string.IsNullOrWhiteSpace(p.TenPhong) || p.SoChoNgoi <= 0)
                return false;

            return dal.Insert(p);
        }
    }
}

