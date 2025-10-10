using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Nhom10_QuanLyBanVeXemPhim.DTO;

namespace Nhom10_QuanLyBanVeXemPhim.DAL
{
    public class PhongChieuDAL
    {
        private string connectionString = Utilities.connectionString;

        public List<PhongChieuDTO> GetAll()
        {
            List<PhongChieuDTO> list = new List<PhongChieuDTO>();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string sql = "SELECT * FROM PhongChieu";
                SqlCommand cmd = new SqlCommand(sql, conn);
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(new PhongChieuDTO
                        {
                            MaPhong = Convert.ToInt32(reader["MaPhong"]),
                            TenPhong = reader["TenPhong"].ToString(),
                            SoChoNgoi = Convert.ToInt32(reader["SoChoNgoi"]),
                            TinhTrang = reader["TinhTrang"].ToString()
                        });
                    }
                }
            }
            return list;
        }

        public bool Insert(PhongChieuDTO p)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand getId = new SqlCommand("SELECT ISNULL(MAX(MaPhong),0)+1 FROM PhongChieu", conn);
                p.MaPhong = Convert.ToInt32(getId.ExecuteScalar());
                string sql = "INSERT INTO PhongChieu(MaPhong, TenPhong, SoChoNgoi, TinhTrang) VALUES(@ma, @ten, @socho, @tinhtrang)";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@ma", p.MaPhong);
                cmd.Parameters.AddWithValue("@ten", p.TenPhong);
                cmd.Parameters.AddWithValue("@socho", p.SoChoNgoi);
                cmd.Parameters.AddWithValue("@tinhtrang", p.TinhTrang);
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        public bool Update(PhongChieuDTO p)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string sql = "UPDATE PhongChieu SET TenPhong=@ten, SoChoNgoi=@socho, TinhTrang=@tinhtrang WHERE MaPhong=@ma";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@ten", p.TenPhong);
                cmd.Parameters.AddWithValue("@socho", p.SoChoNgoi);
                cmd.Parameters.AddWithValue("@tinhtrang", p.TinhTrang);
                cmd.Parameters.AddWithValue("@ma", p.MaPhong);
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        public bool Delete(int maPhong)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string sql = "DELETE FROM PhongChieu WHERE MaPhong=@ma";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@ma", maPhong);
                return cmd.ExecuteNonQuery() > 0;
            }
        }
    }
}



