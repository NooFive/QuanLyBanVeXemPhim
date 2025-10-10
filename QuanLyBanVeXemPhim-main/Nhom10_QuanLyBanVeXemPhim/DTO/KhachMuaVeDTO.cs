using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nhom10_QuanLyBanVeXemPhim.DTO
{
    public class KhachMuaVeDTO
    {
        public int MaKH { get; set; }
        public string TenKH { get; set; }
        public string SDT { get; set; }
        public KhachMuaVeDTO()
        {

        }
        public KhachMuaVeDTO(int maKH, string tenKH, string sdt)
        {
            MaKH = maKH;
            TenKH = tenKH;
            SDT = sdt;
        }
    }
}
