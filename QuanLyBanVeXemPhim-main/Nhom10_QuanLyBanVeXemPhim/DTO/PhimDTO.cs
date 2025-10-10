using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nhom10_QuanLyBanVeXemPhim.DTO
{
    public class PhimDTO
    {
        public int MaPhim { get; set; }
        public string TenPhim { get; set; }
        public string MoTa { get; set; }
        //public int MaTheLoai { get; set; }
        public int ThoiLuong { get; set; }
        public DateTime NgayKC { get; set; }
        public DateTime NgayKT { get; set; }
        public string QuocGia { get; set; }
        public int GioiHanTuoi { get; set; }
        public string TheLoaiHienThi { get; set; }
        public PhimDTO()
        {

        }
        public PhimDTO(int maPhim, string tenPhim, string moTa, int thoiLuong, DateTime ngayKC, DateTime ngayKT, string quocGia, int gioiHanTuoi, string TheLoaiHT)
        {
            MaPhim = maPhim;
            TenPhim = tenPhim;
            MoTa = moTa;
            TheLoaiHienThi = TheLoaiHT;
            ThoiLuong = thoiLuong;
            NgayKC = ngayKC;
            NgayKT = ngayKT;
            QuocGia = quocGia;
            GioiHanTuoi = gioiHanTuoi;
        }
    }
}
