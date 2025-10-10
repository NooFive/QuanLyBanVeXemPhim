using Nhom10_QuanLyBanVeXemPhim.DTO;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nhom10_QuanLyBanVeXemPhim.DAL
{
    public class SuatChieuDAL
    {
        private string connectionString = Utilities.connectionString;

        public List<SuatChieuDTO> GetAll()
        {
            List<SuatChieuDTO> list = new List<SuatChieuDTO>();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string sql = "SELECT MaSC, MaPhong, MaPhim, ThoiGianChieu, GiaVe FROM SuatChieu";
                SqlCommand cmd = new SqlCommand(sql, conn);
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(new SuatChieuDTO
                        {
                            MaSC = Convert.ToInt32(reader["MaSC"]),
                            MaPhong = Convert.ToInt32(reader["MaPhong"]),
                            MaPhim = Convert.ToInt32(reader["MaPhim"]),
                            ThoiGianChieu = Convert.ToDateTime(reader["ThoiGianChieu"]),
                            GiaVe = Convert.ToDecimal(reader["GiaVe"])
                        });
                    }
                }
            }
            return list;
        }

        public bool Insert(SuatChieuDTO sc)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand getId = new SqlCommand("SELECT ISNULL(MAX(MaSC),0)+1 FROM SuatChieu", conn);
                sc.MaSC = Convert.ToInt32(getId.ExecuteScalar());
                string sql = @"INSERT INTO SuatChieu(MaSC, MaPhong, MaPhim, ThoiGianChieu, GiaVe)
                           VALUES(@maSC, @maPhong, @maPhim, @thoiGianChieu, @giaVe)";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@maSC", sc.MaSC);
                cmd.Parameters.AddWithValue("@maPhong", sc.MaPhong);
                cmd.Parameters.AddWithValue("@maPhim", sc.MaPhim);
                cmd.Parameters.AddWithValue("@thoiGianChieu", sc.ThoiGianChieu);
                cmd.Parameters.AddWithValue("@giaVe", sc.GiaVe);
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        public bool Update(SuatChieuDTO sc)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string sql = @"UPDATE SuatChieu SET MaPhong=@maPhong, MaPhim=@maPhim, ThoiGianChieu=@thoiGianChieu, GiaVe=@giaVe WHERE MaSC=@maSC";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@maPhong", sc.MaPhong);
                cmd.Parameters.AddWithValue("@maPhim", sc.MaPhim);
                cmd.Parameters.AddWithValue("@thoiGianChieu", sc.ThoiGianChieu);
                cmd.Parameters.AddWithValue("@giaVe", sc.GiaVe);
                cmd.Parameters.AddWithValue("@maSC", sc.MaSC);
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        public bool Delete(int maSC)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string sql = "DELETE FROM SuatChieu WHERE MaSC=@maSC";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@maSC", maSC);
                return cmd.ExecuteNonQuery() > 0;
            }
        }
    }
}