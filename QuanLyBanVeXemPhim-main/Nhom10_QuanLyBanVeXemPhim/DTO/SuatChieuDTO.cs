using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nhom10_QuanLyBanVeXemPhim.DTO
{
    public class SuatChieuDTO
    {
        public int MaSC { get; set; }
        public int MaPhong { get; set; }
        public int MaPhim { get; set; }
        public DateTime ThoiGianChieu { get; set; }
        public decimal GiaVe { get; set; }
        public SuatChieuDTO()
        {

        }
        public SuatChieuDTO(int maSC, int maPhong, int maPhim, DateTime thoiGianChieu, decimal giaVe)
        {
            MaSC = maSC;
            MaPhong = maPhong;
            MaPhim = maPhim;
            ThoiGianChieu = thoiGianChieu;
            GiaVe = giaVe;
        }

    }
}
