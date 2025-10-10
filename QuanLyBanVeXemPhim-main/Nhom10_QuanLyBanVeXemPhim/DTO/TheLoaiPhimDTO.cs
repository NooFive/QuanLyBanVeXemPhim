using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nhom10_QuanLyBanVeXemPhim.DTO
{
    public class TheLoaiPhimDTO
    {
        public int MaTheLoai { get; set; }
        public string TenTheLoai { get; set; }
        public TheLoaiPhimDTO()
        {

        }
        public TheLoaiPhimDTO(int maTL, string tenTL)
        {
            MaTheLoai = maTL;
            TenTheLoai = tenTL;
        }
    }
}
