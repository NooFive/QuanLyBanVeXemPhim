using Nhom10_QuanLyBanVeXemPhim.DTO;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nhom10_QuanLyBanVeXemPhim.DAL
{
    public class NhanVienDAL
    {
        private string connectionString = Utilities.connectionString;

        public List<NhanVienDTO> GetAll()
        {
            List<NhanVienDTO> list = new List<NhanVienDTO>();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string sql = "SELECT MaNV, TenDangNhap, MatKhau, TenNV, LaAdmin FROM NhanVien";
                SqlCommand cmd = new SqlCommand(sql, conn);
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(new NhanVienDTO
                        {
                            MaNV = Convert.ToInt32(reader["MaNV"]),
                            TenDangNhap = reader["TenDangNhap"].ToString(),
                            MatKhau = reader["MatKhau"].ToString(),
                            TenNV = reader["TenNV"].ToString(),
                            LaAdmin = Convert.ToBoolean(reader["LaAdmin"])
                        });
                    }
                }
            }
            return list;
        }

        public bool Insert(NhanVienDTO nv)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand getId = new SqlCommand("SELECT ISNULL(MAX(MaNV),0)+1 FROM NhanVien", conn);
                nv.MaNV = Convert.ToInt32(getId.ExecuteScalar());
                string sql = @"INSERT INTO NhanVien(MaNV, TenDangNhap, MatKhau, TenNV, LaAdmin)
                           VALUES(@ma, @tendn, @matkhau, @tennv, @laadmin)";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@ma", nv.MaNV);
                cmd.Parameters.AddWithValue("@tendn", nv.TenDangNhap);
                cmd.Parameters.AddWithValue("@matkhau", nv.MatKhau);
                cmd.Parameters.AddWithValue("@tennv", nv.TenNV);
                cmd.Parameters.AddWithValue("@laadmin", nv.LaAdmin);
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        public bool Update(NhanVienDTO nv)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string sql = @"UPDATE NhanVien SET TenDangNhap=@tendn, MatKhau=@matkhau, TenNV=@tennv, LaAdmin=@laadmin WHERE MaNV=@ma";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@tendn", nv.TenDangNhap);
                cmd.Parameters.AddWithValue("@matkhau", nv.MatKhau);
                cmd.Parameters.AddWithValue("@tennv", nv.TenNV);
                cmd.Parameters.AddWithValue("@laadmin", nv.LaAdmin);
                cmd.Parameters.AddWithValue("@ma", nv.MaNV);
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        public bool Delete(int maNV)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string sql = "DELETE FROM NhanVien WHERE MaNV=@ma";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@ma", maNV);
                return cmd.ExecuteNonQuery() > 0;
            }
        }
        public NhanVienDTO DangNhap(string username, string password)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string sql = @"SELECT MaNV, TenDangNhap, MatKhau, TenNV, LaAdmin 
                       FROM NhanVien 
                       WHERE TenDangNhap = @user AND MatKhau = @pass";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@user", username);
                cmd.Parameters.AddWithValue("@pass", password);

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return new NhanVienDTO
                        {
                            MaNV = Convert.ToInt32(reader["MaNV"]),
                            TenDangNhap = reader["TenDangNhap"].ToString(),
                            MatKhau = reader["MatKhau"].ToString(),
                            TenNV = reader["TenNV"].ToString(),
                            LaAdmin = Convert.ToBoolean(reader["LaAdmin"])
                        };
                    }
                }
            }
            return null;
        }

    }
}

    //public NhanVienDTO DangNhap(string username, string password)
    //    {
    //        using (SqlConnection conn = new SqlConnection(Utilities.connectionString))
    //        {
    //            conn.Open();
    //            string sql = "SELECT TenNV, LaAdmin FROM NhanVien WHERE TenDangNhap = @user AND MatKhau = @pass";
    //            SqlCommand cmd = new SqlCommand(sql, conn);
    //            cmd.Parameters.AddWithValue("@user", username);
    //            cmd.Parameters.AddWithValue("@pass", password);

    //            SqlDataReader reader = cmd.ExecuteReader();
    //            if (reader.Read())
    //            {
    //                return new NhanVienDTO
    //                {
    //                    TenNV = reader["TenNV"].ToString(),
    //                    LaAdmin = Convert.ToBoolean(reader["LaAdmin"])
    //                };
    //            }
    //        }
    //        return null;
    //    }


