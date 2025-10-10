using Nhom10_QuanLyBanVeXemPhim.DTO;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nhom10_QuanLyBanVeXemPhim.DAL
{
    public class TheLoaiPhimDAL
    {
        private string connectionString = Utilities.connectionString;

        public List<TheLoaiPhimDTO> GetAll()
        {
            List<TheLoaiPhimDTO> list = new List<TheLoaiPhimDTO>();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string sql = "SELECT * FROM TheLoaiPhim";
                SqlCommand cmd = new SqlCommand(sql, conn);
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(new TheLoaiPhimDTO
                        {
                            MaTheLoai = Convert.ToInt32(reader["MaTheLoai"]),
                            TenTheLoai = reader["TenTheLoai"].ToString()
                        });
                    }
                }
            }
            return list;
        }

        public bool Insert(TheLoaiPhimDTO t)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand getId = new SqlCommand("SELECT ISNULL(MAX(MaTheLoai),0)+1 FROM TheLoaiPhim", conn);
                t.MaTheLoai = Convert.ToInt32(getId.ExecuteScalar());
                string sql = "INSERT INTO TheLoaiPhim(MaTheLoai, TenTheLoai) VALUES(@ma, @ten)";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@ma", t.MaTheLoai);
                cmd.Parameters.AddWithValue("@ten", t.TenTheLoai);
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        public bool Update(TheLoaiPhimDTO t)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string sql = "UPDATE TheLoaiPhim SET TenTheLoai=@ten WHERE MaTheLoai=@ma";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@ten", t.TenTheLoai);
                cmd.Parameters.AddWithValue("@ma", t.MaTheLoai);
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        public bool Delete(int maTheLoai)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string sql = "DELETE FROM TheLoaiPhim WHERE MaTheLoai=@ma";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@ma", maTheLoai);
                return cmd.ExecuteNonQuery() > 0;
            }
        }
    }
}