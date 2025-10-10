using Nhom10_QuanLyBanVeXemPhim.DAL;
using Nhom10_QuanLyBanVeXemPhim.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nhom10_QuanLyBanVeXemPhim.BLL
{
    public class SuatChieuBLL
    {
        private SuatChieuDAL dal = new SuatChieuDAL();

        public List<SuatChieuDTO> LayDanhSachSuatChieu()
        {
            return dal.GetAll();
        }

        public bool ThemSuatChieu(SuatChieuDTO sc)
        {
            if (sc.MaPhong <= 0 || sc.MaPhim <= 0 || sc.ThoiGianChieu == default || sc.GiaVe <= 0)
                return false;
            return dal.Insert(sc);
        }

        public bool SuaSuatChieu(SuatChieuDTO sc)
        {
            if (sc.MaSC <= 0 || sc.MaPhong <= 0 || sc.MaPhim <= 0 || sc.ThoiGianChieu == default || sc.GiaVe <= 0)
                return false;
            return dal.Update(sc);
        }

        public bool XoaSuatChieu(int maSC)
        {
            if (maSC <= 0)
                return false;
            return dal.Delete(maSC);
        }
    }

}
