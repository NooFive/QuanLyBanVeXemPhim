using Nhom10_QuanLyBanVeXemPhim.DAL;
using Nhom10_QuanLyBanVeXemPhim.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nhom10_QuanLyBanVeXemPhim.BLL
{
    public class TheLoaiPhimBLL
    {
        private TheLoaiPhimDAL dal = new TheLoaiPhimDAL();

        public List<TheLoaiPhimDTO> LayDanhSachTheLoai()
        {
            return dal.GetAll();
        }

        public bool ThemTheLoai(TheLoaiPhimDTO tl)
        {
            if (string.IsNullOrWhiteSpace(tl.TenTheLoai))
                return false;
            return dal.Insert(tl);
        }

        public bool SuaTheLoai(TheLoaiPhimDTO tl)
        {
            if (tl.MaTheLoai <= 0 || string.IsNullOrWhiteSpace(tl.TenTheLoai))
                return false;
            return dal.Update(tl);
        }

        public bool XoaTheLoai(int maTheLoai)
        {
            if (maTheLoai <= 0)
                return false;
            return dal.Delete(maTheLoai);
        }
    }

}
