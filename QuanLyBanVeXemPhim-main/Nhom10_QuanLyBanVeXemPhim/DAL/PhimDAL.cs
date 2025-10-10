using Nhom10_QuanLyBanVeXemPhim.DTO;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nhom10_QuanLyBanVeXemPhim.DAL
{
    public class PhimDAL
    {
        private string connectionString = Utilities.connectionString;

        public List<PhimDTO> GetAll()
        {
            List<PhimDTO> list = new List<PhimDTO>();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string sql = @"
                    SELECT p.MaPhim, p.TenPhim, p.MoTa, p.ThoiLuong,
                           p.NgayKC, p.NgayKT, p.QuocGia, p.GioiHanTuoi,
                           STUFF((
                               SELECT ', ' + tl.TenTheLoai
                               FROM Phim_TheLoai pt
                               JOIN TheLoaiPhim tl ON pt.MaTheLoai = tl.MaTheLoai
                               WHERE pt.MaPhim = p.MaPhim
                               FOR XML PATH(''), TYPE
                           ).value('.', 'NVARCHAR(MAX)'), 1, 2, '') AS TheLoaiHienThi
                    FROM Phim p";

                SqlCommand cmd = new SqlCommand(sql, conn);
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    list.Add(new PhimDTO
                    {
                        MaPhim = Convert.ToInt32(reader["MaPhim"]),
                        TenPhim = reader["TenPhim"].ToString(),
                        MoTa = reader["MoTa"].ToString(),
                        ThoiLuong = Convert.ToInt32(reader["ThoiLuong"]),
                        NgayKC = Convert.ToDateTime(reader["NgayKC"]),
                        NgayKT = Convert.ToDateTime(reader["NgayKT"]),
                        QuocGia = reader["QuocGia"].ToString(),
                        GioiHanTuoi = Convert.ToInt32(reader["GioiHanTuoi"]),
                        TheLoaiHienThi = reader["TheLoaiHienThi"]?.ToString()
                    });
                }
            }

            return list;
        }

        public int Insert(PhimDTO p, List<int> dsMaTheLoai)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                // Lấy mã phim mới
                SqlCommand getId = new SqlCommand("SELECT ISNULL(MAX(MaPhim), 0) + 1 FROM Phim", conn);
                int newId = Convert.ToInt32(getId.ExecuteScalar());
                p.MaPhim = newId;

                // Thêm phim
                string sql = @"
                    INSERT INTO Phim (MaPhim, TenPhim, MoTa, ThoiLuong, NgayKC, NgayKT, QuocGia, GioiHanTuoi)
                    VALUES (@ma, @ten, @mota, @thoiluong, @ngaykc, @ngaykt, @quocgia, @gioihan)";

                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@ma", p.MaPhim);
                cmd.Parameters.AddWithValue("@ten", p.TenPhim);
                cmd.Parameters.AddWithValue("@mota", p.MoTa);
                cmd.Parameters.AddWithValue("@thoiluong", p.ThoiLuong);
                cmd.Parameters.AddWithValue("@ngaykc", p.NgayKC);
                cmd.Parameters.AddWithValue("@ngaykt", p.NgayKT);
                cmd.Parameters.AddWithValue("@quocgia", p.QuocGia);
                cmd.Parameters.AddWithValue("@gioihan", p.GioiHanTuoi);
                cmd.ExecuteNonQuery();

                // Thêm thể loại
                foreach (int maTL in dsMaTheLoai)
                {
                    SqlCommand cmdTL = new SqlCommand(
                        "INSERT INTO Phim_TheLoai (MaPhim, MaTheLoai) VALUES (@maPhim, @maTL)", conn);
                    cmdTL.Parameters.AddWithValue("@maPhim", p.MaPhim);
                    cmdTL.Parameters.AddWithValue("@maTL", maTL);
                    cmdTL.ExecuteNonQuery();
                }

                return p.MaPhim;
            }
        }

        public bool Update(PhimDTO p, List<int> dsMaTheLoai)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                string sql = @"
                    UPDATE Phim SET
                        TenPhim=@ten, MoTa=@mota, ThoiLuong=@thoiluong,
                        NgayKC=@ngaykc, NgayKT=@ngaykt, QuocGia=@quocgia, GioiHanTuoi=@gioihan
                    WHERE MaPhim=@ma";

                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@ma", p.MaPhim);
                cmd.Parameters.AddWithValue("@ten", p.TenPhim);
                cmd.Parameters.AddWithValue("@mota", p.MoTa);
                cmd.Parameters.AddWithValue("@thoiluong", p.ThoiLuong);
                cmd.Parameters.AddWithValue("@ngaykc", p.NgayKC);
                cmd.Parameters.AddWithValue("@ngaykt", p.NgayKT);
                cmd.Parameters.AddWithValue("@quocgia", p.QuocGia);
                cmd.Parameters.AddWithValue("@gioihan", p.GioiHanTuoi);

                bool result = cmd.ExecuteNonQuery() > 0;

                // Xóa thể loại cũ
                SqlCommand del = new SqlCommand("DELETE FROM Phim_TheLoai WHERE MaPhim=@ma", conn);
                del.Parameters.AddWithValue("@ma", p.MaPhim);
                del.ExecuteNonQuery();

                // Thêm lại thể loại mới
                foreach (int maTL in dsMaTheLoai)
                {
                    SqlCommand cmdTL = new SqlCommand(
                        "INSERT INTO Phim_TheLoai (MaPhim, MaTheLoai) VALUES (@maPhim, @maTL)", conn);
                    cmdTL.Parameters.AddWithValue("@maPhim", p.MaPhim);
                    cmdTL.Parameters.AddWithValue("@maTL", maTL);
                    cmdTL.ExecuteNonQuery();
                }

                return result;
            }
        }

        public bool Delete(int maPhim)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                // Xóa bảng trung gian trước
                SqlCommand delTL = new SqlCommand("DELETE FROM Phim_TheLoai WHERE MaPhim=@ma", conn);
                delTL.Parameters.AddWithValue("@ma", maPhim);
                delTL.ExecuteNonQuery();

                // Xóa phim
                SqlCommand delPhim = new SqlCommand("DELETE FROM Phim WHERE MaPhim=@ma", conn);
                delPhim.Parameters.AddWithValue("@ma", maPhim);
                return delPhim.ExecuteNonQuery() > 0;
            }
        }
    }
}

