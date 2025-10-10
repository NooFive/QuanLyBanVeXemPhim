using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nhom10_QuanLyBanVeXemPhim.DTO
{
    public class VeDTO
    {
        public int MaVe { get; set; }
        public int MaSC { get; set; }
        public int MaNV { get; set; }
        public int MaKH { get; set; }
        public int MaGhe { get; set; }
        public VeDTO()
        {

        }
        public VeDTO(int maVe, int maSC, int maNV, int maKH, int maGhe)
        {
            MaVe = maVe;
            MaSC = maSC;
            MaNV = maNV;
            MaKH = maKH;
            MaGhe = maGhe;
        }
    }
}
